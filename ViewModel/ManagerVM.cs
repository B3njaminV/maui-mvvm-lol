using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
	public class ManagerVM : INotifyPropertyChanged
	{
		public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> _champions { get; set; } = new ObservableCollection<ChampionVM>();

        public IDataManager DataManager
        {
            get => _dataManager;
            set
            {
                if (_dataManager == value) return;
                _dataManager = value;
                OnPropertyChanged();
                LoadChampions();
            }
        }
        private IDataManager _dataManager;

		public ManagerVM(IDataManager dataManager)
		{
            //PrevPage = new Command(PreviousPageAction);
            //NextPage = new Command(NextPageAction);
            DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
			PropertyChanged += ManagerVM_PropertyChanged;
		}

        //public ICommand PrevPage { get; }
//        public ICommand NextPage { get; }

        private async void ManagerVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == nameof(Index))
			{
				await LoadChampions();
			}
		}

		public int Index
		{
			get => index;
			set
			{
				if (index == value) return;
				index = value;
				OnPropertyChanged();
			}
		}
		private int index = 0;

		public int Count
		{
			get;
			set;
		} = 5;

        private async void PreviousPageAction()
        {

            Console.WriteLine("===> Previous page clicked");

            if (index > 0)
            {
                index = index - 1;
            }
            _champions.Clear();
            await LoadChampions();
        }
        private async void NextPageAction()
        {

            Console.WriteLine("===> Next page clicked");

            index = index + 1;
            _champions.Clear();
            await LoadChampions();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadChampions()
        {
			_champions.Clear();
			int nbItems = await DataManager.ChampionsMgr.GetNbItems();
            //IEnumerable<Champion> modelChampions = await DataManager.ChampionsMgr.GetItems(0, nbItems);
            IEnumerable<Champion> modelChampions = await DataManager.ChampionsMgr.GetItems(Index, Count);
            foreach (var champion in modelChampions)
            {
				_champions.Add(new ChampionVM(champion));
			}
        }

    }
}

