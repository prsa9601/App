namespace AppRazorPage.Models.User
{
    public class AddUserCommand
    {
        public AddUserCommand(string userName, string phoneNumber, string password)
        {
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }  
    public class EditUserCommand
    {
        public EditUserCommand(long userId, string userName, string phoneNumber, string password)
        {
            UserId = userId;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
        }

        public long UserId { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }  
    public class SetProductUserCommand
    {
        public SetProductUserCommand(long userId, string title, string price)
        {
            UserId = userId;
            Title = title;
            Price = price;
        }

        public long UserId { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
    }  
    public class SetRoleUserCommand
    {
        public SetRoleUserCommand(long userId, string title)
        {
            UserId = userId;
            Title = title;
        }

        public long UserId { get; set; }
        public string Title { get; set; }
    }
}
