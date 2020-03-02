using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Ver3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // public static DataTable listall[3] = new DataTable();
        //public static DataTable listall[0] = new DataTable();
        //public static DataTable listall[1] = new DataTable();
        //public static DataTable listall[2] = new DataTable();
        public static List<DataTable> listall = new List<DataTable>()
        {
            new DataTable(), new DataTable(), new DataTable(),
            new DataTable(), new DataTable(), new DataTable(),
            new DataTable()
        };

        Add add = new Add();
        public static int _page = 0;
        static int _pageC = 0, _pageM = 0;


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            listall[0].Prefix = "Jk";
            listall[1].Prefix = "houses_in_complexes";
            listall[2].Prefix = "apartments_in_houses";

            listall[3].Columns.Add(new DataColumn("№", System.Type.GetType("System.Int32")));
            listall[3].Columns.Add(new DataColumn("Название ЖК"));
            listall[3].Columns.Add(new DataColumn("Статус"));
            listall[3].Columns.Add(new DataColumn("Количество домов в ЖК", System.Type.GetType("System.Int32")));
            listall[3].Columns.Add(new DataColumn("Город, в котором находится ЖК"));

            listall[4].Columns.Add(new DataColumn("№", System.Type.GetType("System.Int32")));
            listall[4].Columns.Add(new DataColumn("Название ЖК"));
            listall[4].Columns.Add(new DataColumn("Улица"));
            listall[4].Columns.Add(new DataColumn("№ Дома"));
            listall[4].Columns.Add(new DataColumn("Статус"));
            listall[4].Columns.Add(new DataColumn("Количество проданных квартир", System.Type.GetType("System.Int32")));
            listall[4].Columns.Add(new DataColumn("Количество продающихся квартир", System.Type.GetType("System.Int32")));

            listall[5].Columns.Add(new DataColumn("№", System.Type.GetType("System.Int32")));
            listall[5].Columns.Add(new DataColumn("Название ЖК"));
            listall[5].Columns.Add(new DataColumn("Адрес"));
            listall[5].Columns.Add(new DataColumn("Площадь квартиры"));
            listall[5].Columns.Add(new DataColumn("Количество комнат"));
            listall[5].Columns.Add(new DataColumn("Подъезд"));
            listall[5].Columns.Add(new DataColumn("Этаж"));
            listall[5].Columns.Add(new DataColumn("Статус"));

            ready();
            pokaz();
            listall[4].RowChanged += MainWindow_RowChanged;
            listall[3].RowChanged += MainWindow_RowChanged1;
            listall[5].RowChanged += MainWindow_RowChanged2;
        }

        private void MainWindow_RowChanged2(object sender, DataRowChangeEventArgs e)
        {
            pokaz();
        }

        private void MainWindow_RowChanged1(object sender, DataRowChangeEventArgs e)
        {
            pokaz();
        }

        private void MainWindow_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            pokaz();
        }

        public static void ready()
        {
            Connect.connect();
            listall[3].Rows.Clear();
            listall[4].Rows.Clear();
            listall[5].Rows.Clear();
            DataRow dr;
            for (int i = 0; i < listall[0].Rows.Count; i++)
            {
                dr = listall[3].NewRow();
                dr[0] = Int32.Parse(listall[0].Rows[i][0].ToString());
                dr[1] = listall[0].Rows[i][1];
                dr[2] = listall[0].Rows[i][3].ToString() == "built" ? "Cтроительство" : listall[0].Rows[i][3].ToString() == "plan" ? "План" : "Реализация";
                int g = 0;
                for (int j = 0; j < listall[1].Rows.Count; j++)
                    if (listall[1].Rows[j][5].ToString() == listall[0].Rows[i][0].ToString()) g++;
                dr[3] = g;
                dr[4] = listall[0].Rows[i][2];

                listall[3].Rows.Add(dr);
            }
            for (int i = 0; i < listall[1].Rows.Count; i++)
            {
                dr = listall[4].NewRow();
                dr[0] = Int32.Parse(listall[1].Rows[i][0].ToString());
                for (int j = 0; j < listall[0].Rows.Count; j++)
                    if (listall[1].Rows[i][5].ToString() == listall[0].Rows[j][0].ToString())
                    {
                        dr[1] = listall[0].Rows[j][1];
                        dr[4] = listall[0].Rows[j][3].ToString() == "built" ? "Cтроительство" : listall[0].Rows[j][3].ToString() == "plan" ? "План" : "Реализация";
                    }
                dr[2] = listall[1].Rows[i][1];
                dr[3] = listall[1].Rows[i][2];
                int kv = 0, kvp = 0;
                for (int j = 0; j < listall[2].Rows.Count; j++)
                    if (listall[1].Rows[i][0].ToString() == listall[2].Rows[j][0].ToString())
                    {
                        kv = "sold" == listall[2].Rows[j][6].ToString() ? ++kv : kv;
                        kvp = "ready" == listall[2].Rows[j][6].ToString() ? ++kvp : kvp;
                    }
                dr[5] = kv;
                dr[6] = kvp;
                listall[4].Rows.Add(dr);
            }
            for (int i = 0; i < listall[2].Rows.Count; i++)
            {
                dr = listall[5].NewRow();
                dr[0] = i + 1;
                for (int j = 0; j < listall[0].Rows.Count; j++)
                    for (int d = 0; d < listall[1].Rows.Count; d++)
                        if (listall[1].Rows[d][0].ToString() == listall[2].Rows[i][0].ToString())
                        {
                            if (listall[1].Rows[d][5].ToString() == listall[0].Rows[j][0].ToString())
                            {
                                dr[1] = listall[0].Rows[j][1];
                            }
                        }
                for (int d = 0; d < listall[1].Rows.Count; d++)
                    if (listall[1].Rows[d][0].ToString() == listall[2].Rows[i][0].ToString())
                    {
                        dr[2] = "Ул." + listall[1].Rows[d][1] + " д." + listall[1].Rows[d][2] + " кв." + listall[2].Rows[i][1];
                    }
                dr[3] = listall[2].Rows[i][2];
                dr[4] = listall[2].Rows[i][3];
                dr[5] = listall[2].Rows[i][4];
                dr[6] = listall[2].Rows[i][5];
                dr[7] = listall[2].Rows[i][6].ToString() == "sold" ? "Продана" : "Продается";
                listall[5].Rows.Add(dr);
                
            }
        }
        private void pokaz()
        {
            listall[6].Rows.Clear();
            listall[6].Columns.Clear();
            _pageM = (int)Math.Ceiling(listall[_page + 3].Rows.Count / 20.0);
            if (_pageC > _pageM || _pageC < 0) _pageC = 0;
            for (int i = 0; i < listall[_page + 3].Columns.Count; i++)
                listall[6].Columns.Add(new DataColumn(listall[_page + 3].Columns[i].ColumnName));

            for (int i = (20 * _pageC); i < (20 * _pageC + 20); i++)
            {
                if (i > listall[_page + 3].Rows.Count-1) continue; 
                listall[6].ImportRow(listall[_page + 3].Rows[i]);
            }
            testGrid.ItemsSource = listall[6].AsDataView();
           
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(_page.ToString());
            if (_page < 2)
            {
                add.Show();
                add.Activate();
                add.check(0);
            }
            else
            {
                MessageBox.Show("Эти данные нельзя изменить");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_page < 2)
            {
                add.Show();
                add.Activate();
                add.check(1);
            }
            else
            {
                MessageBox.Show("Эти данные нельзя изменить");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_page < 2)
            {
                add.Show();
                add.Activate();
                add.check(2);
            }
            else
            {
                MessageBox.Show("Эти данные нельзя изменить");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            _page = _page < listall.Count - 5 ? ++_page : 0;
            page();

            ready();
            pokaz();
            //MessageBox.Show(i.ToString()) ;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _pageC = _pageM - 1;
            pokaz();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            _pageC = _pageC < _pageM-1 ? ++_pageC: _pageC;
            pokaz();
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _pageC = _pageC > 0 ? --_pageC : _pageC;
            pokaz();
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            _pageC = 0;
            pokaz();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            _page = _page > 0 ? --_page : listall.Count - 5;
            page();

            ready();
            pokaz();
            //MessageBox.Show(i.ToString());
        }

        private void page()
        {
            switch (_page)
            {
                case 0:
                    LogoLab.Content = "Список жилищных комплексов";
                    break;
                case 1:
                    LogoLab.Content = "Список домов";
                    break;
                case 2:
                    LogoLab.Content = "Список квартир";
                    break;
            }
        }
    }
}
