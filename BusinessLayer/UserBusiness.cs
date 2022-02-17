using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using DataAccessLayer;
using System.Collections;

namespace BusinessLayer
{
    public class UserBusiness
    {
        UserData objUserData = new UserData();

       public bool AddUser(User obj)
        {
           bool check= objUserData.AddUser(obj);
           return check;
        }

        public List<User> GetUsers()
        {
            List<User> users = objUserData.GetUsers();
            return users;
        }

        public bool UpdateUser(User obj)
        {
            bool check = objUserData.UpdateUser(obj);
            return check;
        }

        public bool DeleteUser(int Id)
        {
            bool check = objUserData.DeleteUser(Id);
            return check;
        }




    }
}
