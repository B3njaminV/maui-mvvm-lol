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

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EditPage(ChampionVM));
    }
}