using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_4
{
    public partial class Form1 : Form
    {
        // Переменные
        private double a, b;
        private string bStr;


        public Form1()
        {
            InitializeComponent();
        }

        // При изменении поля ввода
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool rez = double.TryParse(textBox1.Text, out a);
            if (rez == false)
            {
                label2.Text = "Неверный формат";
            }
            else
            {
                label2.Text = "";
                Answear();
            }
        }

        // При изменении элемента листа
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Answear();
        }

        // Метод вычисления финкций
        private void Answear()
        {
            if (listBox1.SelectedIndex == 0)
                b = Math.Tan(a);

            else if (listBox1.SelectedIndex == 1)
                b = Math.Sin(a);

            else if(listBox1.SelectedIndex == 2)
                b = Math.Log(a);

            bStr = b.ToString();
            textBox2.Text = bStr;
        }
    }
}
