namespace Buffet.RequestModels
{
    public class UserRegisterRequest
    {
        public string email { get; set; }
        public string password { get; set; }
        public string passwordConfirm { get; set; }
    }
}