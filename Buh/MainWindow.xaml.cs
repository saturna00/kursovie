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

namespace Buh
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

        private void Vhod_Click(object sender, RoutedEventArgs e)
        {
            if (log.Text.Length > 0) // проверяем введён ли логин
            {
                if (psw.Text.Length > 0) // проверяем введён ли пароль
                { // ищем в базе данных пользователя с такими данными
                    DataTable dt_user = mainWindow.Select("SELECT * FROM [dbo].[Users] WHERE [Login] = '" + log.Text + "' AND [Password] = '" + psw.Text + "'");
                    if (dt_user.Rows.Count > 0) // если такая запись существует
                    {
                    }
                }
            }
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase"); // создаём таблицу в приложении
                                                             // подключаемся к базе данных
            SqlConnection sqlConnection = null; //SqlConnection sqlConnection = new SqlConnection("server=PC\\SQLEXPRESS;Trusted_Connection=Yes;DataBase=testlog;");
            sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open(); // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); // создаём команду
            sqlCommand.CommandText = selectSQL; // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable); // возращаем таблицу с результатом
            return dataTable;


        }
    } 
}
