namespace RestSharpProject
{
    public static class EndPoints
    {
        public const string BaseUrl = "https://api.restful-api.dev";
        public const string CREATE_USER = "/objects";
        public const string UPDATE_USER = "/objects/{id}";
        public const string DELETE_USER = "/objects/{id}";
        public const string GET_USER = "/objects/{id}";
        public const string GET_LIST_USERS = "/objects";
        public const string GET_USERS = "/objects?ids={ids}";
    }
}