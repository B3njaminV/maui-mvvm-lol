using ViewModel;

namespace LOLApp.Pages;

public partial class ChampionPage : ContentPage
{

    public ManagerVM ManagerVM { get; private set; }

	public ChampionPage(ManagerVM managerVM)
	{
        ManagerVM = managerVM;
		InitializeComponent();
		BindingContext = ManagerVM;
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        await Navigation.PushAsync(new DetailPage((sender as CollectionView).SelectedItem as ChampionVM));
    }
}
