using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BusinessLayer;
using Entity;


namespace UserManagement.Repository
{
    
    public class UserRepository
    {
        UserBusiness objUserBusiness = new UserBusiness();

        internal bool AddUser(User user)
        {
            bool check=objUserBusiness.AddUser(user);
            return check;
        }

        public List<User> GetUsers()
        {
            List<User> users = objUserBusiness.GetUsers();
            return users;
        }

        public bool UpdateUser(User obj)
        {
            bool check = objUserBusiness.UpdateUser(obj);
            return check;
        }

        public bool DeleteUser(int Id)
        {
            bool check = objUserBusiness.DeleteUser(Id);
            return check;
        }
    }
}