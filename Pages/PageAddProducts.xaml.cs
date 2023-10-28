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
                    Product product = new Product();
                    {
                        product.ProductArticleNumber = tbArt.Text;
                        product.ProductCategory = tbCat.Text;
                        product.ProductUnit = tbUni.Text;
                        product.ProductManufacturer = tbMan.Text;
                        product.ProductName = tbNam.Text;
                        product.ProductDescription = tbText.Text;
                        product.ProductCost = Decimal.Parse(tbCos.Text);
                        product.ProductDiscountAmount = Byte.Parse(tbDis.Text);
                        product.ProductDiscountAmountMax = Byte.Parse(tbDisMax.Text);
                        product.ProductQuantityInStock = int.Parse(tbQua.Text);
                        product.ProductPhoto = tbImg.Text;
                    }

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