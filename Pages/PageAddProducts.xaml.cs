﻿using System;
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
    /// Логика взаимодействия для PageAddProducts.xaml
    /// </summary>
    public partial class PageAddProducts : Page
    {
        user8 user8 = new user8();

        public PageAddProducts()
        {
            InitializeComponent();
            tbCat.SelectedValuePath = "CategoryID";
            tbCat.DisplayMemberPath = "CategoryName";
            tbCat.ItemsSource = user8.ProductCategory.ToList();

            tbUni.SelectedValuePath = "ProductUnitID";
            tbUni.DisplayMemberPath = "UnitName";
            tbUni.ItemsSource = user8.ProductUnit.ToList();

            tbMan.SelectedValuePath = "ManufacturerID";
            tbMan.DisplayMemberPath = "ManufacturerName";
            tbMan.ItemsSource = user8.ProductManufacturer.ToList();
        }

        private void tbGoBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tbAdd_Click(object sender, RoutedEventArgs e)
        {
           if(MessageBox.Show("Вы действительно желаете добавить этот продукт?", "Диалог", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Product product = new Product()
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

                    user8.Product.Add(product);
                    user8.SaveChanges();
                    MessageBox.Show("Добавлено ", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception exz)
                {
                    MessageBox.Show("" + exz, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
