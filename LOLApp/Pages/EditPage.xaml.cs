using ViewModel;
using ViewModelApp;

namespace LOLApp.Pages;

public partial class EditPage : ContentPage
{

    public EditPageVM EditPageVM;

    public ChampionVM ChampionVM;

    public EditPage(ChampionVM championVM)
    {
        ChampionVM = championVM;
        EditPageVM = new EditPageVM(ChampionVM);
        InitializeComponent();
        BindingContext = EditPageVM;
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }
}