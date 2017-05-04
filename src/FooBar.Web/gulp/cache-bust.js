var crypto = require('crypto');
var through2 = require('through2');
var path = require('path');
var slash = require('slash');
var jsonfile = require('jsonfile');
var fs = require('fs');

module.exports = function(options) {
	this.referenceFileName = (options && options.referenceFileName) || 'wwwroot/dist/cachebust.json';
	this.checksumLength = (options && options.checksumLength) || 8;
	this.bust = bust;
	this.resolve = resolve;
};

function bust() {
	var referenceFileName = this.referenceFileName;
	var checksumLength = this.checksumLength;

	return through2.obj(function transform(file, encoding, callback) {
		var bustedPath = getBustedPath(file, checksumLength);
		if (!bustedPath) {
			this.push(file);
			return callback();
		}

		var originalPath = slash(file.relative);
		file.path = bustedPath;
		createMappingFileIfMissing(referenceFileName);
		writeMapping(referenceFileName, originalPath, slash(file.relative));
		this.push(file);
		return callback();
	});
}

function getChecksum(file, checksumLength) {
	var hash = crypto.createHash('md5');

	if (file.isNull()) {
		return null;
	}

	if (file.isStream()) {
		file.pipe(hash);
		hash.end();
	}

	if (file.isBuffer()) {
		hash.end(file.contents);
	}

	return hash.read().toString('hex').substr(0, checksumLength);
}

function getBustedPath(file, checksumLength) {
	var checksum = getChecksum(file, checksumLength);
	if (!checksum) {
		return null;
	}
	var extname = path.extname(file.path);
	var basename = path.basename(file.path, extname);
	var dirname = path.dirname(file.path);

	var str = path.join(dirname, basename + '.' + checksum + extname);
	return slash(str);
}

function writeMapping(referenceFileName, originalPath, bustedPath) {
	var mappings = jsonfile.readFileSync(referenceFileName);
	mappings[originalPath] = bustedPath;
	jsonfile.writeFileSync(referenceFileName, mappings);
}

function createMappingFileIfMissing(referenceFileName) {
	if (fs.existsSync(referenceFileName)) return;
	jsonfile.writeFileSync(referenceFileName, {});
}

function resolve(originalPath, removeExtension) {
	var stat = fs.statSync(this.referenceFileName);
	var mappings = stat.isFile() ? jsonfile.readFileSync(this.referenceFileName) : {};
	var path = (mappings[originalPath] || originalPath);
	var dotIndex = path.lastIndexOf('.');
	return removeExtension && dotIndex > -1 ? path.substring(0, dotIndex) : path;
}