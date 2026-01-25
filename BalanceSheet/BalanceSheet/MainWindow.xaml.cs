using Microsoft.UI.Windowing;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BalanceSheet
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Activated += MainWindow_Activated;
        }

        /// <summary>
        /// This navigate the frame to the page.
        /// </summary>
        /// <param name="sender">This window.</param>
        /// <param name="args">Event arguments.</param>
        private void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            MainFrame.Navigate(typeof(BalanceSheet));

            OverlappedPresenter presenter = (OverlappedPresenter)AppWindow.Presenter;
            presenter.Maximize();
        }
    }
}
