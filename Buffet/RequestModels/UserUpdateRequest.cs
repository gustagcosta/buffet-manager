namespace Buffet.RequestModels
{
    public class UserUpdateRequest
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
        public string newPasswordConfirm { get; set; }
    }
}