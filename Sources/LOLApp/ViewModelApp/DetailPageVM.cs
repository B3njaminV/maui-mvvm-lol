using LOLApp.Pages;
using System.Windows.Input;
using ViewModel;

namespace LOLApp.ViewModelApp
{
    public class DetailPageVM : PropertyChange
    {

        public ChampionVM ChampionVM { get; set; }

        public ICommand ModifyCommand { get; private set; }
        public INavigation Navigation { get; set; }

        public DetailPageVM(ChampionVM championVM, INavigation navigation)
        {
            ChampionVM = championVM;
            Navigation = navigation;
            ModifyCommand = new Command(
                execute: async () => await ModifyChampion(),
                canExecute: () => ChampionVM != null
            );
        }

        private async Task ModifyChampion()
        {
            await Navigation.PushAsync(new EditPage(ChampionVM));
        }

    }
}
