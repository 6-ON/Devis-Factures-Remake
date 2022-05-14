using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using MahApps.Metro.Controls;
using LiveCharts;
using LiveCharts.Wpf;

namespace Devis_Factures_Remake.Tabs
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl
    {
        public string[] XLabels { get; set; }
        ResourceDictionary strings = new ResourceDictionary();
        string CON = (string)App.Current.Resources["connectionS"];
        public Dashboard()
        {
            InitializeComponent();
            strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
            XLabels =  CultureInfo.GetCultureInfoByIetfLanguageTag("fr").DateTimeFormat.AbbreviatedMonthNames;

            DataContext = this;
        }
        public void OnLoad(object sender ,RoutedEventArgs args)
        {
            using (var ctn = new SqlConnection(CON))
            {
                string query = "select name,price from months ";
                SqlCommand cmd = new SqlCommand(query, ctn);
                // had dictionary fiha columns dyal month name and incoms dyalo 
                Dictionary<string, decimal> rs = new Dictionary<string, decimal>();
                try
                {
                    ctn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        rs.Add((string)reader[0], (decimal)reader[1]);
                    }
                    //clear old chart
                    SeriesCollection updatedseries = new SeriesCollection();
                    foreach (var item in rs)
                    {
                        updatedseries.Add(
                                new PieSeries
                                {
                                    Title = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.Key.ToLower()) ,
                                    Values = new ChartValues<decimal> { item.Value },
                                    PushOut = 0,
                                    DataLabels = true,
                                    LabelPoint =  chartPoint => string.Format("{0} MAD {1:P}", chartPoint.Y, chartPoint.Participation)
                                });
                    }
                    PieChar.Series.Clear();
                    PieChar.Series.AddRange(updatedseries);



                }
                catch (SqlException)
                {

                    MessageBox.Show("Error !! ");
                }
            }
        }
        // tooltip setup
        public void TooltipHandller(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null) { SetAltToolTip(button, strings[button.Name]); }
        }
        private void TooltipCloseHandller(object sender ,MouseEventArgs e)
        {
            AltTooltip.Visibility = Visibility.Collapsed;
            AltTooltip.IsOpen = false;
        }
        public void SetAltToolTip(Button target,object message)
        {
            AltTooltip.PlacementTarget = target;
            AltTooltip.Placement = PlacementMode.Bottom;
            AltTooltip.IsOpen = true;
            Context.PopupText.Text = message.ToString();
        }

        private void btnCreateFournisseuer_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            object obj = parentWindow.FindName("testfl");
            Flyout flyout = (Flyout)obj;
            flyout.Content = new FLayouts.FournisseursFL();
            flyout.IsOpen = !flyout.IsOpen;
        }

        private void CircleRadioChecked(object sender, RoutedEventArgs e)
        {
            HideAllChartsButThis(PieChar);
        }
        private void HistoRadioChecked(object sender, RoutedEventArgs e)
        {
            HideAllChartsButThis(HistoChar);
        }
        private void CurveRadioChecked(object sender, RoutedEventArgs e)
        {
            HideAllChartsButThis(CurveChar);
        }
        void HideAllChartsButThis(FrameworkElement target)
        {
            FrameworkElement[] charts = { PieChar, HistoChar,CurveChar};
            //hide all
            foreach (var chart in charts)
                if (chart !=target && chart !=null)
                    chart.Visibility = Visibility.Collapsed;
            //show selected
            if (target !=null)
                target.Visibility = Visibility.Visible;
        }

    }
}
