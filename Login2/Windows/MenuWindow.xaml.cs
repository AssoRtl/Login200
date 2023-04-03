using System;
using System.Collections.Generic;
using System.Linq;
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
using Login2.Windows;

namespace Login2
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        private void BtnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }

        private void BtnRoom_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow roomWindow = new RoomWindow();   
            roomWindow.Show();
            this.Close();
        }

        private void BtnClient_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow    clientWindow = new ClientWindow();  
            clientWindow.Show();
            this.Close();
        }

        private void BtnEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow  employeeWindow = new EmployeeWindow();  
            employeeWindow.Show();
            this.Close();
        }

        private void BtnAuth_Click(object sender, RoutedEventArgs e)
        {
            loginDataWindow loginDataWindow = new loginDataWindow();    
            loginDataWindow.Show();
            this.Close();
        }
    }
}
