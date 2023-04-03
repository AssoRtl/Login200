using Login2.DataBase;
using Microsoft.Win32;
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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        private Login authorization;
        private RoomOrder orderRoomCheck;
        public AddOrderWindow()
        {
            InitializeComponent();
            CmbClient.ItemsSource = context.Client.ToList();
            CmbClient.SelectedIndex = 0;
            CmbClient.DisplayMemberPath = "ID";
            CmbRoom.ItemsSource = context.Room.ToList();
            CmbRoom.SelectedIndex = 0;
            CmbRoom.DisplayMemberPath = "ID";
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (StartDate.SelectedDate.Value < DateTime.Now)
            {
                MessageBox.Show("Дата начала брони не верна");
                return;
            }
            if (StartDate.SelectedDate.Value > EndDate.SelectedDate.Value)
            {
                MessageBox.Show("Дата окончания брони не верна");
                return;
            }
            


            else
            {
                Order order = new Order();
                order.OrderDate = DateTime.Now;
                order.IdClient = (CmbClient.SelectedItem as Client).ID;
                order.Price = Convert.ToInt32(TbPrice.Text);
                order.StartDate = StartDate.SelectedDate.Value;
                order.EndDate = EndDate.SelectedDate.Value;
                context.Order.Add(order);

                context.SaveChanges();

                RoomOrder orderRoom = new RoomOrder();
                orderRoom.Idorder = order.ID;
                orderRoom.IdRoom = (CmbRoom.SelectedItem as Room).ID;
                context.RoomOrder.Add(orderRoom);

                context.SaveChanges();

               OrderWindow window = new OrderWindow();
                window.Show();
                this.Close();
            }
        } 
    }
}