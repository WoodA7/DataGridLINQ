using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Configuration;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridLINQ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var constr = ConfigurationManager.ConnectionStrings["connstr"].ToString();
            var db = new StepDataContext(constr);
            var res = from t in db.Tickets
                select new
                {
                    t.FirstName,
                    t.SecondName,
                    SrcName = t.City.Name,
                    DestName = t.City1.Name,
                    t.Date1,
                    t.Date2,
                    t.Class
                };
            dataGrid.ItemsSource = res;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
