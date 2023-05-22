using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel
{
	public class ChampionMgrVM : INotifyPropertyChanged
	{
		public IReadOnlyCollection<ChampionVM> Champions { get; private set; }
		private ObservableCollection<ChampionVM> champions = new ObservableCollection<ChampionVM>();

		private IDataManager DataManager { get; set; }

		public ChampionMgrVM(IDataManager dataManager)
		{
			DataManager = dataManager;
			Champions = new ReadOnlyCollection<ChampionVM>(champions);
			PropertyChanged += ChampionMgrVM_PropertyChanged;
		}

        private async void ChampionMgrVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(Index))
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
		private int index;

		public int Count
		{
			get;
			set;
		} = 5;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadChampions()
        {
			champions.Clear();
			var modelChampions = await DataManager.ChampionsMgr.GetItems(Index, Count);
            foreach (var n in modelChampions)
            {
				champions.Add(new ChampionVM(n));

			}
        }

    }
}

