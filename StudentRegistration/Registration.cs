using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration
{
    public partial class Registration : Form
    {
        String connectionString = "Server=ARYASHAJI\\SQLEXPRESS;Database=StudentRegistrationDatabase;Trusted_Connection=True;";
        public Registration()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK) ;
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);

            }
            string path = openFileDialog.FileName;
            File.WriteAllText(@"Downloads", path);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string Address = txtAddress.Text;
            

            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand("StudentSave", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("Name", txtName.Text);
            command.Parameters.AddWithValue("Address", txtAddress.Text);
            if (radioMale.Checked == true)
            {
                command.Parameters.AddWithValue("Gender", "M");

            }
            if (radioFemale.Checked == true)
            {
                command.Parameters.AddWithValue("Gender", "F");
            }

            command.Parameters.AddWithValue("Sslc", checkTen.Checked);
            command.Parameters.AddWithValue("PlusTwo", checkPlusTwo.Checked);
            command.Parameters.AddWithValue("Ug", checkUg.Checked);
            command.Parameters.AddWithValue("Pg", checkPg.Checked);
            command.Parameters.AddWithValue("Image", File.ReadAllText(@"Downloads"));
            command.ExecuteNonQuery();
            connection.Close();
            txtName.Text = txtAddress.Text = "";
            checkTen.Checked = checkPlusTwo.Checked = checkUg.Checked = checkPg.Checked = false;
            radioFemale.Checked = radioMale.Checked = false;
            pictureBox1.Image = null;
            MessageBox.Show("Saved");
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();

                SqlCommand command = new SqlCommand("StudentRead", con);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("Name", txtName.Text);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    
                    txtAddress.Text = reader["Address"].ToString();
                    if (reader["Gender"].ToString() == "M")
                    {
                        radioMale.Checked = true;
                    }
                    if (reader["Gender"].ToString() == "F")
                    {
                        radioFemale.Checked = true;
                    }
                    if (reader["Sslc"].ToString() == "1")
                    {
                        checkTen.Checked = true;

                    }
                    if (reader["PlusTwo"].ToString() == "1")
                    {
                        checkPlusTwo.Checked = true;
                    }
                    if (reader["Ug"].ToString() == "1")
                    {
                        checkUg.Checked = true;
                    }
                    if (reader["Pg"].ToString() == "1")
                    {
                        checkPg.Checked = true;
                    }
                    pictureBox1.Image = Image.FromFile("" + reader["Image"].ToString());
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    }


    

