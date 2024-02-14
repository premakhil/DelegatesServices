using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DelegatesServices;

namespace DelegatesServices
{
    public class UserRepository
        
    {
        private readonly List<User> _users = new List<User>();

        public User GetUser(int userId)
        {
            return _users[userId - 100];
        }

        public void AddUser(string name, string email, string contact)
        {
            int id = _users.Count + 100;
            _users.Add(new User { Id = id, Name = name, Email = email, Contact = contact });
        }

        public void UpdateUser(int userId, string[] properties)
        {
            _users[userId - 100].Name = properties[0];
            _users[userId - 100].Email = properties[1];
            _users[userId - 100].Contact = properties[2];
            Console.WriteLine("Updated User");
        }

        public void DeleteUser(int userId)
        {
            _users.RemoveAt(userId - 100);
            Console.WriteLine("User Removed successfully");
        }

        public void ShowUsers()
        {
            foreach (var user in _users)
            {
                Console.WriteLine($"ID: {user.Id}\tNAME: {user.Name}\tEMAIL: {user.Email}\tContact: {user.Contact}");
            }
        }
    }
}
