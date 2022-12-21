using Database_Service.Models;

namespace Authentication_Service.Response
{
    public class RegisterResponse
    {
        public string Message { get; set; }

        public User? User { get; set; }
            
        public RegisterResponse(string message, User? user)
        {
            Message = message;
            User = user;
        }
    }
}
