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
    /// Логика взаимодействия для AddEmployeeWindow.xaml
    /// </summary>
    public partial class AddEmployeeWindow : Window
    {
        public AddEmployeeWindow()
        {
            InitializeComponent();
            CMBGender.ItemsSource = context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Name";

        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            Employee employee = new Employee();
            employee.FirstName = TbFName.Text;
            employee.LastName = TbLName.Text;
            employee.MidleName = TbMName.Text;
            employee.IdGender = (CMBGender.SelectedItem as Gender).ID;
            employee.Phone = TbPhone.Text;
            employee.Salary=Convert.ToInt32(TbSalary.Text);
            employee.Passport = TbPassport.Text;

            context.Employee.Add(employee);
            context.SaveChanges();

            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();

        }
    }
}
