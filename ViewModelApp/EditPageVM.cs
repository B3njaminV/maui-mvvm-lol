using System.Windows.Input;
using ViewModel;

namespace ViewModelApp
{
    public class EditPageVM : PropertyChange
    {

        public ChampionVM ChampionVM { get; set; }

        public EditPageVM(ChampionVM championVM)
        {
            this.ChampionVM = championVM;

        }

    }
}