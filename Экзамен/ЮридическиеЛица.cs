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
    public partial class ЮридическиеЛица : Form
    {
        public ЮридическиеЛица()
        {
            InitializeComponent();
            обновитьтаблицу();
            ОбновитьМенеджеров();
        }

        void обновитьтаблицу()
        {
            listView.Items.Clear();
            if (textBoxПоиск.Text == "")
                foreach (LegalEntities legalEntities in Program.база_данных.LegalEntities)
                {
                    ListViewItem item = new ListViewItem(new string[]
                    {
                        legalEntities.id.ToString(),
                        legalEntities.INN,
                        legalEntities.ShortName,
                        legalEntities.Address,
                        legalEntities.Email,
                        legalEntities.idManager.ToString()
                    });
                    item.Tag = legalEntities;
                    listView.Items.Add(item);
                }
            else
                foreach (LegalEntities legalEntities in Program.база_данных.LegalEntities)
                {
                    if (textBoxПоиск.Text == legalEntities.ShortName.ToString())
                    {
                        ListViewItem item = new ListViewItem(new string[]
                        {
                       legalEntities.id.ToString(),
                        legalEntities.INN,
                        legalEntities.ShortName,
                        legalEntities.Address,
                        legalEntities.Email,
                        legalEntities.idManager.ToString()
                        });
                        item.Tag = legalEntities;
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
                && textBoxShortName.Text != null
                && textBoxAddres.Text != null
                && textBoxEmail.Text != null
                && comboBoxidManager.SelectedItem.ToString() != null)
            {
                try
                {
                    LegalEntities legalEntities = new LegalEntities();
                    legalEntities.INN = textBoxINN.Text;
                    legalEntities.ShortName = textBoxShortName.Text;
                    legalEntities.Address = textBoxAddres.Text;
                    legalEntities.Email = textBoxEmail.Text;
                    legalEntities.idManager = Convert.ToInt32(comboBoxidManager.SelectedItem.ToString().Split('.')[1]);

                    Program.база_данных.LegalEntities.Add(legalEntities);
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
                    LegalEntities legalEntities = listView.SelectedItems[0].Tag as LegalEntities;

                    if (textBoxINN.Text != "")
                        legalEntities.INN = textBoxINN.Text;
                    if (textBoxShortName.Text != "")
                        legalEntities.ShortName = textBoxShortName.Text;
                    if (textBoxAddres.Text != "")
                        legalEntities.Address = textBoxAddres.Text;
                    if (textBoxEmail.Text != "")
                        legalEntities.Email = textBoxEmail.Text;
                    if (comboBoxidManager.SelectedItem.ToString().Split('.')[1] != "")
                        legalEntities.idManager = Convert.ToInt32(comboBoxidManager.SelectedItem.ToString().Split('.')[1]);
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
                    LegalEntities legalEntities = listView.SelectedItems[0].Tag as LegalEntities;

                    Program.база_данных.LegalEntities.Remove(legalEntities);

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
                LegalEntities legalEntities = listView.SelectedItems[0].Tag as LegalEntities;
                textBoxINN.Text = legalEntities.INN;
                textBoxShortName.Text = legalEntities.ShortName;
                textBoxAddres.Text = legalEntities.Address;
                textBoxEmail.Text = legalEntities.Email;
            }
            else
            {
                textBoxINN.Text = "";
                textBoxShortName.Text = "";
                textBoxAddres.Text = "";
                textBoxEmail.Text = "";
            }
        }
    }
}
