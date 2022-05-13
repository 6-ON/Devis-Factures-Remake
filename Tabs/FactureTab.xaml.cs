using System;
using System.Collections.Generic;
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
using MahApps.Metro.Controls;
namespace Devis_Factures_Remake.Tabs
{
    /// <summary>
    /// Interaction logic for FactureTab.xaml
    /// </summary>
    public partial class FactureTab : UserControl
    {
        ResourceDictionary strings = new ResourceDictionary();
        public FactureTab()
        {
            strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
            InitializeComponent();
            //just for test scrolling
            List<int> nums = new List<int>();
            for (int i = 0; i < 100; ++i)
                nums.Add(i);

            dgFactures.ItemsSource = nums;
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

        private void btnReglemetnt_Click(object sender, RoutedEventArgs e)
        {
            Window parentWindow = Window.GetWindow(this);
            object obj = parentWindow.FindName("testfl");
            Flyout flyout = (Flyout)obj;
            flyout.Content = new FLayouts.ReglementFlyout();
            flyout.Header = "Reglement";
            flyout.IsOpen = !flyout.IsOpen;
        }
    }
}
