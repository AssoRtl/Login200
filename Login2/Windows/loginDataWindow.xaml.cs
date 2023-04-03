using Login2.DataBase;
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
using static Login2.ClassHelper.EFClass;

namespace Login2.Windows
{
    /// <summary>
    /// Логика взаимодействия для loginDataWindow.xaml
    /// </summary>
    public partial class loginDataWindow : Window
    {
        private int IdLogin=-1;
        public loginDataWindow()
        {
            InitializeComponent();
            LoginsGrid.ItemsSource = context.Login.ToList();
            List<string> sortList = new List<string>()
        { "По умолчанию","По роли"};
            CMBFilter.ItemsSource = sortList;
            CMBFilter.SelectedIndex = 0;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CMBFilter.SelectedIndex)
            {
                case 0:
                    LoginsGrid.ItemsSource = context.Login.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    LoginsGrid.ItemsSource = context.Login.OrderBy(i => i.IdRole).ToList();
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
            AddLoginWindow addLogin = new AddLoginWindow();
            addLogin.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IdLogin != -1)
            {

                try
                {

                    Login login = context.Login.First(i => i.ID.Equals(this.IdLogin));
                    context.Login.Remove(login);
                    context.SaveChanges();
                    LoginsGrid.ItemsSource = context.Login.ToList();
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.Write("");
                }

            }
        }

        private void btnCange_Click(object sender, RoutedEventArgs e)
        {

            if (IdLogin != -1)
            {
                ChangeLoginWindow changeLogin = new ChangeLoginWindow(IdLogin);
                changeLogin.Show();
                this.Close();
            }
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = LoginsGrid.Columns[0].GetCellContent(LoginsGrid.Items[LoginsGrid.SelectedIndex]) as TextBlock;
            IdLogin = Convert.ToInt32(x.Text);
        }
    }
}
