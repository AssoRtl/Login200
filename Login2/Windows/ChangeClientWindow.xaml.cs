using Login2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
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
    /// Логика взаимодействия для ChangeClientWindow.xaml
    /// </summary>
    public partial class ChangeClientWindow : Window
    {
        private int IdClient;
        public ChangeClientWindow(int IdClient)
        {
            InitializeComponent();
            CMBGender.ItemsSource = context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Name";
            this.IdClient = IdClient;


            TbFName.Text = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().FirstName;
            TbLName.Text = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().LastName;
            TbMName.Text = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().MidleName;
            TbPhone.Text = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().Phone;
            TbEmail.Text = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().Email;
            CMBGender.SelectedIndex = context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().IdGender;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().FirstName=TbFName.Text;
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().LastName=TbLName.Text;
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().MidleName=TbMName.Text;
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().Phone=TbPhone.Text;
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().Email=TbEmail.Text;
            context.Client.ToList().Where(i => i.ID == this.IdClient).FirstOrDefault().IdGender = (CMBGender.SelectedItem as Gender).ID;
                context.SaveChanges();

                ClientWindow client1 = new ClientWindow();
                client1.Show();
                this.Close();
            
        }
    }
}