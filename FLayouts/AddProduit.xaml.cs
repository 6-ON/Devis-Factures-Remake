using Microsoft.Win32;
using System;
using System.Collections.Generic;
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
        // -----------------------------------------------------------------
        public void LoadImage(string fileName)
        {
            ImageSource = new BitmapImage(new Uri(fileName, UriKind.Relative));
        }

        public ImageSource ImageSource { get; set; }
        // -----------------------------------------------------------------
        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            { //OpenFileDialog fileDialog = new OpenFileDialog();
              //fileDialog.DefaultExt = ".png"; // Required file extension 
              //fileDialog.Filter = "Text documents (.png)|*.jpg"; // Optional file extensions

                ////SaveFileDialog saveFileDialog = new SaveFileDialog();
                //bool? result = fileDialog.ShowDialog();
                //if (result == true)
                //{
                //    //MessageBox.Show(fileDialog.FileName.ToString());
                //    //imageProduct.Source = fileDialog.FileName.ToLower();

                //    var uriSource = new Uri(fileDialog.FileName, UriKind.Relative);
                //    LoadImage(fileDialog.FileName);
                //    imageProduct.Source = new BitmapImage(uriSource);

                //    System.IO.StreamReader sr = new System.IO.StreamReader(fileDialog.FileName);
                //    //MessageBox.Show(sr.ReadToEnd());
                //    sr.Close();
                //}
            }
            {
                //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                ////if (openFileDialo1.ShowDialog() == true)
                ////    txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
                ////To where your opendialog box get starting location. My initial directory location is desktop.
                //openFileDialog1.InitialDirectory = "C://Desktop";
                ////Your opendialog box title name.
                //openFileDialog1.Title = "Select file to be upload.";
                ////which type file format you want to upload in database. just add them.
                //openFileDialog1.Filter = "Select Valid Document(*.pdf; *.doc; *.xlsx; *.html)|*.pdf; *.docx; *.xlsx; *.html";
                ////FilterIndex property represents the index of the filter currently selected in the file dialog box.
                //openFileDialog1.FilterIndex = 1;
                //try
                //{
                //    if (openFileDialog1.ShowDialog() == DialogResult.Ok)
                //    {
                //        if (openFileDialog1.CheckFileExists)
                //        {
                //            string path = System.IO.Path.GetFullPath(openFileDialog1.FileName);
                //            label1.Text = path;
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Please Upload document.");
                //    }
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
            }


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
    }
}
