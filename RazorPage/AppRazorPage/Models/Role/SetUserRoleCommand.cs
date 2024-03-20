namespace AppRazorPage.Models.Role
{
    public class SetUserRoleCommand
    {
        public SetUserRoleCommand(long roleId, string userName, string phoneNumber, string password, string title)
        {
            RoleId = roleId;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
            Title = title;
        }

        public long RoleId  { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Title { get; set; }
    }
}
