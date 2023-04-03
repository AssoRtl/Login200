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
    /// Логика взаимодействия для ChangeLoginWindow.xaml
    /// </summary>
    public partial class ChangeLoginWindow : Window
    {
        private int IdLogin;
        public ChangeLoginWindow(int IdLogin)
        {
            InitializeComponent();
            CMBClient.ItemsSource = context.Client.ToList();
            CMBClient.DisplayMemberPath = "ID";

            CMBEmployee.ItemsSource = context.Employee.ToList();
            CMBEmployee.DisplayMemberPath = "ID";

            CMBRole.ItemsSource = context.Role.ToList();
            CMBRole.DisplayMemberPath = "Name";
            this.IdLogin = IdLogin;


            if (context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().IdEmployee.HasValue)
            {
                TbLogin.Text = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Login1;
                TbPassword.Password = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Password;
                
                CMBEmployee.SelectedIndex = (int)context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().IdEmployee-1;
                CMBRole.SelectedIndex = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().IdRole-1;
            }
            else
            {
                CMBClient.SelectedIndex = (int)context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().idClient-1;
                TbLogin.Text = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Login1;
                TbPassword.Password = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Password;
                CMBRole.SelectedIndex = context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().IdRole - 1;
            }

                   
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            loginDataWindow loginData = new loginDataWindow();
            loginData.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Login1 = TbLogin.Text;
            context.Login.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().Password = TbPassword.Password;
            context.Client.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().ID = CMBClient.SelectedIndex;
            context.Employee.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().ID = CMBEmployee.SelectedIndex;
            context.Role.ToList().Where(i => i.ID == this.IdLogin).FirstOrDefault().ID = CMBRole.SelectedIndex;


            context.SaveChanges();
            loginDataWindow loginData = new loginDataWindow();
            loginData.Show();
            this.Close();

        }
    }
}