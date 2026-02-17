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

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxHP_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxMileage_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
