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
        public static DataTable nice = new DataTable();
        public static DataTable jk = new DataTable();
        public static DataTable hic = new DataTable();
        public static DataTable aih = new DataTable();
        Add add = new Add();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            jk.Prefix = "Jk";
            aih.Prefix = "apartments_in_houses";
            hic.Prefix = "houses_in_complexes";

            

            nice.Columns.Add(new DataColumn("№"));
            nice.Columns.Add(new DataColumn("Название ЖК"));
            nice.Columns.Add(new DataColumn("Статус"));
            nice.Columns.Add(new DataColumn("Количество домов в ЖК"));
            nice.Columns.Add(new DataColumn("Город, в котором находится ЖК"));
            testGrid.ItemsSource = nice.AsDataView();
            ready();
        }
        private void gr()
        {
            var col = testGrid.Columns[0];
            testGrid.Items.SortDescriptions.Clear();
            testGrid.Items.SortDescriptions.Add(new SortDescription(col.SortMemberPath, ListSortDirection.Ascending));
        }
        public static void ready()
        {
            Connect.connect();
            nice.Rows.Clear();
            DataRow dr;
            for (int i = 0; i < jk.Rows.Count; i++)
            {
                dr = nice.NewRow();
                dr[0] = jk.Rows[i][0];
                dr[1] = jk.Rows[i][1];
                dr[2] = jk.Rows[i][3].ToString() == "built" ? "Cтроительство" : jk.Rows[i][3].ToString() == "plan" ? "План" : "Реализация";
                int g = 0;
                for (int j = 0; j < hic.Rows.Count; j++)
                    if (hic.Rows[j][5].ToString() == jk.Rows[i][0].ToString()) g++;
                dr[3] = g;
                dr[4] = jk.Rows[i][2];

                nice.Rows.Add(dr);

            }
            MainWindow mw = (MainWindow)Application.Current.Windows[1];
            mw.gr();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            add.Show();
            add.Activate();
            add.check(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            add.Show();
            add.Activate();
            add.check(1);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            add.Show();
            add.Activate();
            add.check(2);
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
