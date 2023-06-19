using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Model;

namespace ViewModel
{
	public class ManagerVM : PropertyChange
    {
		public ReadOnlyObservableCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> _champions { get; set; } = new ObservableCollection<ChampionVM>();

        public ICommand NextPageCommand { get; private set; }
        public ICommand PreviousPageCommand { get; private set; }
        public ICommand LoadChampionsCommand { get; private set; }

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
            DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
            PropertyChanged += ManagerVM_PropertyChanged;

            LoadChampionsCommand = new Command(
                execute: async () => await LoadChampions(),
                canExecute: () => DataManager != null
            );

            NextPageCommand = new Command(
                execute: NextPageAction,
                canExecute: () => CanNextPage()
                );

            PreviousPageCommand = new Command(
                execute: PreviousPageAction,
                canExecute: () => CanPreviousPage()
                );

        }

        public int Index
        {
            get => index;
            set
            {
                if (index == value) return;
                index = value;
                OnPropertyChanged();
                (NextPageCommand as Command)?.ChangeCanExecute();
                (PreviousPageCommand as Command)?.ChangeCanExecute();
            }

        }
        private int index = 1;

        public int Count
        {
            get => count;
            set
            {
                if (count == value) return;
                count = value;
                OnPropertyChanged();
            }
        }
        private int count;

        public int NbParPage { get; set; } = 5;

        private void NextPageAction()
        {
            Index++;
            LoadChampions();
        }

        private void PreviousPageAction()
        {
            Index--;
            LoadChampions();
        }

        private async Task LoadChampions()
        {
			_champions.Clear();
            Count = await DataManager.ChampionsMgr.GetNbItems();
            IEnumerable<Champion> modelChampions = await DataManager.ChampionsMgr.GetItems(Index - 1, NbParPage);
            
            foreach (var champion in modelChampions)
            {
				_champions.Add(new ChampionVM(champion));
			}

            OnPropertyChanged(nameof(Champions));
        }

        private async void ManagerVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Index))
            {
                await LoadChampions();
            }
        }

        private bool CanNextPage()
        {
            return Count - (NbParPage * (Index - 1)) > NbParPage;
        }

        private bool CanPreviousPage()
        {
            return Index > 1;
        }

    }
}

