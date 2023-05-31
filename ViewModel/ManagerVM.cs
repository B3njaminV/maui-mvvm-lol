﻿using System;
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
			DataManager = dataManager;
			Champions = new ReadOnlyObservableCollection<ChampionVM>(_champions);
			PropertyChanged += ManagerVM_PropertyChanged;
		}

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
			_champions.Clear();
			int nbItems = await DataManager.ChampionsMgr.GetNbItems();
			IEnumerable<Champion> modelChampions = await DataManager.ChampionsMgr.GetItems(0, nbItems);

			foreach (var champion in modelChampions)
            {
				_champions.Add(new ChampionVM(champion));
			}
        }

    }
}
