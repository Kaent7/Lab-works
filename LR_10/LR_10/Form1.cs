using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_10.FolderForModel;

namespace LR_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ModelEF model = new ModelEF();

        void StartLoad()
        {
            dataGridView1.DataSource = model.UsersHash.ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StartLoad();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" ||
                textBoxPass.Text == "" ||
                textBoxName.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }

            UsersHash usersHash = new UsersHash();
            usersHash.Login = textBoxLogin.Text;
            usersHash.Password = textBoxPass.Text;
            usersHash.FirstName = textBoxName.Text;
            try
            {
                model.UsersHash.Add(usersHash);
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLoad();
            }
            textBoxLogin.Text = "";
            textBoxPass.Text = "";
            textBoxName.Text = "";
            MessageBox.Show("Данные добавлены");
        }

        private void buttonAuth_Click(object sender, EventArgs e)
        {
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }
    }
}
