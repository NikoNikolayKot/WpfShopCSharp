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
    /// Логика взаимодействия для PageSeeProductsUser.xaml
    /// </summary>
    public partial class PageSeeProductsUser : Page
    {
        user8 user8 = new user8();

        public PageSeeProductsUser()
        {
            InitializeComponent();
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void cbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectIndex = cbFilt.SelectedIndex;
            Product product = new Product();

            try
            {
                switch (selectIndex)
                {
                    case 0:
                        ListProducts.ItemsSource = user8.Product.Where(x => x.ProductCost > 2500).ToList();
                        ListProducts.SelectedIndex = 0;
                        break;
                    case 1:
                        ListProducts.ItemsSource = user8.Product.ToList();
                        ListProducts.SelectedIndex = 0;
                        break;
                    case 2:
                        ListProducts.ItemsSource = user8.Product.Where(x => x.ProductCost > 0 && x.ProductCost < 1000).ToList();
                        ListProducts.SelectedIndex = 0;
                        break;
                }
            }
            catch (Exception ex)
            {
                MyExceptionHelper(ex);
            }
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectIndex = cbSort.SelectedIndex;

            try
            {
                switch (selectIndex)
                {
                    case 0:
                        ListProducts.ItemsSource = user8.Product.OrderBy(x => x.ProductCost).ToList();
                        break;
                    case 1:
                        ListProducts.ItemsSource = user8.Product.ToList();
                        break;
                    case 2:
                        ListProducts.ItemsSource = user8.Product.OrderByDescending(x => x.ProductCost).ToList();
                        break;
                }
            }
            catch (Exception ex)
            {
                MyExceptionHelper(ex);
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                ListProducts.ItemsSource = user8.Product.Where(x => x.ProductName.Contains(tbSearch.Text)).ToList();
            }
            catch (Exception ex)
            {
                MyExceptionHelper(ex);
            }
        }

        public void MyExceptionHelper(Exception ex)
        {
            MessageBox.Show("" + ex, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
