using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Экзамен
{
    public partial class Меню : Form
    {
        public Меню()
        {
            InitializeComponent();
            if(Авторизация.users.type == "admin")
            {
                buttonUser.Enabled = true;
            }

        }

        private void buttonManagers_Click(object sender, EventArgs e)
        {
            Менеджеры менеджеры = new Менеджеры();
            менеджеры.Show();
        }

        private void buttonКлиенты_Click(object sender, EventArgs e)
        {
            Физические_лица физические_Лица = new Физические_лица();
            физические_Лица.Show();
        }

        private void buttonLegalEntities_Click(object sender, EventArgs e)
        {
            ЮридическиеЛица юридическиеЛица = new ЮридическиеЛица();
            юридическиеЛица.Show();
        }
        private void buttonUser_Click(object sender, EventArgs e)
        {
            Пользователи пол = new Пользователи();
            пол.Show();
        }
        private void Меню_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
