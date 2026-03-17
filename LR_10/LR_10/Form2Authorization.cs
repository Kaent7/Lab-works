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

namespace LR_10.FolderForModel
{
    public partial class Form2Authorization : Form
    {
        public Form2Authorization()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            ModelEF model = new ModelEF();
            if (model.UsersHash.ToList().Any(x =>
            x.Login == textBoxLogin.Text &&
            x.Password == SHA256Builder.ConvertToHash(textBoxPass.Text)))
            {
                MessageBox.Show("Пользователь найден!");
                return;
            }
            MessageBox.Show("Пользователь не найден!");
        }
    }
}
