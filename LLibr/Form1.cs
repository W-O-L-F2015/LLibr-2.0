using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Media;

namespace LLibr
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlConnection = null;
        public Form1()
        {

            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            SqlCommand command = new SqlCommand($"INSERT INTO [Books] (Name, Author, Publishing, Year, Place, Style, Serial, Rating, Pages, Circulation, Description, Cost, Binding, Format, Status, Image) VALUES (N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox3.Text}', N'{Convert.ToInt32(textBox4.Text)}', N'{textBox5.Text}', N'{textBox6.Text}', N'{textBox7.Text}', N'{Convert.ToByte(comboBox1.Text)}', N'{Convert.ToInt32(textBox9.Text)}', N'{Convert.ToInt32(textBox10.Text)}', N'{textBox15.Text}', N'{textBox11.Text}', N'{comboBox2.Text}', N'{textBox13.Text}', N'{comboBox3.Text}', '{pictureBox1.Image}')");
            command.Connection = sqlConnection;
            pictureBox1.Image.Save(textBox1.Text + ".png");
            MessageBox.Show(command.ExecuteNonQuery().ToString());


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dBlibrDataSet.Books". При необходимости она может быть перемещена или удалена.
            this.booksTableAdapter.Fill(this.dBlibrDataSet.Books);
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["Key"].ConnectionString);
            
            sqlConnection.Open();

            if (sqlConnection.State == ConnectionState.Open)
            {
                MessageBox.Show("база данных подключена");

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog pic = new OpenFileDialog();
            pic.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG";

            if (pic.ShowDialog() == DialogResult.OK) //если в окне была нажата кнопка "ОК"
            {
                try
                {
                    pictureBox1.Image = new Bitmap(pic.FileName);
                    //вместо pictureBox1 укажите pictureBox, в который нужно загрузить изображение 

                    pictureBox1.Image = pictureBox1.Image;
                    pictureBox1.Invalidate();
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }



            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
       


            int index = dataGridView1.CurrentRow.Index;
            MessageBox.Show(Convert.ToString (index));
            
            label16.Text = dataGridView1.Rows[index].Cells[1].Value.ToString();
            richTextBox1.Text = dataGridView1.Rows[index].Cells[11].Value.ToString();
            
            System.IO.FileStream fs = new System.IO.FileStream((label16.Text + ".png"), System.IO.FileMode.Open);
            System.Drawing.Image img = System.Drawing.Image.FromStream(fs);
            fs.Close();
            pictureBox2.Image = img;







        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
