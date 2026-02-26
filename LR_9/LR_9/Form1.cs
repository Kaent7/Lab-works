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

namespace LR_9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Form2AddData form2 = new Form2AddData();
            form2.Show();
            Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ModelDB model = new ModelDB();
            studentDataGridView.DataSource = model.Student.ToList();
        }
    }
}
