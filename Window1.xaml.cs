using MahApps.Metro.Controls;
using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace Devis_Factures_Remake
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : MetroWindow
    {
        string CON = (string)App.Current.Resources["connectionS"];
        public Func<ChartPoint, string> PointLabel { get; set; }
        public Window1()
        {
            
            InitializeComponent();
            PointLabel = chartPoint =>string.Format("{0:P}", chartPoint.Participation);

            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            using (var l_oConnection = new SqlConnection(CON))
            {
                try
                {
                    l_oConnection.Open();
                    MessageBox.Show("connected to database ");
                }
                catch (SqlException)
                {

                    MessageBox.Show("Error !! ");
                }
            }
        }
    }
}
