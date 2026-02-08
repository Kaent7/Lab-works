using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Метод по надатию кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            //Переменные
            double a, b, c;
            string cStr;

            //Проверка правильности написания
            bool rez1 = double.TryParse(textBox1.Text, out a);
            //Вывод сообщения об оштбке и выход из метода
            if (rez1 == false)
            {
                MessageBox.Show($"Неверный формат числа: {textBox1.Text}!");
                return;
            }

            //Проверка правильности написания
            bool rez2 = double.TryParse(textBox2.Text, out b);
            //Вывод сообщения об оштбке и выход из метода
            if (rez2 == false)
            {
                MessageBox.Show($"Неверный формат числа: {textBox2.Text}!");
            }

            //Решение
            c = (7 * a + 3 * b) * 4.5;

            //Преоброзование в строку и вывод на форму
            cStr = c.ToString();
            label2.Text = cStr;
        }
    }
}
