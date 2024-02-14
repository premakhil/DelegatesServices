using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesServices
{
    public class UserService
    {
        private UserRepository _repository = new UserRepository();


        public event EventHandler<UserEvent> UserChanged;

        public void AddUser(string name, string email, string contact)
        {
            _repository.AddUser(name, email, contact);
            UserChanged.Invoke(null, new UserEvent(name, email, UserEvent.UserActionType.Added));
        }

        public void UpdateUser(string[] properties, int userId)
        {
            _repository.UpdateUser(userId, properties);
            UserChanged.Invoke(null, new UserEvent(properties[0], properties[1], UserEvent.UserActionType.Updated));
        }

        public void DeleteUser(int userId)
        {
            User user = _repository.GetUser(userId);
            _repository.DeleteUser(userId);
            UserChanged.Invoke(null, new UserEvent(user.Name, user.Email, UserEvent.UserActionType.Removed));
        }

        public void DisplayUsers()
        {
            _repository.ShowUsers();
        }
    }
}
