namespace Authentication_Service.Request
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RedirectURL { get; set; }
    }
}
