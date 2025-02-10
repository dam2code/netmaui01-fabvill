using Microsoft.Maui.Controls;

namespace MauiApp5
{
    [QueryProperty(nameof(AstroName), "astroName")]
    public partial class AstronomicalBodyPage : ContentPage
    {
        string astroName;
        public string AstroName
        {
            get => astroName;
            set
            {
                astroName = value;
                UpdateAstroBodyUI(astroName); 
            }
        }

        public AstronomicalBodyPage()
        {
            InitializeComponent();
        }
        private void UpdateAstroBodyUI(string astroName)
        {
            DisplayAlert("Astronomical Body", $"Displaying details for {astroName}", "OK");
           
        }
    }
}
