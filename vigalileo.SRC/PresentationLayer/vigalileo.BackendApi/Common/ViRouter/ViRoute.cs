namespace vigalileo.BackendApi.Common.ViRouter
{
    public class ViRoute
    {
        public string PathRegex { get; set; }
        public string Method { get; set; }

        public ViRoute(string pathRegex, string method)
        {
            PathRegex = pathRegex;
            Method = method;
        }
    }
}