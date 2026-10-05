using CalculateurAge.Views;

namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnCalculerClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(entryNom.Text))
        {
            DisplayAlert("Erreur", "Entrez un nom", "OK");
            return;
        }

        System.DateTime d = pickerDate.Date ?? System.DateTime.Today;

        int age = System.DateTime.Today.Year - d.Year;

        if (d.Date > System.DateTime.Today.AddYears(-age))
            age--;

        await Shell.Current.GoToAsync(
            $"{nameof(ResultatPage)}?nom={entryNom.Text}&age={age}");
    }
}