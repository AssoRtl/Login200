using Login2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
            CMBGender.ItemsSource = context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Name";
            
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
          
                Client client = new Client();
            client.FirstName = TbFName.Text;
            client.LastName = TbLName.Text;
            client.MidleName = TbMName.Text;
            client.IdGender = (CMBGender.SelectedItem as Gender).ID;
            client.Phone= TbPhone.Text;
            client.Email= TbEmail.Text;

                context.Client.Add(client);
                context.SaveChanges();
                ClientWindow client1 = new ClientWindow();
                client1.Show();
                this.Close();
            
        }
    }
}