using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
using ControlzEx.Standard;
using MahApps.Metro.Controls;
using System.Security;
using System.Configuration;
using System.Data.SqlClient;

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
            strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
            //strings.Source = App.Current.Resources.MergedDictionaries[3].Source;
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

        //Lunch the calculator app
        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            AppLuncher("calculator");
        }
        //Lunch the notes app
        private void btnNotes_Click(object sender, RoutedEventArgs e)
        {
            AppLuncher("notepad");
        }
        //Lunch the calendar app
        private void btnCalendar_Click(object sender, RoutedEventArgs e)
        {
            AppLuncher("chrome");
        }

        // //////////////////////////////////////////////////////////////

        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        private void AppLuncher(string fileName)
        {


            Process[] proc = Process.GetProcessesByName(fileName);
            if (proc.Length != 0)
            {
                proc[0].WaitForInputIdle();
                IntPtr s = proc[0].MainWindowHandle;
                SetForegroundWindow(s);
            }
            else if (fileName == "notepad")
            {
                Process.Start(fileName, @"C:\Users\DELL\Desktop\DevisFacturesNotes.txt");
            }
            else if (fileName == "calculator")
            {
                Process.Start("calc");
            }
            else if (fileName == "chrome")
            {
                Process.Start("chrome");
            }

        }

        //Lunch the setting app
        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnCalc_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
        }

    }
}