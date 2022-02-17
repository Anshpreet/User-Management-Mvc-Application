using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserManagement.Repository;
using Entity;
using BusinessLayer;



namespace UserManagement.Controllers
{
    public class UserController : Controller
    {

        public ActionResult GetUsers()
        {

            UserRepository userRepository = new UserRepository();
            var model = userRepository.GetUsers();
            return View(model);
            
        }


        public ActionResult AddUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddUser(User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserRepository userRepository = new UserRepository();

                    if (userRepository.AddUser(user))
                    {
                        ViewBag.Message = "User details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }


        public ActionResult UpdateUser(int id)
        {
            UserRepository userRepository = new UserRepository();

            return View(userRepository.GetUsers().Find(User => User.Id == id));

        }


        [HttpPost]

        public ActionResult UpdateUser(int id, User obj)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                userRepository.UpdateUser(obj);

                return RedirectToAction("GetUsers");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult DeleteUser(int id)
        {
            UserRepository userRepository = new UserRepository();

            return View(userRepository.GetUsers().Find(User => User.Id == id));

        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User obj)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                if (userRepository.DeleteUser(obj.Id))
                {
                    ViewBag.AlertMsg = "User details deleted successfully";

                }
                return RedirectToAction("GetUsers");

            }
            catch
            {
                return View();
            }
        }


    }
}
