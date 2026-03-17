using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_11.FolderForModel;

namespace LR_11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (new ModelEF().Users.Any(x =>
            x.Login == textBoxLogin.Text &&
            x.Password == textBoxPass.Text))
            {
                MessageBox.Show("Пользователь найден!");
                return;
            }
            MessageBox.Show("Пользователь не найден, пройдите проверку Captcha!");
            new CaptchForm().ShowDialog();
        }
    }
}
