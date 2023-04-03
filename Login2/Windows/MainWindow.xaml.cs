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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static Login2.ClassHelper.EFClass;

namespace Login2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string capchatext = "";
        public MainWindow()
        {
            InitializeComponent();

            
            string[] a = new string[5];
            int[] b = new int[5];
            Random rnd = new Random();
            for (int i = 0; i <5 ; i++) { 
            a[i] += (char)(rnd.Next(65, 122));
            b[i] += rnd.Next(10, 40);
            capchatext += a[i];
            }
            Capcha1.Text = a[0];
            Capcha1.FontSize = b[0];
            Capcha2.Text = a[1];
            Capcha2.FontSize = b[1];
            Capcha3.Text = a[2];
            Capcha3.FontSize = b[2];
            Capcha4.Text = a[3];
            Capcha4.FontSize = b[3];
            Capcha5.Text = a[4];
            Capcha5.FontSize = b[4];
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var authUser = context.Login.ToList().Where(i => i.Password == TbPassword.Password && i.Login1 == TbLogin.Text && TbCapcha.Text==capchatext).FirstOrDefault();
            if (authUser != null)
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("no");
            }
        }
    }
}
