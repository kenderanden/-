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
    public partial class Менеджеры : Form
    {
        public Менеджеры()
        {
            InitializeComponent();
            обновитьтаблицу();
        }
        void обновитьтаблицу()
        {
            listView.Items.Clear();
            if (textBoxПоиск.Text == "")
                foreach (Manager manager in Program.база_данных.Manager)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        manager.id.ToString(),
                        manager.Surname,
                        manager.Name,
                        manager.Patronymic,
                        manager.Email
                    });
                    item.Tag = manager;
                    listView.Items.Add(item);
                }
            else
                foreach (Manager manager in Program.база_данных.Manager)
                {
                    if (textBoxПоиск.Text == manager.Surname.ToString())
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                        manager.id.ToString(),
                        manager.Surname,
                        manager.Name,
                        manager.Patronymic,
                        manager.Email
                        });
                        item.Tag = manager;
                        listView.Items.Add(item);
                    }
                }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxSurname.Text != null && textBoxName.Text != null && textBoxPatronymic.Text != null && textBoxEmail.Text != null)
            {
                try
                {
                    Manager manager = new Manager();
                    manager.Surname = textBoxSurname.Text;
                    manager.Name = textBoxName.Text;
                    manager.Patronymic = textBoxPatronymic.Text;
                    manager.Email = textBoxEmail.Text;
                    Program.база_данных.Manager.Add(manager);
                    Program.база_данных.SaveChanges();
                    обновитьтаблицу();
                }
                catch 
                {
                    MessageBox.Show("Ошибка доступа", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else MessageBox.Show("Данные не выбраны", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    Manager manager = listView.SelectedItems[0].Tag as Manager;

                    if (textBoxSurname.Text != "")
                        manager.Surname = textBoxSurname.Text;
                    if (textBoxName.Text != "")
                        manager.Name = textBoxName.Text;
                    if (textBoxPatronymic.Text != "")
                        manager.Patronymic = textBoxPatronymic.Text;
                    if (textBoxEmail.Text != "")
                        manager.Email = textBoxEmail.Text;

                    Program.база_данных.SaveChanges();

                    обновитьтаблицу();
                }
            }
            catch 
            {
                MessageBox.Show("Ошибка доступа", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (listView.SelectedItems.Count == 1)
                {
                    Manager manager = listView.SelectedItems[0].Tag as Manager;

                    Program.база_данных.Manager.Remove(manager);

                    Program.база_данных.SaveChanges();

                    обновитьтаблицу();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка доступа", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Manager manager = listView.SelectedItems[0].Tag as Manager;

                textBoxSurname.Text =  manager.Surname;
                textBoxName.Text = manager.Name;
                textBoxPatronymic.Text = manager.Patronymic;
                textBoxEmail.Text = manager.Email;
            }
            else
            {
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
                textBoxEmail.Text = "";
            }
        }

        private void buttonПоиск_Click(object sender, EventArgs e)
        {
            обновитьтаблицу();
        }
    }
}
