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
    /// Логика взаимодействия для PageSeeProductsDataGread.xaml
    /// </summary>
    public partial class PageSeeProductsDataGread : Page
    {
        public PageSeeProductsDataGread()
        {
            InitializeComponent();
            user8 user8 = new user8();
            dgProducts.ItemsSource = user8.Product.ToList();
        }

        private void btGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
