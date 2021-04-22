namespace vigalileo.Utilities.UriUtils
{
    public static class UriConstants
    {
        // public static ViUri API_USERS_OBJECT = new ViUri(@"/api/users", @"USER");
        // public static ViUri API_CARTS_OBJECT = new ViUri(@"/api/carts", @"CART");
        // public static ViUri API_ORDERS_OBJECT = new ViUri(@"/api/orders", @"ORDER");
        // public static ViUri API_PRODUCTS_OBJECT = new ViUri(@"/api/products", @"PRODUCT");
        // public static ViUri API_STORES_OBJECT = new ViUri(@"/api/stores", @"STORE");

        public static ViUri API_USERS_ID_GET = new ViUri(@"/api/users/\d+", GET, "READ USER", true, true);
        public const string API_USERS_ID_GET_PATH = @"/api/users/{userId}";
        public static ViUri API_USERS_REGISTER_POST = new ViUri(@"/api/users/register", POST, "CREATE USER", false, false);
        public const string API_USERS_REGISTER_POST_PATH = @"/api/users/register";
        public static ViUri API_USERS_LOGIN_POST = new ViUri(@"/api/users/login", POST, "LOGIN USER", false, false);
        public const string API_USERS_LOGIN_POST_PATH = @"/api/users/login";



        public const string GET = "GET";
        public const string POST = "POST";
        public const string PUTCH = "PUTCH";
        public const string DELETE = "DELETE";

        // public const string API_USERS_LOGIN = @"/api/users/login";
        // public const string API_USERS_REGISTER = @"/api/users/register";


        public class ViUri
        {
            public readonly string PathRegex;
            public readonly string Method;
            public readonly string Name;
            public readonly bool IsAuthenRoute;
            public readonly bool IsAuthorRoute;

            public ViUri(string pathRegex, string method, string name, bool isAuthenRoute, bool isAuthorRoute)
            {
                PathRegex = pathRegex;
                Method = method;
                Name = name;
                IsAuthenRoute = isAuthenRoute;
                IsAuthorRoute = isAuthorRoute;
            }
        }
    }
}

// public static string API_USERS_ID = "/api/users/{userId}";
// public static string API_USERS_ID_REGEX = @"/api/users/\d+";

// public static string API_USERS_ID_CARTS = @"/api/users/{userId}/carts/{cartId}";
// public static string API_USERS_ID_CARTS_REGEX = @"/api/users/\d+/carts\d+";


// public static ViUri API_USERS_ID = new ViUri(@"/api/users/{userId}", @"/api/users/\d+");
// public static ViUri API_USERS_ID_ROLES = new ViUri(@"/api/users/{userId}/roles", @"/api/users/\d+/roles");
// public static ViUri API_STORES = new ViUri(@"/api/stores", @"/api/stores");
// public static ViUri API_STORES_ID = new ViUri(@"/api/stores/{storeId}", @"/api/stores/\d+");
// public static ViUri API_STORES_ID_PRODUCTS = new ViUri(@"/api/stores/{storeId}/products", @"/api/stores/\d+/products");
// public static ViUri API_STORES_ID_PRODUCTS_ID = new ViUri(@"/api/stores/{storeId}/products", @"/api/stores/\d+/products");
// public static ViUri API_STORES_ID_ORDERS = new ViUri(@"/api/stores/{storeId}/orders", @"/api/stores/\d+/orders");
// public static ViUri API_STORES_ID_ORDERS_ID = new ViUri(@"/api/stores/{storeId}/orders", @"/api/stores/\d+/orders");
// public static ViUri API_CARTS = new ViUri(@"/api/stores", @"/api/stores");
// public static ViUri API_CARTS_ID = new ViUri(@"/api/stores/{storeId}", @"/api/stores/\d+");
// public static ViUri API_ORDERS = new ViUri(@"/api/orders", @"/api/orders");
// public static ViUri API_ORDERS_ID = new ViUri(@"/api/orders/{orderId}", @"/api/orders/\d+");
// public static ViUri API_PRODUCTS = new ViUri(@"/api/products", @"/api/products");
// public static ViUri API_PRODUCTS_ID = new ViUri(@"/api/products/{storeId}", @"/api/products/\d+");