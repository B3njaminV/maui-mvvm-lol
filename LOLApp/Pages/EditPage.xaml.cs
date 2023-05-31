using ViewModel;

namespace LOLApp.Pages;

public partial class EditPage : ContentPage
{
    public ChampionVM ChampionVM;

    public EditPage(ChampionVM championVM)
    {
        ChampionVM = championVM;
        InitializeComponent();
        BindingContext = ChampionVM;
    }

}