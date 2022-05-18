using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
using Devis_Factures_Remake.Tabs;

namespace Devis_Factures_Remake.FLayouts
{
    /// <summary>
    /// Interaction logic for AddProduit.xaml
    /// </summary>
    public partial class AddProduit : UserControl
    {
        ResourceDictionary strings = new ResourceDictionary();
        public AddProduit()
        {
            strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
            InitializeComponent();
            //just for test scrolling
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


        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=Tabs;Integrated Security=True");
        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
            dlg.RestoreDirectory = true;

            bool? result = dlg.ShowDialog();
            if (result == true)
            {
                string selectedFileName = dlg.FileName;
                //FileNameLabel.Content = selectedFileName;
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(selectedFileName);
                bitmap.EndInit();
                imageProduct.Source = bitmap;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FillDataGrid();
        }

        private void FillDataGrid()

        {

            string ConString = (string)App.Current.Resources["conString"];

            string CmdString = string.Empty;

            using (SqlConnection con = new SqlConnection(ConString))

            {
                con.Open();
                String Query = @$"insert into Produit (unite, designation, famile, fournisseur, pAchat, pVente, mergeEnTax, tax, totalTTC, img) values(2, '{desProdCol.Text}', 'info', 'Ayoub', {int.Parse(acahtProdCol.Text)}, {int.Parse(venteProdCol.Text)}, 30, 40, 50, 'C:\Users\DELL\ElgountariAyoub\NestedFolders\DestopWallpaper\Thinking\code-hacker-1366x768.jpg')";
                //Query = @"insert into Produit (unite, designation, famile, fournisseur, pAchat, pVente, mergeEnTax, tax, totalTTC, img) values(2, 'computer', 'info', 'Amin', 100, 200, 300, 400, 500, 'C:\Users\DELL\ElgountariAyoub\NestedFolders\DestopWallpaper\Thinking\code-hacker-1366x768.jpg')";
                SqlCommand ncmd = new SqlCommand(Query, con);
                ncmd.ExecuteNonQuery();
                con.Close();
                con.Open();
                CmdString = "SELECT ref, designation, pVente, totalTTC, pAchat, famile, fournisseur FROM Produit";
                SqlCommand cmd = new SqlCommand(CmdString, con);


                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable("Produit");

                sda.Fill(dt);


               
                con.Close();

            }

        }

        private void venteProdCol_TextChanged(object sender, TextChangedEventArgs e)
        {
            double op = int.Parse(venteProdCol.Text) + int.Parse(venteProdCol.Text) * 0.4;
            tttcAvoir.Text = op.ToString();
        }
    }
}
