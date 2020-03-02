using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ver3
{
    class Connect
    {
        private static SqlConnectionStringBuilder connS = new SqlConnectionStringBuilder()
        {
            // DataSource = "303-2\\SQLEXPRESS",
            DataSource = "DESKTOP-U5HC5KL",
            InitialCatalog = "Ver2",
            IntegratedSecurity = true
        };
        public static void connect()
        {
            using (SqlConnection conn = new SqlConnection(connS.ConnectionString))
            {
                conn.Open();
                List<DataTable> dat = new List<DataTable>()
                {
                    MainWindow.listall[0],
                    MainWindow.listall[1],
                    MainWindow.listall[2]
                };
                foreach (DataTable dt in dat)
                {
                    string d = "SELECT * FROM dbo." + dt.Prefix + "";
                    SqlCommand cmd = new SqlCommand(d, conn);
                    using (SqlDataAdapter ada = new SqlDataAdapter(cmd))
                    {
                        dt.Clear();
                        ada.Fill(dt);

                    }
                }
                conn.Close();
            }
        }
        public static void connect(byte i, DataRow dr)
        {
            using (SqlConnection conn = new SqlConnection(connS.ConnectionString))
            {
                conn.Open();

                switch (i)
                {
                    case 0:
                        {
                            string d = $"INSERT INTO dbo.Jk(Id_Jk, Название_ЖК, Город, Статус_строительства_ЖК, Добавочная_стоимость_ЖК, Затраты_на_строительство_ЖК) Values ('{dr[0]}', '{dr[1]}', '{dr[2]}', '{dr[3]}', '{dr[4]}', '{dr[5]}') ";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    case 1:
                        {
                            string d = $"UPDATE dbo.Jk Set Название_ЖК = '{dr[1]}', Город = '{dr[2]}', Статус_строительства_ЖК = '{dr[3]}', Добавочная_стоимость_ЖК = '{dr[4]}', Затраты_на_строительство_ЖК = '{dr[5]}' WHERE Id_Jk = '{dr[0]}'";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    case 2:
                        {
                            string d = $"DELETE FROM dbo.Jk WHERE Id_Jk = '{dr[0]}'";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    case 3:
                        {
                            string d = $"INSERT INTO dbo.houses_in_complexes([id],[Улица],[Номер_дома],[Затраты_на_строительство_дома],[Добавочная_стоимость_квартиры_в_доме],[Id_JK]) Values ('{dr[0]}', '{dr[1]}', '{dr[2]}', '{dr[3]}', '{dr[4]}', '{dr[5]}') ";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    case 4:
                        {
                            string d = $"UPDATE dbo.houses_in_complexes Set [Улица] = '{dr[1]}', [Номер_дома] = '{dr[2]}', [Затраты_на_строительство_дома] = '{dr[3]}', [Добавочная_стоимость_квартиры_в_доме]= '{dr[4]}', [Id_JK] = '{dr[5]}' WHERE Id = '{dr[0]}'";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                    case 5:
                        {
                            string d = $"DELETE FROM dbo.houses_in_complexes WHERE Id = '{dr[0]}'";
                            SqlCommand cmd = new SqlCommand(d, conn);
                            cmd.ExecuteNonQuery();
                            break;
                        }
                }

                conn.Close();
            }
        }
    }
}
