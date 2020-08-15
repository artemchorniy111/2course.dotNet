using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Application1
{
    public partial class Form2 : Form
    {
        SqlConnection sqlConnection;

        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Users\User\Desktop\politex\КУРСОВА\Programm_kyrsova\Application1\Application1\Database1.mdf;Integrated Security=True";

            sqlConnection = new SqlConnection(connectionString);

            //assing dlya norm robotu interfeisa;
            await sqlConnection.OpenAsync();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [University]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "        " + Convert.ToString(sqlReader["Name"]) + "        " + Convert.ToString(sqlReader["Number"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Hide();
            Form1 fr1 = new Form1();
            fr1.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
            Application.Exit();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            if (label7.Visible)
                label7.Visible = false;

            if (!string.IsNullOrEmpty(TextBox1.Text) && !string.IsNullOrWhiteSpace(TextBox1.Text) &&
                !string.IsNullOrEmpty(TextBox2.Text) && !string.IsNullOrWhiteSpace(TextBox2.Text))
            {

                SqlCommand command = new SqlCommand("INSERT INTO [University] (Name, Number)VALUES(@Name, @Number)", sqlConnection);

                command.Parameters.AddWithValue("Name", TextBox1.Text);
                command.Parameters.AddWithValue("Number", TextBox2.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label7.Visible = true;
                label7.Text = "Всі поля повинні бути заповнені!";
            }
        }

        private async void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ListBox1.Items.Clear();

            SqlDataReader sqlReader = null;

            SqlCommand command = new SqlCommand("SELECT * FROM [University]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();

                while (await sqlReader.ReadAsync())
                {
                    ListBox1.Items.Add(Convert.ToString(sqlReader["Id"]) + "        " + Convert.ToString(sqlReader["Name"]) + "        " + Convert.ToString(sqlReader["Number"]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null)
                    sqlReader.Close();
            }
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(TextBox5.Text) && !string.IsNullOrWhiteSpace(TextBox5.Text) &&
                !string.IsNullOrEmpty(TextBox3.Text) && !string.IsNullOrWhiteSpace(TextBox3.Text) &&
                !string.IsNullOrEmpty(TextBox4.Text) && !string.IsNullOrWhiteSpace(TextBox4.Text))
            {
                SqlCommand command = new SqlCommand("UPDATE [University] SET [Name]=@Name, [Number]=@Number WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", TextBox5.Text);
                command.Parameters.AddWithValue("Name", TextBox3.Text);
                command.Parameters.AddWithValue("Number", TextBox4.Text);

                await command.ExecuteNonQueryAsync();
            }
            else if (!string.IsNullOrEmpty(TextBox5.Text) && !string.IsNullOrWhiteSpace(TextBox5.Text))
            {
                label8.Visible = true;
                label8.Text = "Всі поля повинні бути заповнений!";
            }
            else
            {
                label8.Visible = true;
                label8.Text = "Всі поля повинні бути заповнені!";
            }
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            if (label8.Visible)
                label8.Visible = false;

            if (!string.IsNullOrEmpty(TextBox6.Text) && !string.IsNullOrWhiteSpace(TextBox6.Text))
            {
                SqlCommand command = new SqlCommand("DELETE FROM [University] WHERE [Id]=@Id", sqlConnection);

                command.Parameters.AddWithValue("Id", TextBox6.Text);

                await command.ExecuteNonQueryAsync();
            }
            else
            {
                label9.Visible = true;
                label9.Text = "Всі поля повинні бути заповнені!";
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Hide();
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hide();
            Form4 fr4 = new Form4();
            fr4.ShowDialog();
        }
    }
}
