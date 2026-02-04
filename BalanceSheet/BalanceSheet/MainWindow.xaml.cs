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
using System.Security.Principal;
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

            if (AppWindowTitleBar.IsCustomizationSupported())
            {
                string path = AppContext.BaseDirectory;
                AppWindow.SetIcon(Path.Combine(path, "Chrome_Logo.ico"));
            }

            Activated += MainWindow_Activated;
        }

        /// <summary>
        /// This navigate the frame to the page.
        /// </summary>
        /// <param name="sender">This window.</param>
        /// <param name="args">Event arguments.</param>
        private async void MainWindow_Activated(object sender, WindowActivatedEventArgs args)
        {
            OverlappedPresenter presenter = (OverlappedPresenter)AppWindow.Presenter;
            presenter.Maximize();

            // Getting the user data.
            string? userSid = WindowsIdentity.GetCurrent().User?.Value;

            if(userSid is string user)
            {
                if (user == SecretResources.UserName)
                {
                    Debug.WriteLine(user);
                    MainFrame.Navigate(typeof(BalanceSheet));
                    return;
                }
            }

            Application.Current.Exit();
        }
    }
}
