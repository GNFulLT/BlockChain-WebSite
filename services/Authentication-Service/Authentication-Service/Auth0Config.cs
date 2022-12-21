namespace Authentication_Service
{
    public class Auth0Config
    {
        public string Domain { get; set; }

        public string ClientId { get; set; }

        public string ReturnUrl { get; set; }
        
        public string ClientSecret { get; set; }
    }
}
