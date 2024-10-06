using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.WFA_classes;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Class_WFA c = new Class_WFA();

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            //load data in gridview
            DataTable dt = c.select();
            StudentRecordList.DataSource = dt;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void LabelContact_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //get the value from the input fields
            c.studentID = int.Parse(textBoxStudentID.Text);
            c.name = textBoxName.Text;
            c.course = comboBoxCourse.Text;
            c.branch = textBoxBranch.Text;
            c.email = textBoxEmail.Text;
            c.contactNo = long.Parse(textBoxContactNo.Text);

            //inserting data into database
            bool success = c.Insert(c);
            if (success == true)
            {
                MessageBox.Show("New record insertion successful");
                // calling clear method
                clear();
            }
            else
            {
                MessageBox.Show("Failed to add new record.TRY AGAIN");
            }

            //load data in gridview
            DataTable dt = c.select();
            StudentRecordList.DataSource = dt;

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

            //get the data from the textboxes
            c.studentID=int.Parse(textBoxStudentID.Text);
            c.name = textBoxName.Text;
            c.course = comboBoxCourse.Text;
            c.branch = textBoxBranch.Text;
            c.email = textBoxEmail.Text;
            c.contactNo = long.Parse(textBoxContactNo.Text);

            //Update Data in database
            bool success=c.Update(c);
            if (success == true)
            {
                MessageBox.Show(" record updation successful");
                //loading the data in grid
                DataTable dt = c.select();
                StudentRecordList.DataSource = dt;
                //call clear method
                clear();
            }
            else
            {
                MessageBox.Show("Failed to update record.TRY AGAIN");
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Method to clear all fields
        public void clear()
        {
            textBoxStudentID.Text = "";
            textBoxName.Text = "";
            comboBoxCourse.Text = "";
            textBoxBranch.Text = "";
            textBoxEmail.Text = "";
            textBoxContactNo.Text = "";


        }

        private void StudentRecordList_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get the data from View and Load it tot he textboxes respectively
            //identify the  row on which the mouse is clicked
            int rowIndex = e.RowIndex;
            textBoxStudentID.Text = StudentRecordList.Rows[rowIndex].Cells[0].Value.ToString();
            textBoxName.Text = StudentRecordList.Rows[rowIndex].Cells[1].Value.ToString();
            comboBoxCourse.Text = StudentRecordList.Rows[rowIndex].Cells[2].Value.ToString();
            textBoxBranch.Text = StudentRecordList.Rows[rowIndex].Cells[3].Value.ToString();
            textBoxEmail.Text = StudentRecordList.Rows[rowIndex].Cells[4].Value.ToString();
            textBoxContactNo.Text = StudentRecordList.Rows[rowIndex].Cells[5].Value.ToString();

        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            //calling clear method
            clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //get data from textbox
            c.studentID=Convert.ToInt32(textBoxStudentID.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                MessageBox.Show(" record deletion successful");
                //Refresh the datagrid
                //loading the data in grid
                DataTable dt = c.select();
                StudentRecordList.DataSource = dt;
                //call clear method
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete record.TRY AGAIN");
            }
        }

        

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            //get the value from textbox
            string keyword=textBoxSearch.Text;

            MySqlConnection conn = new DatabaseConnection().GetConnection();
            string sql = "SELECT * FROM wfp_datatable WHERE  name Like '%" + keyword + "%'OR course LIKE '%" + keyword + "%' OR branch Like '%" + keyword + "%' OR email Like '%" + keyword + "%'";


            MySqlDataAdapter sda = new MySqlDataAdapter(sql,conn);

            DataTable dt = new DataTable();

            sda.Fill(dt);

            StudentRecordList.DataSource = dt;

        }

        private void textBoxStudentID_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxCourse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxBranch_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxContactNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }
    }   
}
