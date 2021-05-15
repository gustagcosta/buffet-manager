namespace Buffet.RequestModels
{
    public class UserUpdateRequest
    {
        public string email { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
    }
}