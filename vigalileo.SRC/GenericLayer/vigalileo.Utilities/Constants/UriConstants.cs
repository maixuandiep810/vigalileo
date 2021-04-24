namespace vigalileo.Utilities.Constants
{
    public static class UriConstants
    {
        public const string API_USERS_ID_GET_PATH = @"/api/users/{userId}";
        public const string API_USERS_NAME_GET_PATH = @"/api/users/{userName}";
        public const string API_USERS_REGISTER_POST_PATH = @"/api/users/register";
        public const string API_USERS_LOGIN_POST_PATH = @"/api/users/login";
        public const string API_USERS_UPDATE_PUTCH_PATH = @"/api/users/login/{userId}";
        public const string API_USERS_UPDATE_PASSWORD_PUTCH_PATH = @"/api/users/login/{userId}/update-password";



        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUTCH = "PUTCH";
        public const string DELETE = "DELETE";

    }
}