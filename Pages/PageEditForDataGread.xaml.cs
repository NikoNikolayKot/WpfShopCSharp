using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для PageEditForDataGread.xaml
    /// </summary>
    public partial class PageEditForDataGread : Page
    {
        user8 user8 = new user8();
        public PageEditForDataGread(Product product)
        {
            InitializeComponent();
            try
            {
                dgProducts.ItemsSource = user8.Product.Where(x => x.ProductID == product.ProductID).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user8.SaveChanges();
                MessageBox.Show("Изменения сохранены");
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
