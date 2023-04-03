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
    /// Логика взаимодействия для ChangeEmployeeWindow.xaml
    /// </summary>
    public partial class ChangeEmployeeWindow : Window
    {
        private int IdEmployee;
        public ChangeEmployeeWindow(int IdEmployee)
        {
            InitializeComponent();
            CMBGender.ItemsSource = context.Gender.ToList();
            CMBGender.SelectedIndex = 0;
            CMBGender.DisplayMemberPath = "Name";
            this.IdEmployee = IdEmployee;

             
                        TbFName.Text = context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().FirstName;
                        TbLName.Text = context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().LastName;
                        TbMName.Text = context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().MidleName;
                        TbPhone.Text = context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().Phone;
                       TbSalary.Text = Convert.ToString(context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().Salary);
             CMBGender.SelectedIndex = context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().IdGender;
                      TbPassport.Text= context.Employee.ToList().Where(i=>i.ID==this.IdEmployee).FirstOrDefault().Passport;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {

            
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().FirstName = TbFName.Text;
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().LastName = TbLName.Text;
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().MidleName = TbMName.Text;
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().Phone = TbPhone.Text;
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().Salary = Convert.ToInt32(TbSalary.Text);
            context.Employee.ToList().Where(i => i.ID == this.IdEmployee).FirstOrDefault().IdGender = (CMBGender.SelectedItem as Gender).ID;
            context.Employee.ToList().Where((i) => i.ID == this.IdEmployee).FirstOrDefault().Passport= TbPassport.Text;
            
            
            context.SaveChanges();
            EmployeeWindow employeeWindow = new EmployeeWindow();
            employeeWindow.Show();
            this.Close();

        }
    }
}