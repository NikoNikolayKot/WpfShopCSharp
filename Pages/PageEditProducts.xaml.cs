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
    /// Логика взаимодействия для PageEditProducts.xaml
    /// </summary>
    public partial class PageEditProducts : Page
    {
        user8 user8 = new user8();
        int id = 0;

        public PageEditProducts(Product product)
        {
            InitializeComponent();

            tbArt.Text = product.ProductArticleNumber;

            tbCat.SelectedValuePath = "CategoryID";
            tbCat.DisplayMemberPath = "CategoryName";
            tbCat.ItemsSource = user8.ProductCategory.ToList();

            tbUni.SelectedValuePath = "ProductUnitID";
            tbUni.DisplayMemberPath = "UnitName";               //переделать на вывод из product
            tbUni.ItemsSource = user8.ProductUnit.ToList();

            tbMan.SelectedValuePath = "ManufacturerID";
            tbMan.DisplayMemberPath = "ManufacturerName";
            tbMan.ItemsSource = user8.ProductManufacturer.ToList();

            tbNam.Text = product.ProductName;
            tbText.Text = product.ProductDescription;
            tbCos.Text = product.ProductCost + "";
            tbDis.Text = product.ProductDiscountAmount + "";
            tbDisMax.Text = product.ProductDiscountAmountMax + "";
            tbQua.Text = product.ProductQuantityInStock + "";

            id = product.ProductID;
        }

        private void btnGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btOk_Click_1(object sender, RoutedEventArgs e)
        {
            Product product2 = new Product()
            {
                ProductArticleNumber = tbArt.Text,
                ProductCategory = tbCat.SelectedItem as ProductCategory,
                ProductUnit = tbUni.SelectedItem as ProductUnit,
                ProductManufacturer = tbMan.SelectedItem as ProductManufacturer,
                ProductName = tbNam.Text,
                ProductDescription = tbText.Text,
                ProductCost = Decimal.Parse(tbCos.Text),
                ProductDiscountAmount = Byte.Parse(tbDis.Text),
                ProductDiscountAmountMax = Byte.Parse(tbDisMax.Text),
                ProductQuantityInStock = int.Parse(tbQua.Text),
                ProductPhoto = null,
                ProductImageBitmap = null,
            };

            Product product3 = user8.Product.FirstOrDefault(x => x.ProductID == id);
            user8.Product.Remove(product3);

            user8.Product.Add(product2);

            user8.SaveChanges();
            MessageBox.Show("Отредактировано ", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
