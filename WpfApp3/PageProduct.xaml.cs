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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct 
    {
        public static decimal min;
        public PageProduct()
        {
            InitializeComponent();
            list.ItemsSource = Base.BD.Product.ToList();
            Sortirovka.SelectedIndex = 0;
            List<ProductType> products = Base.BD.ProductType.ToList();
            Filtra.Items.Add("Все");
            for (int i = 0; i < products.Count; i++)
            {
                Filtra.Items.Add(products[i].Title);
            }
            Filtra.SelectedIndex = 0;
           


        }

        void Filter()
        {
            List<Product> products6 = Base.BD.Product.ToList();
            List<Product> products = Base.BD.Product.ToList();
           

            //Поиск
            if (Poisk.Text.Length > 0)
            {
                List<Product> tempList = new List<Product>();

                for (int i = 0; i < products.Count; i++)
                {
                    bool already = true;

                    if (products[i].Title.ToLower().Contains(Poisk.Text.ToLower()))
                    {
                        tempList.Add(products[i]);
                        already = false;
                    }

                    if (products[i].Descriptoin !=null && products[i].Descriptoin.ToLower().Contains(Poisk.Text.ToLower()))
                    {
                        tempList.Add(products[i]);
                    }
                }

                products = tempList;
            }
            //фильтрация
            if (Filtra.SelectedIndex > 0)
            {
                products = products.Where(x => x.ProductTypeID == Filtra.SelectedIndex).ToList();

            }


            //switch (Sortirovka.SelectedIndex)
            //{

            //    case 0:
            //        products.Sort((x, y) => x.productionWorShopNumber.Compare(y.ProductionWorShopNumber));
            //        break;
            //    case 1:
            //        {
            //            products.Sort((x, y) => x.productionWorShopNumber.Compare(y.ProductionWorShopNumber));
            //            products.Reverse();
            //        }
            //        break;
            //}
            //list.ItemsSource = products;
            //if (products.Count > 0)
            //{
            //    kolvo.Text = Convert.ToString(products.Count) + "/" + Convert.ToString(products6.Count);
            //}
            //else
            //{
            //    MessageBox.Show("Данных нету");
            //    Poisk.Text = "";
            //}

        }

        private void proiz_Loaded(object sender, RoutedEventArgs e)
        {
            Filter();
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Sortirovka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }

        private void Filtra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void izmen_Click(object sender, RoutedEventArgs e)
        {

            FrameClass.frame.Navigate(new CreateProduct());
        }

        private void btnupdate_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;  // получаем доступ к Button из шаблона
            int index = Convert.ToInt32(btn.Uid);   // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            Product product = Base.BD.Product.FirstOrDefault(x => x.ID == index);
            
            FrameClass.frame.Navigate(new CreateProduct());


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;  // получаем доступ к Button из шаблона
            int index = Convert.ToInt32(btn.Uid);  // получаем числовой Uid элемента списка (в разметке предварительно нужно связать номер ячейки с номером кота в базе данных)

            // создаем объект, который содержит информацию о коте, который нужно удалить
            Product product = Base.BD.Product.FirstOrDefault(x => x.ID == index);
            Base.BD.Product.Remove(product);
            Base.BD.SaveChanges();
            FrameClass.frame.Navigate(new PageProduct());

        }
    }
}
