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
    /// Логика взаимодействия для AddLoginWindow.xaml
    /// </summary>
    public partial class AddLoginWindow : Window
    {
        public AddLoginWindow()
        {
            InitializeComponent();
            CMBClient.ItemsSource = context.Client.ToList();
            CMBClient.DisplayMemberPath = "ID";

            CMBEmployee.ItemsSource = context.Employee.ToList();
            CMBEmployee.DisplayMemberPath = "ID";

            CMBRole.ItemsSource = context.Role.ToList();
            CMBRole.SelectedIndex= 0;
            CMBRole.DisplayMemberPath = "Name";

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            loginDataWindow loginDataWindow = new loginDataWindow();
            loginDataWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

           Login login = new Login();

            if (CMBClient.SelectedIndex!=-1&&CMBEmployee.SelectedIndex==-1)
            {
                login.idClient = (CMBClient.SelectedItem as Client).ID;
                
                login.IdRole = (CMBRole.SelectedItem as Role).ID;
                login.Login1 = TbLogin.Text;
                login.Password = TbPassword.Password;
                context.Login.Add(login);
                context.SaveChanges();
            }
            else if(CMBEmployee.SelectedIndex!=-1&&CMBClient.SelectedIndex==-1)
            {

                login.IdEmployee = (CMBEmployee.SelectedItem as Employee).ID;
                login.IdRole = (CMBRole.SelectedItem as Role).ID;
                login.Login1 = TbLogin.Text;
                login.Password = TbPassword.Password;
                context.Login.Add(login);
                context.SaveChanges();
            }



            

            loginDataWindow loginDataWindow = new loginDataWindow();
            loginDataWindow.Show();
            this.Close();

        }
    }
}
