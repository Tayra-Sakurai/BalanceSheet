using ChimpanzeeLibrary.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Extensions.DependencyInjection;
using ChimpanzeeLibrary.Models;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace BalanceSheet
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailPage : Page
    {
        private TayraViewModel? tayra;

        public DetailPage()
        {
            InitializeComponent();
            tayra = App.Current.Services.GetService<TayraViewModel>();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Parameter is Tayra t && tayra != null)
            {
                tayra.InitializeForExistingValue(t);
            }
        }

        private async void ReturnBtn_Click(object sender, RoutedEventArgs e)
        {
            Dialog dialog = new();
            dialog.XamlRoot = MainPanel.XamlRoot;
            dialog.DefaultButton = ContentDialogButton.Primary;

            ContentDialogResult result = await dialog.ShowAsync();
            if (result == ContentDialogResult.Primary && tayra != null)
            {
                await tayra.SaveChangesAsync();
            }

            Frame.Navigate(typeof(BalanceSheet));
        }
    }
}
