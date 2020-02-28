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
using System.Windows.Shapes;

namespace Ver3
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        public Add()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
        byte che;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            slnadd();
            T3.Items.Add("План");
            T3.Items.Add("Строительство");
            T3.Items.Add("Реализация");
        }
        private void slnadd()
        {
            SelN.Items.Clear();
            for (int i = 0; i < MainWindow.nice.Rows.Count; i++)
                SelN.Items.Add(MainWindow.nice.Rows[i][0]);
            SelN.SelectedIndex = 0;
        }
        private void edc(bool j)
        {
            if (j)
            {
                T1.Text = "";
                T2.Text = "";
                T3.SelectedIndex = 0;
                T4.Text = "";
                T5.Text = "";
            }
            else
            {
                if (SelN.HasItems)
                {
                    T1.Text = MainWindow.jk.Rows[SelN.SelectedIndex][1].ToString();
                    T2.Text = MainWindow.jk.Rows[SelN.SelectedIndex][4].ToString();
                    int b = Int16.Parse(SelN.Text.ToString()[SelN.Text.ToString().Length - 1].ToString()) - 1;
                    string s = MainWindow.jk.Rows[b][3].ToString();
                    T3.SelectedIndex = s == "plan" ? 0 : s == "built" ? 1 : 2;
                    T4.Text = MainWindow.jk.Rows[SelN.SelectedIndex][5].ToString();
                    T5.Text = MainWindow.jk.Rows[SelN.SelectedIndex][2].ToString();
                }
            }
        }
        public void check(int i)
        {
            switch (i)
            {
                case 0:
                    TitleL.Content = "Добавление записи";
                    btnJob.Content = "Добавить";
                    LbN.Visibility = Visibility.Hidden;
                    SelN.Visibility = Visibility.Hidden;
                    grp(true);
                    edc(true);
                    break;
                case 1:
                    TitleL.Content = "Изменение записи";
                    btnJob.Content = "Изменить";
                    LbN.Visibility = Visibility.Visible;
                    SelN.Visibility = Visibility.Visible;
                    grp(true);
                    edc(false);
                    break;
                case 2:
                    TitleL.Content = "Удаление записи";
                    btnJob.Content = "Удалить";
                    LbN.Visibility = Visibility.Visible;
                    SelN.Visibility = Visibility.Visible;
                    grp(false);
                    edc(true);
                    break;
            }
            che = Convert.ToByte(i);

            void grp(bool j)
            {
                if (j)
                {
                    LbN.Height = 26;
                    LbN.Width = 67;
                    LbN.FontSize = 12;
                    LbN.Margin = new Thickness(0, 10, 130, 0);
                    SelN.Height = 22;
                    SelN.Width = 113;
                    SelN.FontSize = 12;
                    SelN.Margin = new Thickness(0, 10, 10, 0);
                    L1.Visibility = Visibility.Visible;
                    L2.Visibility = Visibility.Visible;
                    L3.Visibility = Visibility.Visible;
                    L4.Visibility = Visibility.Visible;
                    L5.Visibility = Visibility.Visible;
                    T1.Visibility = Visibility.Visible;
                    T2.Visibility = Visibility.Visible;
                    T3.Visibility = Visibility.Visible;
                    T4.Visibility = Visibility.Visible;
                    T5.Visibility = Visibility.Visible;

                }
                else
                {
                    LbN.Height = 36;
                    LbN.Width = 97;
                    LbN.FontSize = 18;
                    LbN.Margin = new Thickness(0, 67, 323, 0);
                    SelN.Height = 32;
                    SelN.Width = 162;
                    SelN.FontSize = 18;
                    SelN.Margin = new Thickness(0, 67, 156, 0);

                    L1.Visibility = Visibility.Hidden;
                    L2.Visibility = Visibility.Hidden;
                    L3.Visibility = Visibility.Hidden;
                    L4.Visibility = Visibility.Hidden;
                    L5.Visibility = Visibility.Hidden;
                    T1.Visibility = Visibility.Hidden;
                    T2.Visibility = Visibility.Hidden;
                    T3.Visibility = Visibility.Hidden;
                    T4.Visibility = Visibility.Hidden;
                    T5.Visibility = Visibility.Hidden;
                }
            }

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }


        private void btnJob_Click(object sender, RoutedEventArgs e)
        {
            switch (che)
            {
                case 0:
                    DataRow dr = MainWindow.jk.NewRow();
                    int g = 1;
                    for (int i = 0; i < MainWindow.jk.Rows.Count; i++)
                        g = Int32.Parse(MainWindow.jk.Rows[i][0].ToString()) != g ? g : g + 1;
                    dr[0] = g;
                    dr[1] = T1.Text;
                    dr[2] = T5.Text;
                    dr[3] = T3.Text == "Строительство" ? "built" : T3.Text == "План" ? "plan" : "ready";
                    dr[4] = Int32.Parse(T2.Text);
                    dr[5] = Int32.Parse(T4.Text);
                    //MainWindow.jk.Rows.Add(dr);
                    Connect.connect(0, dr);
                    MainWindow.ready();
                    slnadd();
                    break;
                case 1:
                    if (SelN.HasItems)
                    {
                        DataRow dr1 = MainWindow.jk.NewRow();
                        dr1[0] = MainWindow.jk.Rows[SelN.SelectedIndex][0];
                        dr1[1] = T1.Text;
                        dr1[2] = T5.Text;
                        dr1[3] = T3.Text == "Строительство" ? "built" : T3.Text == "План" ? "plan" : "ready";
                        dr1[4] = Int32.Parse(T2.Text);
                        dr1[5] = Int32.Parse(T4.Text);
                        //for (int i = 0; i < MainWindow.jk.Columns.Count; i++)
                        //    MainWindow.jk.Rows[SelN.SelectedIndex][i] = dr1[i];

                        Connect.connect(1, dr1);
                        //MessageBox.Show(dr1.Table.Columns.Count.ToString());
                        MainWindow.ready();
                    }

                    break;
                case 2:
                    if (SelN.HasItems)
                    {
                        DataRow dr2 = MainWindow.jk.Rows[SelN.SelectedIndex];
                        //MainWindow.jk.Rows.Remove(dr2);
                        Connect.connect(2, dr2);
                        MainWindow.ready();
                        slnadd();
                    }
                    break;
            }
        }

        private void T3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool ch = false;
            if (T3.SelectedIndex == 0)
            {
                if (!String.IsNullOrEmpty(T3.Text))
                    if (!String.IsNullOrEmpty(SelN.Text))
                    {
                        //MessageBox.Show(MainWindow.aih.Rows[Int32.Parse(SelN.Text.ToString())][6].ToString());
                        for (int i = 0; i < MainWindow.aih.Rows.Count; i++)
                            if (MainWindow.aih.Rows[i][0].ToString() == SelN.Text)
                                if (MainWindow.aih.Rows[i][6].ToString() == "sold")
                                    ch = true;
                        if (ch)
                        {
                            //MessageBox.Show("В этом ЖК уже есть квартиры со статусом \"продана\"");
                            T3.SelectedIndex = 1;
                        }
                    }
            }
        }




        private void SelN_DropDownClosed(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(SelN.Text))
            {

                if (che == 1) edc(false);
            }
        }
    }
}
