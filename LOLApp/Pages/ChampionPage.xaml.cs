using LOLApp.ViewModelApp;
using ViewModel;

namespace LOLApp.Pages;

public partial class ChampionPage : ContentPage
{
    public ChampionPageVM ChampionPageVM { get; private set; }

	public ChampionPage(ManagerVM managerVM)
	{
        // Injection de dépendance
        // On vérifie dans les services si on a une instance de ManagerVM
        // Ici, on a en une (unique) donc on l'a récupère pour l'injecter dans ChampionPageVM
        ChampionPageVM = new ChampionPageVM(managerVM, Navigation);
		InitializeComponent();
		BindingContext = ChampionPageVM;
	}
}
