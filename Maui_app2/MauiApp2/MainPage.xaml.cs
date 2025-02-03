using Microsoft.Maui.Controls;
using System.Diagnostics;

namespace MauiApp2
{
    public partial class MainPage : ContentPage
    {
        Button loginButton;
        VerticalStackLayout layout;

        public MainPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Clicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Login button clicked!");
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            Debug.WriteLine("Counter button clicked!");
        }
    }
}
