namespace ipog.bureaucrats.Models
{
    public class UserModel
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Password { get; set; }
        public long RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? ActionBy { get; set; }
        public bool IsActive { get; set; }
        public DateTime ActionDate { get; set; }
        public bool IsLogin { get; set; }
    }

    public class GetUserModel : UserModel
    {
        public new string? ActionBy { get; set; }
        public new DateTime ActionDate { get; set; }
    }

    public class UserModelCollection : List<GetUserModel> { }

    public class UserLoginModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }

    public class UpdatePasswordModel : UserLoginModel
    {
        public string? NewPassword { get; set; }
    }
}
