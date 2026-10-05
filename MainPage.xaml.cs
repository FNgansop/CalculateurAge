namespace CalculateurAge;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnCalculerClicked(object sender, EventArgs e)
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

        lblResultat.Text = $"{entryNom.Text}, vous avez {age} ans";
        lblResultat.IsVisible = true;
    }
}