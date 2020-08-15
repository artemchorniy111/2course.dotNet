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
    public partial class Form3 : Form
    {
        SqlConnection sqlConnection;
        public Form3()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\User\Desktop\politex\КУРСОВА\Programm_kyrsova\Application1\Application1\Database2.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
            Form2 fr2 = new Form2();
            fr2.ShowDialog();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {

            if (label6.Visible)
                label6.Visible = false;

            if (!string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text) &&
                !string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox1.Text))
            {



                SqlCommand command = new SqlCommand("INSERT INTO [Rent] (Name, Products, Day)VALUES(@Name, @Products, @Day)", sqlConnection);

                command.Parameters.AddWithValue("Name", TextBox2.Text);
                command.Parameters.AddWithValue("Products", TextBox1.Text);
                command.Parameters.AddWithValue("Day", textBox3.Text);

                await command.ExecuteNonQueryAsync();

            }
            else 
            {
                label6.Visible = true;
                label6.Text = "Заповніть всі поля!!!";
            }






          //  Hide();
          //  Form2 fr2 = new Form2();
          //  fr2.ShowDialog();
        }
    }
}
