using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LR_9.ModelEF;

namespace LR_9.ModelEF
{
    public partial class Form2AddData : Form
    {
        public Form2AddData()
        {
            InitializeComponent();
        }

        private void buttonSaveData_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(nameTextBox.Text)
            || String.IsNullOrWhiteSpace(groupTextBox.Text))
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Не задан файл с фотографией!");
                return;
            }

            ModelDB model = new ModelDB();
            Student student = new Student();
            student.Name = nameTextBox.Text;
            student.Group_ = groupTextBox.Text;
            byte[] bImg = (byte[])new ImageConverter().ConvertTo(pictureBox1.Image, typeof(byte[]));
            student.Photo = bImg;
            model.Student.Add(student);

            try
            {
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            MessageBox.Show("Сохранено");
            nameTextBox.Text = "";
            groupTextBox.Text = "";
            pictureBox1.Image = null;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Выберите фото сотрудника";
            ofd.Filter = "Файлы JPG, PNG|*.jpg;*.png|Все файлы (*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
                pictureBox1.Image = Image.FromFile(ofd.FileName);
        }
    }
}
