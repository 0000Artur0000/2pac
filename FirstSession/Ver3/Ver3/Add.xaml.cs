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




        }
        private void loadd()
        {
            if (MainWindow._page == 0)
            {
                slnadd();
                T3.Items.Clear();
                T3.Items.Add("План");
                T3.Items.Add("Строительство");
                T3.Items.Add("Реализация");
                T1.MaxLength = 30;
                T2.MaxLength = 9;
                T4.MaxLength = 9;
                T5.MaxLength = 30;
                L1.Content = "Название жилищного комплекса:";
                L2.Content = "Добавочная стоимость:";
                L3.Content = "Статус:";
                L4.Content = "Затраты на строительство:";
                L5.Content = "Город ЖК:";


            }
            else
            {
                slnadd1();
                T3.Items.Clear();
                for (int i = 0; i < MainWindow.listall[0].Rows.Count; i++)
                    T3.Items.Add(MainWindow.listall[0].Rows[i][1].ToString());

                T1.MaxLength = 30;
                T2.MaxLength = 5;
                T4.MaxLength = 9;
                T5.MaxLength = 9;
                L1.Content = "Улица:";
                L2.Content = "№ Дома:";
                L3.Content = "ЖК:";
                L4.Content = "Добавочная стоимость:";
                L5.Content = "Затраты на строительство::";
            }
        }
        private void slnadd1()
        {
            SelN.Items.Clear();
            for (int i = 0; i < MainWindow.listall[4].Rows.Count; i++)
                SelN.Items.Add(MainWindow.listall[4].Rows[i][0]);
            SelN.SelectedIndex = 0;
        }
        private void slnadd()
        {
            SelN.Items.Clear();
            for (int i = 0; i < MainWindow.listall[3].Rows.Count; i++)
                SelN.Items.Add(MainWindow.listall[3].Rows[i][0]);
            SelN.SelectedIndex = 0;
        }
        private void edc(bool j)
        {
            if (j)
            {
                T1.Text = "";
                T2.Text = "";
                T3.SelectedIndex = -1;
                T4.Text = "";
                T5.Text = "";
            }
            else
            {
                if (SelN.HasItems)
                {
                    if (MainWindow._page == 0)
                    {
                        T1.Text = MainWindow.listall[0].Rows[SelN.SelectedIndex][1].ToString();
                        T2.Text = MainWindow.listall[0].Rows[SelN.SelectedIndex][4].ToString();

                        int b = Int16.Parse(SelN.Text.ToString()[SelN.Text.ToString().Length - 1].ToString()) - 1;
                        string s = MainWindow.listall[0].Rows[b][3].ToString();
                        if (SelN.Text != "2")
                            T3.SelectedIndex = s == "plan" ? 0 : s == "built" ? 1 : 2;
                        else T3.SelectedIndex = 1;
                        T4.Text = MainWindow.listall[0].Rows[SelN.SelectedIndex][5].ToString();
                        T5.Text = MainWindow.listall[0].Rows[SelN.SelectedIndex][2].ToString();
                    }
                    else
                    {
                        T1.Text = MainWindow.listall[1].Rows[SelN.SelectedIndex][1].ToString();
                        T2.Text = MainWindow.listall[1].Rows[SelN.SelectedIndex][2].ToString();
                        for (int i = 0; i < MainWindow.listall[0].Rows.Count; i++)
                            if (MainWindow.listall[1].Rows[SelN.SelectedIndex][5].ToString() == MainWindow.listall[0].Rows[i][0].ToString())
                                T3.SelectedIndex = i;
                        T4.Text = MainWindow.listall[1].Rows[SelN.SelectedIndex][4].ToString();
                        T5.Text = MainWindow.listall[1].Rows[SelN.SelectedIndex][3].ToString();
                    }
                }
            }
        }
        public void check(int i)
        {
            switch (i)
            {
                case 0:
                    loadd();
                    TitleL.Content = "Добавление записи";
                    btnJob.Content = "Добавить";
                    LbN.Visibility = Visibility.Hidden;
                    SelN.Visibility = Visibility.Hidden;
                    grp(true);
                    edc(true);
                    break;
                case 1:
                    loadd();
                    TitleL.Content = "Изменение записи";
                    btnJob.Content = "Изменить";
                    LbN.Visibility = Visibility.Visible;
                    SelN.Visibility = Visibility.Visible;
                    grp(true);
                    edc(false);
                    break;
                case 2:
                    loadd();
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
                    if (MainWindow._page == 0)
                    {

                        DataRow dr = MainWindow.listall[0].NewRow();
                        int g = 1;
                        for (int i = 0; i < MainWindow.listall[0].Rows.Count; i++)
                            g = Int32.Parse(MainWindow.listall[0].Rows[i][0].ToString()) != g ? g : g + 1;
                        dr[0] = g;
                        try
                        {
                            if (!String.IsNullOrEmpty(T1.Text))
                                dr[1] = T1.Text;
                            else MessageBox.Show("Добавьте данные в 1 строку!");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Некорректные данные в 1 строке!");
                            goto suda1;
                        }
                        try
                        {
                            if (!String.IsNullOrEmpty(T5.Text))
                                dr[2] = T5.Text;
                            else MessageBox.Show("Добавьте данные в 5 строку!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Некорректные данные в 5 строке!");
                            goto suda1;
                        }
                        dr[3] = T3.Text == "Строительство" ? "built" : T3.Text == "План" ? "plan" : "ready";
                        try
                        {
                            if (!String.IsNullOrEmpty(T2.Text))
                                dr[4] = Int32.Parse(T2.Text);
                            else MessageBox.Show("Добавьте данные во 2 строку!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Некорректные данные в 2 строке!");
                            goto suda1;
                        }
                        try
                        {
                            if (!String.IsNullOrEmpty(T4.Text))
                                dr[5] = Int32.Parse(T4.Text);
                            else MessageBox.Show("Добавьте данные в 4 строку!");
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Некорректные данные в 4 строке!");
                            goto suda1;
                        }
                        //MainWindow.listall[0].Rows.Add(dr);
                        Connect.connect(0, dr);
                        MainWindow.ready();
                        slnadd();
                    }
                    else
                    {
                        DataRow dr = MainWindow.listall[1].NewRow();
                        int g = 1;
                        for (int i = 0; i < MainWindow.listall[1].Rows.Count; i++)
                            g = Int32.Parse(MainWindow.listall[1].Rows[i][0].ToString()) != g ? g : g + 1;
                        dr[0] = g;

                        if (!String.IsNullOrEmpty(T1.Text))
                            dr[1] = T1.Text;
                        else MessageBox.Show("Добавьте данные в 1 строку!");


                        if (!String.IsNullOrEmpty(T2.Text))
                            dr[2] = T2.Text;
                        else MessageBox.Show("Добавьте данные в 2 строку!");
                        for (int i = 0; i < MainWindow.listall[0].Rows.Count; i++)
                            if (T3.Text == MainWindow.listall[0].Rows[i][1].ToString())
                                dr[5] = MainWindow.listall[0].Rows[i][0];


                        if (!String.IsNullOrEmpty(T5.Text))
                            dr[3] = Int32.Parse(T5.Text);
                        else MessageBox.Show("Добавьте данные во 5 строку!");


                        if (!String.IsNullOrEmpty(T4.Text))
                            dr[4] = Int32.Parse(T4.Text);
                        else MessageBox.Show("Добавьте данные в 4 строку!");

                        //MainWindow.listall[0].Rows.Add(dr);
                        Connect.connect(3, dr);
                        MainWindow.ready();
                        slnadd();
                    }

                    suda1:
                    break;
                case 1:

                    if (SelN.HasItems)
                    {
                        if (MainWindow._page == 0)
                        {
                            DataRow dr1 = MainWindow.listall[0].NewRow();

                            dr1[0] = MainWindow.listall[0].Rows[SelN.SelectedIndex][0];
                            try
                            {
                                if (!String.IsNullOrEmpty(T1.Text))
                                    dr1[1] = T1.Text;
                                else MessageBox.Show("Добавьте данные в 1 строку!");

                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Некорректные данные в 1 строке!");
                                goto suda;
                            };

                            try
                            {
                                if (!String.IsNullOrEmpty(T5.Text))
                                    dr1[2] = T5.Text;
                                else MessageBox.Show("Добавьте данные в 5 строку!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Некорректные данные в 5 строке!");
                                goto suda;
                            }
                            dr1[3] = T3.Text == "Строительство" ? "built" : T3.Text == "План" ? "plan" : "ready";
                            try
                            {
                                if (!String.IsNullOrEmpty(T2.Text))
                                    dr1[4] = Int32.Parse(T2.Text);
                                else MessageBox.Show("Добавьте данные во 2 строку!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Некорректные данные в 2 строке!");
                                goto suda;
                            }
                            try
                            {
                                if (!String.IsNullOrEmpty(T4.Text))
                                    dr1[5] = Int32.Parse(T4.Text);
                                else MessageBox.Show("Добавьте данные в 4 строку!");
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("Некорректные данные в 4 строке!");
                                goto suda;
                            }
                            //for (int i = 0; i < MainWindow.listall[0].Columns.Count; i++)
                            //    MainWindow.listall[0].Rows[SelN.SelectedIndex][i] = dr1[i];

                            Connect.connect(1, dr1);
                            //MessageBox.Show(dr1.Table.Columns.Count.ToString());
                            MainWindow.ready();

                        }
                        else
                        {
                            DataRow dr1 = MainWindow.listall[1].NewRow();

                            dr1[0] = MainWindow.listall[1].Rows[SelN.SelectedIndex][0];

                            if (!String.IsNullOrEmpty(T1.Text))
                                dr1[1] = T1.Text;
                            else MessageBox.Show("Добавьте данные в 1 строку!");


                            if (!String.IsNullOrEmpty(T2.Text))
                                dr1[2] = T2.Text;
                            else MessageBox.Show("Добавьте данные в 2 строку!");
                            for (int i = 0; i < MainWindow.listall[0].Rows.Count; i++)
                                if (T3.Text == MainWindow.listall[0].Rows[i][1].ToString())
                                    dr1[5] = MainWindow.listall[0].Rows[i][0];


                            if (!String.IsNullOrEmpty(T5.Text))
                                dr1[3] = Int32.Parse(T5.Text);
                            else MessageBox.Show("Добавьте данные во 5 строку!");


                            if (!String.IsNullOrEmpty(T4.Text))
                                dr1[4] = Int32.Parse(T4.Text);
                            else MessageBox.Show("Добавьте данные в 4 строку!");

                            //for (int i = 0; i < MainWindow.listall[0].Columns.Count; i++)
                            //    MainWindow.listall[0].Rows[SelN.SelectedIndex][i] = dr1[i];

                            Connect.connect(4, dr1);
                            //MessageBox.Show(dr1.Table.Columns.Count.ToString());
                            MainWindow.ready();
                        }
                    }

                    suda:
                    break;
                case 2:

                    if (SelN.HasItems)
                    {
                        if (MainWindow._page == 0)
                        {
                            DataRow dr2 = MainWindow.listall[0].Rows[SelN.SelectedIndex];
                            //MainWindow.listall[0].Rows.Remove(dr2);
                            Connect.connect(2, dr2);
                            MainWindow.ready();
                            slnadd();
                        }
                        else
                        {
                            DataRow dr2 = MainWindow.listall[1].Rows[SelN.SelectedIndex];
                            //MainWindow.listall[0].Rows.Remove(dr2);
                            Connect.connect(5, dr2);
                            MainWindow.ready();
                            slnadd();
                        }
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
                        if (che == 2)
                        {
                            List<string> ko = new List<string>();
                            //MessageBox.Show(MainWindow.listall[2].Rows[Int32.Parse(SelN.Text.ToString())][6].ToString());

                            for (int i = 0; i < MainWindow.listall[1].Rows.Count; i++)
                                if (MainWindow.listall[1].Rows[i][5].ToString() == SelN.Text)
                                    ko.Add(MainWindow.listall[1].Rows[i][0].ToString());

                            for (int d = 0; d < ko.Count; d++)
                                for (int k = 0; k < MainWindow.listall[2].Rows.Count; k++)
                                    if (MainWindow.listall[2].Rows[k][0].ToString() == ko[d])
                                        if (MainWindow.listall[2].Rows[k][6].ToString() == "sold")
                                            ch = true;

                            if (ch)
                            {
                                MessageBox.Show("В этом ЖК уже есть квартиры со статусом \"продана\"");
                                T3.SelectedIndex = 1;
                            }
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

        private void SelN_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(SelN.Text))
            {

                if (che == 1) edc(false);
            }
        }
    }
}
