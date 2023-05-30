using ViewModel;

namespace LOLApp.Pages;

public partial class DetailPage : ContentPage
{
    public ChampionVM ChampionVM;

    public DetailPage(ChampionVM championVM)
    {
        ChampionVM = championVM;
        InitializeComponent();
        BindingContext = ChampionVM;
    }

}   