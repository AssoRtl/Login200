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
    /// Логика взаимодействия для RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        public RoomWindow()
        {
            InitializeComponent();
            RoomsGrid.ItemsSource = context.Room.ToList();
            List<string> sortList = new List<string>()
        { "По умолчанию","По типу комнаты" };
            CMBFilter.ItemsSource = sortList;
            CMBFilter.SelectedIndex = 0;
        }

        private void CmbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (CMBFilter.SelectedIndex)
            {
                case 0:
                    RoomsGrid.ItemsSource = context.Room.OrderBy(i => i.ID).ToList();
                    break;
                case 1:
                    RoomsGrid.ItemsSource = context.Room.OrderBy(i => i.IdTypeOfRoom).ToList();
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
    }
}
