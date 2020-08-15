using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Application1
{
    public partial class Form1 : Form
    {
        SqlConnection sqlConnection;

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\User\Desktop\politex\КУРСОВА\Programm_kyrsova\Application1\Application1\Database3.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            //assing dlya norm robotu interfeisa;
            await sqlConnection.OpenAsync();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (label4.Visible)
                label4.Visible = false;

            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox1.Text) &&
                !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text))
            {

                SqlCommand command = new SqlCommand("INSERT INTO [LogIn] (Name, Pass)VALUES(@Name, @Pass)", sqlConnection);

                command.Parameters.AddWithValue("Name", TextBox2.Text);
                command.Parameters.AddWithValue("Pass", TextBox1.Text);

                await command.ExecuteNonQueryAsync();

                Hide();
                Form2 fr2 = new Form2();
                fr2.ShowDialog();
            }

            else
            {
                label4.Visible = true;
                label4.Text = "Введіть логін та пароль!!!";
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
          //  Close();
        }
    }
}
