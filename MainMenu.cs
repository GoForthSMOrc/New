using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DIDSOMEONESAYYEP
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            get_Info(listView1);
        }

        void get_Info(ListView List)
        {
            listView1.Items.Clear();
            string query = "SELECT Emotes.Id_Emotes, Emotes.NameEmotes, Emotes.NameDate, Author.NameAuthor, Status.NameStatus FROM Emotes JOIN Author ON Emotes.id_Author = Author.Id_Author JOIN Status ON Emotes.id_Status = Status.Id_Status;";
            MySqlConnection conn = DBUtils.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query, conn);
            cmDB.CommandTimeout = 60;
            MySqlDataReader rd;
            try
            {
                conn.Open();
                rd = cmDB.ExecuteReader();
                if(rd.HasRows)
                {
                    while(rd.Read())
                    {
                        string[] row = { rd.GetString(0), rd.GetString(1), rd.GetString(2), rd.GetString(3), rd.GetString(4) };
                        var listViewItem = new ListViewItem(row);
                        listView1.Items.Add(listViewItem);
                    }
                }
                conn.Close();
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД");
                MessageBox.Show(ex.Message);
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            
        }
    }
}
