using Login2.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Login2.ClassHelper.EFClass;

namespace Login2.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public int IdClient = -1;
        public ClientWindow()
        {
            InitializeComponent();
            ClientsGrid.ItemsSource = context.Client.ToList();

            List<string> sortList = new List<string>()
        { "По умолчанию","По имени","По телефону" };
            CMBFilter.ItemsSource = sortList;
            CMBFilter.SelectedIndex = 0;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CMBFilter.SelectedIndex)
            {
                case 0:
                    ClientsGrid.ItemsSource = context.Client.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    ClientsGrid.ItemsSource = context.Client.OrderBy(i => i.FirstName).ToList();
                    break;
                case 2:
                    ClientsGrid.ItemsSource = context.Client.OrderBy(i => i.Phone).ToList();
                    break;

                default:
                    break;
            }
        }
       

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientWindow addClient = new AddClientWindow();
            addClient.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IdClient != -1)
            {
                
                try
                {

                    Client client = context.Client.First(i => i.ID.Equals(this.IdClient));
                    context.Client.Remove(client);
                    context.SaveChanges();
                    ClientsGrid.ItemsSource = context.Client.ToList();
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.Write("");
                }

            }
        }

        private void btnCange_Click(object sender, RoutedEventArgs e)
        {

            if (IdClient != -1)
            {
                ChangeClientWindow changeClient = new ChangeClientWindow(IdClient);
                changeClient.Show();
                this.Close();
            }
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = ClientsGrid.Columns[0].GetCellContent(ClientsGrid.Items[ClientsGrid.SelectedIndex]) as TextBlock;
            IdClient = Convert.ToInt32(x.Text);
        }


    }


}

