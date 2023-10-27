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
using System.Windows.Navigation;
using System.Windows.Shapes;

using WpfShopCSharp.db;

namespace WpfShopCSharp.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAutentification.xaml
    /// </summary>
    public partial class PageAutentification : Page
    {
        public PageAutentification()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user8 model = new user8();
                var obj = model.User.FirstOrDefault(x => x.UserLogin == tbLogin.Text && x.UserPassword == tbPassword.Text);
                if (obj != null)
                {
                    switch (obj.UserRole)
                    {
                        case 1:
                            MessageBox.Show("Вы входите как Менеджер", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageManager());
                            break;
                        case 2:
                            MessageBox.Show("Вы входите как Пользователь", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageUser());
                            break;
                        case 1002:
                            MessageBox.Show("Вы входите как Администратор", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                            NavigationService.Navigate(new PageAdmin());
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Ошибка введенных данных\nУказанный пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ошибка введенных данных\n" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
