using LOLApp.ViewModelApp;
using ViewModel;

namespace LOLApp.Pages;

public partial class EditPage : ContentPage
{

    public EditPageVM EditPageVM;

    public EditPage(ChampionVM championVM)
    {
        EditPageVM = new EditPageVM(championVM, Navigation);
        InitializeComponent();
        BindingContext = EditPageVM;
    }

}