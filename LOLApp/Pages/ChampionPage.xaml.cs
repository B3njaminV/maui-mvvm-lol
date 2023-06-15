using ViewModel;

namespace LOLApp.Pages;

public partial class ChampionPage : ContentPage
{

    public ManagerVM ManagerVM { get; private set; }

	public ChampionPage(ManagerVM managerVM)
	{
        // Injection de dépendance
        // On vérifie dans les services si on a une instance de ManagerVM
        // Ici, on a en une (unique) donc on l'a récupère
        ManagerVM = managerVM;
		InitializeComponent();
		BindingContext = ManagerVM;
	}

    private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        await Navigation.PushAsync(new DetailPage((sender as ListView).SelectedItem as ChampionVM));
    }
}
