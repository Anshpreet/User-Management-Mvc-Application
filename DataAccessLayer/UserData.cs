using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Entity;
using System.Collections.Generic;
using System.Data;

namespace DataAccessLayer
{
    public class UserData
    {

        string conStr = ConfigurationManager.ConnectionStrings["UserConString"].ConnectionString;

        public bool AddUser(User obj)
        {

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand command = new SqlCommand("spAddUser", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            
            command.Parameters.AddWithValue("@UserName", obj.Name);
            command.Parameters.AddWithValue("@Age", obj.Age);
            command.Parameters.AddWithValue("@Dob", obj.Dob);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }
        }


        public List<User> GetUsers()
        {
            
            List<User> users= new List<User>();

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand command = new SqlCommand("spGetUsers", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            connection.Open();
            da.Fill(dt);
            connection.Close();
            //Bind EmpModel generic list using dataRow     
            foreach (DataRow dr in dt.Rows)
            {

                users.Add(

                    new User
                    {

                        Id = Convert.ToInt32(dr["UserId"]),
                        Name = Convert.ToString(dr["UserName"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        Dob = Convert.ToDateTime(dr["Dob"])

                    }
                    );
            }

            return users;
        }

        public bool UpdateUser(User obj)
        {

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand command = new SqlCommand("spUpdateUser", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", obj.Id);
            command.Parameters.AddWithValue("@UserName", obj.Name);
            command.Parameters.AddWithValue("@Age", obj.Age);
            command.Parameters.AddWithValue("@Dob", obj.Dob);
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUser(int Id) 
        {

            SqlConnection connection = new SqlConnection(conStr);

            SqlCommand command = new SqlCommand("spDeleteUser", connection);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@UserId", Id);

            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }

    }
}
