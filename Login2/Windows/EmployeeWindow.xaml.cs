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
    /// Логика взаимодействия для EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public int IdEmployee = -1;
        
        public EmployeeWindow()
        {
            InitializeComponent();
            EmployeesGrid.ItemsSource = context.Employee.ToList();
            List<string> sortList = new List<string>()
        { "По умолчанию","По имени","По зарплате"};
            CMBFilter.ItemsSource = sortList;
            CMBFilter.SelectedIndex= 0;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CMBFilter.SelectedIndex)
            {
                case 0:
                    EmployeesGrid.ItemsSource = context.Employee.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    EmployeesGrid.ItemsSource = context.Employee.OrderBy(i => i.FirstName).ToList();
                    break;
                case 2:
                    EmployeesGrid.ItemsSource = context.Employee.OrderBy(i => i.Salary).ToList();
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
            AddEmployeeWindow addEmployee = new AddEmployeeWindow();
            addEmployee.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IdEmployee != -1)
            {

                try
                {

                    Employee employee = context.Employee.First(i => i.ID.Equals(this.IdEmployee));
                    context.Employee.Remove(employee);
                    context.SaveChanges();
                    EmployeesGrid.ItemsSource = context.Employee.ToList();
                }
                catch (ArgumentOutOfRangeException argumentOutOfRangeException)
                {
                    Console.Write("");
                }

            }
        }

        private void btnCange_Click(object sender, RoutedEventArgs e)
        {

            if (IdEmployee != -1)
            {
                ChangeEmployeeWindow changeEmployee = new ChangeEmployeeWindow(IdEmployee);
                changeEmployee.Show();
                this.Close();
            }
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = EmployeesGrid.Columns[0].GetCellContent(EmployeesGrid.Items[EmployeesGrid.SelectedIndex]) as TextBlock;
            IdEmployee = Convert.ToInt32(x.Text);
        }


    }


}
