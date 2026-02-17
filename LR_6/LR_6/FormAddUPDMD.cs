using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LR_6.ModelEF;

namespace LR_6
{
    public partial class FormAddUPDMD : Form
    {
        public FormAddUPDMD()
        {
            InitializeComponent();
        }

        private string Pic_Name;
        private List<Table_Motorbike> vsMotorbike = FormShowMot.DB.Table_Motorbike.ToList();

        private void FormAddUPDMD_Load(object sender, EventArgs e)
        {
            List<string> dictBrand = new List<string>();
            foreach (Table_Motorbike TB in vsMotorbike)
                dictBrand.Add(TB.Brand);
            dictBrand = dictBrand.Distinct().ToList();
            comboBoxBrand.DataSource = dictBrand;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Файлы изображений (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png";
            DialogResult result = ofd.ShowDialog();
            if (DialogResult.OK == result)
            {
                Pic_Name = ofd.FileName;
                pictureBox1.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            FormShowMot form = new FormShowMot();
            form.Visible = true;
            this.Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(comboBoxBrand.Text) || String.IsNullOrEmpty(textBoxModel.Text))
            {
                MessageBox.Show("Заполните все поля Модель и Марка!");
                return;
            }

            try
            {
                Convert.ToInt32(textBoxMileage.Text);
                Convert.ToInt32(textBoxHP.Text);
            }
            catch
            {
                MessageBox.Show("В полях Л/С и Пробег, могут быть тольк целочисленные данные");
                return;
            }

            try
            {
                Convert.ToSingle(textBoxPrice.Text);
            }
            catch
            {
                MessageBox.Show("В поле Цена, могут быть только числа с плавующей точкой");
                return;
            }

            if (!File.Exists(Pic_Name))
            {
                MessageBox.Show("Невозможно найти файл!");
                return;
            }

            File.Copy(Pic_Name, $@"Pictures\{FLplus1()}{Path.GetExtension(Pic_Name)}");


            Table_Motorbike NMotorbike = new Table_Motorbike();

            NMotorbike.ID = FLplus1();
            NMotorbike.Brand = comboBoxBrand.Text;
            NMotorbike.Model = textBoxModel.Text;
            NMotorbike.Price = Convert.ToSingle(textBoxPrice.Text);
            NMotorbike.Horsepower = Convert.ToInt32(textBoxHP.Text);
            NMotorbike.Mileage = Convert.ToInt32(textBoxMileage.Text);
            NMotorbike.Picture = $@"{FLplus1()}{Path.GetExtension(Pic_Name)}";

            try
            {
                FormShowMot.DB.Table_Motorbike.Add(NMotorbike);
                FormShowMot.DB.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
                textBox.Text = null;
            comboBoxBrand.SelectedIndex = 0;
            pictureBox1.Image = null;
            Pic_Name = null;
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != ',')
                e.Handled = true;
        }

        private void textBoxHP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private void textBoxMileage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
                e.Handled = true;
        }

        private int FLplus1()
        {
            int maxId = FormShowMot.DB.Table_Motorbike.Max(x => (int?)x.ID) ?? 0;
            return maxId + 1;
        }
    }
}
