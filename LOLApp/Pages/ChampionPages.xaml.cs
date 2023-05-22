using ViewModel;

namespace LOLApp.Pages;

public partial class ChampionPages : ContentPage
{
	public ChampionMgrVM ChampionMgr { get; private set; }

	public ChampionPages(ChampionMgrVM cmvm)
	{
		ChampionMgr = cmvm;
		InitializeComponent();
		BindingContext = ChampionMgr;
	}
}
