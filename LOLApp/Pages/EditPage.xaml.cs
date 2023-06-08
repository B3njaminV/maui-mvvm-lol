using ViewModel;

namespace LOLApp.Pages;

public partial class EditPage : ContentPage
{

    public static readonly BindableProperty TitreProperty =
    BindableProperty.Create("Title", typeof(string), typeof(DetailPage), "", BindingMode.OneWay);

    public string Titre
    {
        get => (string)GetValue(TitreProperty);
        set => SetValue(TitreProperty, value);
    }

    public ChampionVM ChampionVM;

    public EditPage(ChampionVM championVM)
    {
        ChampionVM = championVM;
        InitializeComponent();
        BindingContext = ChampionVM;
    }

}