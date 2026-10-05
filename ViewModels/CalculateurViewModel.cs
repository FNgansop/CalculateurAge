namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    // Contient l'ÉTAT de l'écran et les ACTIONS possibles.

    // Champs privés : la vraie donnée.
    private string _nom = "";
    private DateTime _dateNaissance =
        DateTime.Today.AddYears(-20);
    private string _resultat = "";
    private bool _resultatVisible;
    private string _message = "";
    private int _joursRestants;

    // Propriétés publiques : ce que le XAML voit.
    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
                CalculerCommand.Rafraichir();
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    public string Message
    {
        get => _message;
        set => SetField(ref _message, value);
    }

    public int JoursRestants
    {
        get => _joursRestants;
        set => SetField(ref _joursRestants, value);
    }

    // Lié à Button.Command dans le XAML.
    public RelayCommand CalculerCommand { get; }
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(
            Calculer,
            () => !string.IsNullOrWhiteSpace(Nom));

        EffacerCommand = new RelayCommand(Effacer);
    }

    // La logique métier : aucun contrôle d'interface ici.
    private void Calculer()
    {
        int age = DateTime.Today.Year - DateNaissance.Year;

        if (DateNaissance.Date >
            DateTime.Today.AddYears(-age))
            age--;

        Resultat = $"{Nom}, vous avez {age} ans";
        ResultatVisible = true;

        Message = age >= 18 ? "Majeur" : "Mineur";

        DateTime prochainAnniversaire =
            new DateTime(DateTime.Today.Year,
                DateNaissance.Month,
                DateNaissance.Day);

        if (prochainAnniversaire < DateTime.Today)
            prochainAnniversaire =
                prochainAnniversaire.AddYears(1);

        JoursRestants =
            (prochainAnniversaire - DateTime.Today).Days;
    }

    private void Effacer()
    {
        Nom = "";
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = "";
        ResultatVisible = false;
        Message = "";
        JoursRestants = 0;
    }
}