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
using System.Windows.Controls.Primitives;
using MahApps.Metro.Controls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Devis_Factures_Remake.Tabs
{
    /// <summary>
    /// Interaction logic for ProduitsTab.xaml
    /// </summary>
    public partial class ProduitsTab : UserControl
    {
        ResourceDictionary strings = new ResourceDictionary();

        public ProduitsTab()
        {
            strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
            InitializeComponent();
            
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }
        public void TooltipHandller(object sender, MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button != null) { SetAltToolTip(button, strings[button.Name]); }
        }
        private void TooltipCloseHandller(object sender, MouseEventArgs e)
        {
            AltTooltip.Visibility = Visibility.Collapsed;
            AltTooltip.IsOpen = false;
        }

        public void SetAltToolTip(Button target, object message)
        {
            AltTooltip.PlacementTarget = target;
            AltTooltip.Placement = PlacementMode.Bottom;
            AltTooltip.IsOpen = true;
            Context.PopupText.Text = message.ToString();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            object obj = parentWindow.FindName("testfl");
            Flyout flyout = (Flyout)obj;
            flyout.Content = new FLayouts.AddProduit();
            flyout.IsOpen = !flyout.IsOpen;
        }
        void reloaduc(object s,RoutedEventHandler e)
        {
            string ConString = (string)App.Current.Resources["conString"];

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT ref, designation, pVente, totalTTC, pAchat, famile, fournisseur FROM Produit";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Produit");

                sda.Fill(dt);

                dgProduits.ItemsSource = dt.DefaultView;

            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            object obj = parentWindow.FindName("testfl");
            Flyout flyout = (Flyout)obj;
            flyout.Content = new FLayouts.AddProduit();
            flyout.IsOpen = !flyout.IsOpen;
        }

        private void FillDataGrid()

        {

            string ConString = (string)App.Current.Resources["conString"];

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {

                CmdString = "SELECT ref, designation, pVente, totalTTC, pAchat, famile, fournisseur FROM Produit";

                SqlCommand cmd = new SqlCommand(CmdString, con);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Produit");

                sda.Fill(dt);

                dgProduits.ItemsSource = dt.DefaultView;

            }

        }


    }
}
