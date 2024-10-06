using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.WFA_classes
{
    internal class Class_WFA
    {
        //Getter setter properties which acts as Data Carrioer for our app

        public int studentID { get; set; }
        public string name { get; set; }
        public string course { get; set; }
        public string branch { get; set; }
        public string email { get; set; }
        public long contactNo { get; set; }

        //static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;


        //Selecting data from database

        public DataTable select()
        {

            //step1: Database connection
            MySqlConnection conn = new DatabaseConnection().GetConnection();
            DataTable dt = new DataTable();
            try
            {
                //ste2:Writing SQL query
                string sql = "SELECT * FROM wfp_datatable";
                //creating cmd using sql and conn
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //creatng SQL DataAdapter using cmd
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;

        }

        //Inserting data into database
        public bool Insert(Class_WFA c)
        {
            //creating a deafult return type and setting its value to false
            bool isSuccess = false;

            //connect database
            MySqlConnection conn = new DatabaseConnection().GetConnection();

            try
            {
                //create a SQl query to insert data
                string query = "INSERT INTO wfp_datatable(studentId,name,course,branch,email,contactNo) VALUES (@studentID,@name,@course,@branch,@email,@contactNo)";
                //creating cmd using sql and conn
                MySqlCommand cmd = new MySqlCommand(query, conn);

                //create Parameters to add data
                cmd.Parameters.AddWithValue("@studentID", c.studentID);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@course", c.course);
                cmd.Parameters.AddWithValue("@branch", c.branch);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);

                //connection open 
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully  the values of rows will bw graater than 0 else 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        //method  to update data in dbs
        public bool Update(Class_WFA c)
        {
            //create a default return type and sets its value to false
            bool isSuccess = false;

            MySqlConnection conn = new DatabaseConnection().GetConnection();

            try
            {
                //SQl to update data in our database
                string sql = "UPDATE wfp_datatable  SET studentId=@studentId,name=@name,course=@course,branch=@branch,email=@email,contactNo=@contactNo  WHERE studentId=@studentId";

                //creating sql command
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@studentID", c.studentID);
                cmd.Parameters.AddWithValue("@name", c.name);
                cmd.Parameters.AddWithValue("@course", c.course);
                cmd.Parameters.AddWithValue("@branch", c.branch);
                cmd.Parameters.AddWithValue("@email", c.email);
                cmd.Parameters.AddWithValue("@contactNo", c.contactNo);

                //connection open 
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully  the values of rows will bw graater than 0 else 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        //method to delete data from database
        public bool Delete(Class_WFA c)
        {

            bool isSuccess = false;

            MySqlConnection conn = new DatabaseConnection().GetConnection();

            try
            {
                //SQl to delete data from our database
                string sql = "DELETE FROM wfp_datatable WHERE studentId=@studentId";

                //creating sql command
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@studentID", c.studentID);


                //connection open 
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully  the values of rows will bw graater than 0 else 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;




        }

    }
}
