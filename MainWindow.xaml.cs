using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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

namespace Devis_Factures_Remake
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        //[DllImport("user32.dll")]
        //internal static extern IntPtr SetForegroundWindow(IntPtr hWnd);

        //[DllImport("user32.dll")]
        //internal static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        ResourceDictionary strings = new ResourceDictionary();

        public MainWindow()
        {
            strings.Source = new Uri(@"resources\dictionaries\strings.xaml", UriKind.Relative);
            InitializeComponent();
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

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            Process[] proc = Process.GetProcessesByName("calculator");


            if (proc.Length != 0)
            {
                proc[0].Kill();
            }
            Process.Start("calc");
        }

        //hambugermwnu behaviour
        private void HamburgerMenuControl_OnItemInvoked(object sender, HamburgerMenuItemInvokedEventArgs e)
        {
            this.HamburgerMenuControl.Content = e.InvokedItem;
            //if (!e.IsItemOptions && this.HamburgerMenuControl.IsPaneOpen)
            //{
            //    // You can close the menu if an item was selected
            //    this.HamburgerMenuControl.IsPaneOpen = false;
            //}
        }
    }
}
