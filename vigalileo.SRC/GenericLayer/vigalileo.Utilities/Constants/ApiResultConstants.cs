namespace vigalileo.Utilities.Constants
{
    public static class ApiResultConstants
    {
        public enum CODE
        {
            ERROR = 6000,
            CLIENT_ERROR = 7000,
            SERVER_ERROR = 8000,
            SUCCESS = 9000,

            USERNAME_PASSWORD_EXISTS_E = 6001,
            USERNAME_PASSWORD_INCORRECT_E = 6002,
            ROLE_EXISTS_E = 6003,

            SUCCESSFULLY_REGISTER_S = 9001,
            SUCCESSFULLY_CREATING_ROLE_S = 9002
        }

        public static string MESSAGE(CODE valueCode)
        {
            switch (valueCode)
            {
                case CODE.ERROR:
                    return "Error.";
                case CODE.CLIENT_ERROR:
                    return "Error.";
                case CODE.SERVER_ERROR:
                    return "Error.";
                case CODE.SUCCESS:
                    return "Successed.";

                case CODE.USERNAME_PASSWORD_EXISTS_E:
                    return "The username or email already exists.";
                case CODE.USERNAME_PASSWORD_INCORRECT_E:
                    return "The username or password is incorrect.";
                case CODE.ROLE_EXISTS_E:
                    return "The role already exists.";

                case CODE.SUCCESSFULLY_REGISTER_S:
                    return "Your account has been succesfully created.";
                case CODE.SUCCESSFULLY_CREATING_ROLE_S:
                    return "The role has been succesfully created.";

                default:
                    return "Error.";
            }
        }

    }
}