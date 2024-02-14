using DelegatesServices;

class NotificationHandler
{
    public UserService _userService;

    public Notification _smsService;
    public Notification _emailService;
    public Notification _pushNotificationService;
    public NotificationHandler()
    {
        _userService = new UserService();
        _smsService = new Notification("SMSService");
        _emailService = new Notification("EmailService");
        _pushNotificationService = new Notification("PushNotificationService");

        _userService.UserChanged += _smsService.OnUserAction;
        _userService.UserChanged += _emailService.OnUserAction;
        _userService.UserChanged += _pushNotificationService.OnUserAction;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        NotificationHandler handler = new NotificationHandler();
        bool running = true;
        while (running)
        {
            Console.WriteLine("1.Add User\n2.Update User\n3.Delete User\n4.Exit");
            running = HandleInput(handler._userService);
        }
    }
    static bool HandleInput(UserService userService)
    {
        bool running = true;
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                HandleAddUser(userService);
                break;
            case "2":
                HandleUpdateUser(userService);
                break;
            case "3":
                HandleDeleteUser(userService);
                break;
            case "4":
                running = false;
                break;
            default:
                Console.WriteLine("Wrong Option");
                break;
        }
        return running;
    }

    static void HandleAddUser(UserService userService)
    {
        Console.WriteLine("Enter User Details(Name ,Email ,Contact)");
        string response = Console.ReadLine();
        string[] properties = response.Split(',');
        string name = properties[0];
        string email = properties[1];
        string contact = properties[2];
        userService.AddUser(name, email, contact);
    }

    static void HandleUpdateUser(UserService userService)
    {
        userService.DisplayUsers();
        Console.WriteLine("Enter the ID of the User you want to update");
        int userId = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter updated details");
        string response = Console.ReadLine();
        string[] properties = response.Split(',');
        userService.UpdateUser(properties, userId);
    }

    static void HandleDeleteUser(UserService userService)
    {
        Console.WriteLine("Enter the ID of the User you want to delete");
        int userId = Convert.ToInt32(Console.ReadLine());
        userService.DeleteUser(userId);
    }
}