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
    public partial class Физические_лица : Form
    {
        public Физические_лица()
        {
            InitializeComponent();
            обновитьтаблицу();
            ОбновитьМенеджеров();
        }



        void обновитьтаблицу()
        {
            listView.Items.Clear();
            if (textBoxПоиск.Text == "")
                foreach (Individuals individuals in Program.база_данных.Individuals)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        individuals.id.ToString(),
                        individuals.INN,
                        individuals.Surname,
                        individuals.Name,
                        individuals.Patronymic,
                        individuals.Gender,
                        individuals.Email,
                        individuals.idManager.ToString()
                    });
                    item.Tag = individuals;
                    listView.Items.Add(item);
                }
            else
                foreach (Individuals individuals in Program.база_данных.Individuals)
                {
                    if (textBoxПоиск.Text == individuals.Surname.ToString())
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                            individuals.id.ToString(),
                        individuals.INN,
                        individuals.Surname,
                        individuals.Name,
                        individuals.Patronymic,
                        individuals.Gender,
                        individuals.Email,
                        individuals.idManager.ToString()
                        });
                        item.Tag = individuals;
                        listView.Items.Add(item);
                    }
                }
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        void ОбновитьМенеджеров()
        {
            comboBoxidManager.Items.Clear();
            foreach (Manager manager in Program.база_данных.Manager)
            {
                string[] item = { 
                    "id." + manager.id.ToString()
                    + ". " + manager.Surname
                    + " " + manager.Name
                    + " " + manager.Patronymic
                };
                comboBoxidManager.Items.Add(string.Join(" ", item));
            }
        }



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (textBoxINN.Text != null 
                && textBoxSurname.Text != null 
                && textBoxName.Text != null 
                && textBoxPatronymic.Text != null)
            {
                try
                {
                    Individuals individuals = new Individuals();
                    individuals.INN = textBoxINN.Text;
                    individuals.Surname = textBoxSurname.Text;
                    individuals.Name = textBoxName.Text;
                    individuals.Patronymic = textBoxPatronymic.Text;
                    individuals.Gender = comboBoxGender.SelectedItem.ToString();
                    individuals.Email = textBoxEmail.Text;
                    individuals.idManager = Convert.ToInt32(comboBoxidManager.SelectedItem.ToString().Split('.')[1]);

                    Program.база_данных.Individuals.Add(individuals);
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
                    Individuals individuals = listView.SelectedItems[0].Tag as Individuals;

                    if (textBoxINN.Text != "")
                        individuals.INN = textBoxINN.Text;
                    if (textBoxSurname.Text != "")
                        individuals.Surname = textBoxSurname.Text;
                    if (textBoxName.Text != "")
                        individuals.Name = textBoxName.Text;
                    if (textBoxPatronymic.Text != "")
                        individuals.Patronymic = textBoxPatronymic.Text;
                    if (comboBoxGender.SelectedItem.ToString() != "")
                        individuals.Gender = comboBoxGender.SelectedItem.ToString();
                    if (textBoxEmail.Text != "")
                        individuals.Email = textBoxEmail.Text;
                    if (comboBoxidManager.SelectedItem.ToString().Split('.')[1] != "")
                        individuals.idManager = Convert.ToInt32(comboBoxidManager.SelectedItem.ToString().Split('.')[1]);
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
                    Individuals individuals = listView.SelectedItems[0].Tag as Individuals;

                    Program.база_данных.Individuals.Remove(individuals);

                    Program.база_данных.SaveChanges();

                    обновитьтаблицу();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка доступа", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonПоиск_Click(object sender, EventArgs e)
        {
            обновитьтаблицу();
            ОбновитьМенеджеров();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedItems.Count == 1)
            {
                Individuals individuals = listView.SelectedItems[0].Tag as Individuals;
                textBoxINN.Text = individuals.INN;
                textBoxSurname.Text = individuals.Surname;
                textBoxName.Text = individuals.Name;
                textBoxPatronymic.Text = individuals.Patronymic;
                comboBoxGender.SelectedItem = individuals.Gender;
                textBoxEmail.Text = individuals.Email;
            }
            else
            {
                textBoxINN.Text = "";
                textBoxSurname.Text = "";
                textBoxName.Text = "";
                textBoxPatronymic.Text = "";
                comboBoxGender.SelectedItem = "";
                textBoxEmail.Text = "";
            }
        }
    }
}
