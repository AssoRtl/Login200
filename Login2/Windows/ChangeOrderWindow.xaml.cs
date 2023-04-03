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

namespace Login2.Windows
{
    /// <summary>
    /// Логика взаимодействия для ChangeOrderWindow.xaml
    /// </summary>
    public partial class ChangeOrderWindow : Window
    {
        private int IdOrder;
        public ChangeOrderWindow(int IdOrder)
        {
            InitializeComponent();
            CmbRoom.ItemsSource = context.Room.ToList();
            CmbRoom.SelectedIndex = 0;
            CmbRoom.DisplayMemberPath = "ID";
            CmbClient.ItemsSource = context.Client.ToList();
            CmbClient.SelectedIndex = 0;
            CmbClient.DisplayMemberPath = "ID";
            this.IdOrder = IdOrder;

            CmbRoom.SelectedIndex = context.RoomOrder.ToList().Where(i => i.Idorder == this.IdOrder).FirstOrDefault().IdRoom-1;
            StartDate.SelectedDate = context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().StartDate;
            EndDate.SelectedDate = context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().EndDate;
            TbPrice.Text = Convert.ToString(context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().Price);
            CmbClient.SelectedIndex = context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().IdClient-1;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Show();
            this.Close();
        }
        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
           
                Order order = new Order();
                order.ID = this.IdOrder;
            context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().Price= Convert.ToInt32(TbPrice.Text);
            context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().StartDate = StartDate.SelectedDate.Value;
            context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().EndDate= EndDate.SelectedDate.Value;
            context.Order.ToList().Where(i => i.ID == this.IdOrder).FirstOrDefault().IdClient= (CmbClient.SelectedItem as Client).ID;
            context.RoomOrder.ToList().Where(i => i.Idorder == this.IdOrder).FirstOrDefault().IdRoom = (CmbRoom.SelectedItem as Room).ID;

                context.SaveChanges();

               

                OrderWindow window = new OrderWindow();
                window.Show();
                this.Close();
           
        }
    }
}