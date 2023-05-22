using ViewModel;

namespace LOLApp.Pages;

public partial class Champions : ContentPage
{
	public ChampionMgrVM ChampionMgr { get; private set; }

	public Champions(ChampionMgrVM cmvm)
	{
		ChampionMgr = cmvm;
		InitializeComponent();
		BindingContext = ChampionMgr;
	}
}
