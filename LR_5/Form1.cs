using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_5.FolderforModel;

namespace LR_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public static Model1 DB = new Model1();

        List<Motorbike> Motorbikes = DB.Motorbike.ToList();
        int AccNumber = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Loading();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loading(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loading(true);
        }

        private void Loading()
        {
            userControl11.Fill(Motorbikes[AccNumber]);
            userControl12.Fill(Motorbikes[AccNumber + 1]);
        }

        private void Loading(bool Incr)
        {
            if (Incr == true && Motorbikes.Count > AccNumber + 2)
                AccNumber++;
            else if (Incr == false && 0 <= AccNumber - 1)
                AccNumber--;
            else return;

            Loading();
        }
    }
}
