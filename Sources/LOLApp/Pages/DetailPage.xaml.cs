using LOLApp.ViewModelApp;
using ViewModel;

namespace LOLApp.Pages;

public partial class DetailPage : ContentPage
{
    public DetailPageVM DetailPageVM;

    public DetailPage(ChampionVM championVM)
    {
        DetailPageVM = new DetailPageVM(championVM, Navigation);
        InitializeComponent();
        BindingContext = DetailPageVM;
    }  
}