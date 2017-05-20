namespace FooBar.Web.Core.Json
{
    public class FooBarContractResolver : NullToEmptyListResolver
    {
        //Marker class
        //As Json.net don't accept multiple contract resolvers we need to use inheritance.
        //For additional needs of custom contract resolvers, add your new one to the inheritance chain by changing the inheritance of this class
        //and let your new resolver inherit from the one currently inherited here.
    }
}