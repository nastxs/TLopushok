using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLopushok
{
    public partial class Form1 : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("server=localhost; Port=5432; User ID=postgres; Password=postgres; Database=TBLopushok");
        NpgsqlDataReader reader;
        public Form1()
        {
            InitializeComponent();
            FillMainPanel();

            comboBox2.Items.Add("Набор");
            comboBox2.Items.Add("Бумага");
            comboBox2.Items.Add("Полотенце");
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Наименование";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ComboFilter();
        }

        private void ComboFilter()
        {
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from type";
            List<Type> types = new List<Type>();
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Type tp = new Type()
                    {
                        ID = int.Parse(reader["ID"].ToString()),
                        name = reader["Name"].ToString()
                    };
                    types.Add(tp);
                }



            }
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "ID";
            comboBox1.DataSource = types;
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Тип продукции";
            conn.Close();

        }

        private void FillMainPanel()
        {
            string querystr = "select * from myproduct";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(querystr, conn);
            cmd.Connection = conn;
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Panel ProductPanel = new Panel();
                ProductPanel.Name = reader.GetValue(0).ToString();
                ProductPanel.Size = new Size(588, 128);
                ProductPanel.BackColor = Color.Aquamarine;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(12, 12);
                picture.Size = new Size(165, 102);
                string path = "C:\\Users\\qwe\\Desktop\\TBLopushok\\TBLopushok\\Images\\" + reader["image"].ToString();
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                picture.Image = bmp;
                ProductPanel.Controls.Add(picture);


                Label namelab = new Label();
                namelab.Name = reader["name"].ToString();
                namelab.Size = new Size(268, 85);
                namelab.Location = new Point(192, 10);
                namelab.Font = new Font("Gabriola", 12);
                namelab.Text = $"{reader["type"]}" +
                               $" | {reader["name"]}\n" +
                               $"Артикул: {reader["articul"]}\n" +
                               $"Материалы: {reader["material"]}";
                ProductPanel.Controls.Add(namelab);

                Label pricelab = new Label();
                pricelab.Name = reader["price"].ToString();
                pricelab.Size = new Size(60, 85);
                pricelab.Location = new Point(530, 20);
                pricelab.Font = new Font("Gabriola", 12);
                pricelab.Text = $"{reader["price"]} руб.";
                ProductPanel.Controls.Add(pricelab);

                flowLayoutPanel1.Controls.Add(ProductPanel);


            }
            reader.Close();
            cmd.Cancel();
            conn.Close();
        }

        private void GetSearchData()
        {
            flowLayoutPanel1.Controls.Clear();
            string querystr = "select * from myproduct where name like '%" + textBox1.Text.ToString() + "%'";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(querystr, conn);
            cmd.Connection = conn;
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Panel ProductPanel = new Panel();
                ProductPanel.Name = reader.GetValue(0).ToString();
                ProductPanel.Size = new Size(588, 128);
                ProductPanel.BackColor = Color.Aquamarine;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(12, 12);
                picture.Size = new Size(165, 102);
                string path = "C:\\Users\\qwe\\Desktop\\TBLopushok\\TBLopushok\\Images\\" + reader["image"].ToString();
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                picture.Image = bmp;
                ProductPanel.Controls.Add(picture);


                Label namelab = new Label();
                namelab.Name = reader["name"].ToString();
                namelab.Size = new Size(268, 85);
                namelab.Location = new Point(192, 10);
                namelab.Font = new Font("Gabriola", 12);
                namelab.Text = $"{reader["type"]}" +
                               $" | {reader["name"]}\n" +
                               $"Артикул: {reader["articul"]}\n" +
                               $"Материалы: {reader["material"]}";
                ProductPanel.Controls.Add(namelab);

                Label pricelab = new Label();
                pricelab.Name = reader["price"].ToString();
                pricelab.Size = new Size(60, 85);
                pricelab.Location = new Point(530, 20);
                pricelab.Font = new Font("Gabriola", 12);
                pricelab.Text = $"{reader["price"]} руб.";
                ProductPanel.Controls.Add(pricelab);

                flowLayoutPanel1.Controls.Add(ProductPanel);


            }
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Наименование";
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "Тип продукции";
            reader.Close();
            cmd.Cancel();
            conn.Close();
        }

        private void GetComboFilterData()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; Port=5432; User ID=postgres; Password=postgres; Database=TBLopushok");
            flowLayoutPanel1.Controls.Clear();
            string querystr = "select * from myproduct where type like '" + comboBox1.Text.ToString() + "%'";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(querystr, conn);
            cmd.Connection = conn;
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Panel ProductPanel = new Panel();
                ProductPanel.Name = reader.GetValue(0).ToString();
                ProductPanel.Size = new Size(588, 128);
                ProductPanel.BackColor = Color.Aquamarine;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(12, 12);
                picture.Size = new Size(165, 102);
                string path = "C:\\Users\\qwe\\Desktop\\TBLopushok\\TBLopushok\\Images\\" + reader["image"].ToString();
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                picture.Image = bmp;
                ProductPanel.Controls.Add(picture);


                Label namelab = new Label();
                namelab.Name = reader["name"].ToString();
                namelab.Size = new Size(268, 85);
                namelab.Location = new Point(192, 10);
                namelab.Font = new Font("Gabriola", 12);
                namelab.Text = $"{reader["type"]}" +
                               $" | {reader["name"]}\n" +
                               $"Артикул: {reader["articul"]}\n" +
                               $"Материалы: {reader["material"]}";
                ProductPanel.Controls.Add(namelab);

                Label pricelab = new Label();
                pricelab.Name = reader["price"].ToString();
                pricelab.Size = new Size(60, 85);
                pricelab.Location = new Point(530, 20);
                pricelab.Font = new Font("Gabriola", 12);
                pricelab.Text = $"{reader["price"]} руб.";
                ProductPanel.Controls.Add(pricelab);

                flowLayoutPanel1.Controls.Add(ProductPanel);


            }
            comboBox2.SelectedIndex = -1;
            comboBox2.Text = "Наименование";
            comboBox1.Text = "Тип продукции";
            reader.Close();
            cmd.Cancel();
            conn.Close();
        }

        private void GetComboSortData()
        {
            NpgsqlConnection conn = new NpgsqlConnection("server=localhost; Port=5432; User ID=postgres; Password=postgres; Database=TBLopushok");
            flowLayoutPanel1.Controls.Clear();
            string querystr = "select * from myproduct where name like '" + comboBox2.Text.ToString() + "%'";
            conn.Open();
            NpgsqlCommand cmd = new NpgsqlCommand(querystr, conn);
            cmd.Connection = conn;
            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Panel ProductPanel = new Panel();
                ProductPanel.Name = reader.GetValue(0).ToString();
                ProductPanel.Size = new Size(588, 128);
                ProductPanel.BackColor = Color.Aquamarine;

                PictureBox picture = new PictureBox();
                picture.Location = new Point(12, 12);
                picture.Size = new Size(165, 102);
                string path = "C:\\Users\\qwe\\Desktop\\TBLopushok\\TBLopushok\\Images\\" + reader["image"].ToString();
                Bitmap bmp = (Bitmap)Image.FromFile(path);
                picture.Image = bmp;
                ProductPanel.Controls.Add(picture);


                Label namelab = new Label();
                namelab.Name = reader["name"].ToString();
                namelab.Size = new Size(268, 85);
                namelab.Location = new Point(192, 10);
                namelab.Font = new Font("Gabriola", 12);
                namelab.Text = $"{reader["type"]}" +
                               $" | {reader["name"]}\n" +
                               $"Артикул: {reader["articul"]}\n" +
                               $"Материалы: {reader["material"]}";
                ProductPanel.Controls.Add(namelab);

                Label pricelab = new Label();
                pricelab.Name = reader["price"].ToString();
                pricelab.Size = new Size(60, 85);
                pricelab.Location = new Point(530, 20);
                pricelab.Font = new Font("Gabriola", 12);
                pricelab.Text = $"{reader["price"]} руб.";
                ProductPanel.Controls.Add(pricelab);

                flowLayoutPanel1.Controls.Add(ProductPanel);


            }
            comboBox1.SelectedIndex = -1;
            comboBox2.Text = "Наименование";
            comboBox1.Text = "Тип продукции";
            reader.Close();
            cmd.Cancel();
            conn.Close();
        }

        
        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            GetSearchData();
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetComboFilterData();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            GetComboSortData();
        }
    }
}
