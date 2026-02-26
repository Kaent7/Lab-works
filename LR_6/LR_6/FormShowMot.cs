using LR_6.ModelEF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_6
{
    public partial class FormShowMot : Form
    {
        public FormShowMot()
        {
            InitializeComponent();
        }

        public static ModelDB DB = new ModelDB();

        private void FormShowMot_Load(object sender, EventArgs e)
        {
            tableMotorbikeBindingSource.DataSource = DB.Table_Motorbike.ToList();

            if (DB.Table_Motorbike.ToList().Count == 0) return;
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            pictureBox1.Image = Image.FromFile($@"Pictures\{DB.Table_Motorbike.Find(ID).Picture}");
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAddUPDMD form = new FormAddUPDMD();
            this.Visible = false;
            form.Show();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (DB.Table_Motorbike.ToList().Count == 0)
            {
                MessageBox.Show("Данные отсутствуют!");
                return;
            }

            Table_Motorbike CurrentMoto = DB.Table_Motorbike.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show(
                $@"Вы действиетльно хотите удалить объект с ID: {CurrentMoto.ID}",
                "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DB.Table_Motorbike.Remove(CurrentMoto);
                    DB.SaveChanges();
                    File.Delete($@"Pictures\{CurrentMoto.Picture}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    tableMotorbikeBindingSource.DataSource = DB.Table_Motorbike.ToList();
                    pictureBox1.Image = null;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DB.Table_Motorbike.ToList().Count == 0) return;
            int ID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            pictureBox1.Image = Image.FromFile($@"Pictures\{DB.Table_Motorbike.Find(ID).Picture}");
        }
    }
}
