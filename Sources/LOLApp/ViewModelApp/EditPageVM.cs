using System.Windows.Input;
using ViewModel;

namespace LOLApp.ViewModelApp
{
    public class EditPageVM : PropertyChange
    {

        public ChampionVM ChampionVM { get; set; }
        
        public ICommand ValidCommand { get; private set; }
        public INavigation Navigation { get; set; }

        public EditPageVM(ChampionVM championVM, INavigation navigation)
        {
            ChampionVM = championVM;
            Navigation = navigation;
            ValidCommand = new Command(
                execute: async () => await ValidChampion(),
                canExecute: () => ChampionVM != null
            );
        }

        private async Task ValidChampion()
        {
            await Navigation.PopAsync();
        }

    }
}