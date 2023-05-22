using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ChampionVM : INotifyPropertyChanged
{
    public ChampionVM(Champion champion) => Model = champion;

    public ChampionVM() => Model = new Champion("Heros", ChampionClass.Assassin);

    private Champion model;
    public Champion Model
    {
        get => model;
        set
        {
            if (model.Equals(value)) return;
            if (model == null) return;
            model = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => Model.Name;
    }

    public string Icon
    {
        get => Model.Icon;
        set
        {
            if (model == null) return;
            Model.Icon = value;
            OnPropertyChanged();
        }
    }

    public LargeImage Image
    {
        get => Model.Image;
        set
        {
            if (model == null) return;
            Model.Image = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

