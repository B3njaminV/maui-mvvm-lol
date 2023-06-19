using LOLApp.Pages;
using System.Windows.Input;
using ViewModel;

namespace LOLApp.ViewModelApp
{
    public class ChampionPageVM
    {

        public INavigation Navigation { get; set; }
        public ICommand SelectChampionCommand { get; private set; }
        public ICommand DeleteChampionCommand { get; private set; }

        public ManagerVM ManagerVM { get; set; }   

        public ChampionPageVM(ManagerVM managerVM, INavigation navigation)
        {
            ManagerVM = managerVM;
            Navigation = navigation;

            SelectChampionCommand = new Command<ChampionVM>(
                execute: async (selectedChampion) => await SelectChampion(selectedChampion),
                canExecute: selectedChampion => ManagerVM is not null && selectedChampion is not null
            );

            DeleteChampionCommand = new Command<ChampionVM>(
                execute: async (selectedChampion) => await SelectChampion(selectedChampion),
                canExecute: selectedChampion => ManagerVM is not null && selectedChampion is not null
            );
        }

        private async Task SelectChampion(ChampionVM selectedChampion)
        {
            await Navigation.PushAsync(new DetailPage(selectedChampion));
        }
    }
}
