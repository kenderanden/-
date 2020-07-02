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
    public partial class Авторизация : Form
    {
        public struct User
        {
            public string login;
            public string password;
            public string type;
        }
        public static User users = new User();
        public Авторизация()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxLogin.Text == "" || textBoxPass.Text == "")
                {
                    MessageBox.Show("Введите данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    foreach (Users user in Program.база_данных.Users)
                    {
                        if (textBoxLogin.Text == user.Login && user.Password == textBoxPass.Text)
                        {
                            users.login = user.Login;
                            users.password = user.Password;
                            users.type = user.Type;
                            break;
                        }
                    }
                    if (users.login == null && users.type != "Недоступен")
                    {
                        MessageBox.Show("Пользователь не найден или данные введены не верно", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (users.type == "Недоступен")
                    {
                        MessageBox.Show("Админ не подтвердил учётную запись", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Меню menu = new Меню();
                        menu.Show();
                        this.Hide();
                    }
                }
            }
            catch { }
        }

        private void linkLabelRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Регистрация рег = new Регистрация();
            рег.Show();
        }
    }
}
