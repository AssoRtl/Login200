using Login2.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using Login2.Windows;


namespace Login2.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public int IdOrder = -1;
        public OrderWindow()
        {
            InitializeComponent();
            OrdersGrid.ItemsSource = context.Order.ToList();
            RoomOrderGrid.ItemsSource = context.RoomOrder.ToList();
            List<string> sortList = new List<string>()
        { "По умолчанию","По дате заказа","По цене"};
            CMBFilter.ItemsSource = sortList;
            CMBFilter.SelectedIndex = 0;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CMBFilter.SelectedIndex)
            {
                case 0:
                    OrdersGrid.ItemsSource = context.Order.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    OrdersGrid.ItemsSource = context.Order.OrderBy(i => i.OrderDate).ToList();
                    break;
                case 2:
                    OrdersGrid.ItemsSource = context.Order.OrderBy(i => i.Price).ToList();
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
            AddOrderWindow addOrder = new AddOrderWindow();
            addOrder.Show();
            this.Close();
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            if (IdOrder != -1)
            {
                Order order = context.Order.First(i => i.ID.Equals(this.IdOrder));
                RoomOrder orderRoom = context.RoomOrder.First(i => i.Idorder.Equals(this.IdOrder));
                context.Order.Remove(order);
                context.RoomOrder.Remove(orderRoom);
                context.SaveChanges();
                OrdersGrid.ItemsSource = context.Order.ToList();
            }
        }

        private void btnCange_Click(object sender, RoutedEventArgs e)
        {

            if (IdOrder != -1)
            {
                ChangeOrderWindow changeOrder = new ChangeOrderWindow(IdOrder);
                changeOrder.Show();
                this.Close();
            } 
        }
        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TextBlock x = OrdersGrid.Columns[0].GetCellContent(OrdersGrid.Items[OrdersGrid.SelectedIndex]) as TextBlock;
            IdOrder = Convert.ToInt32(x.Text);
        }


    }
}
