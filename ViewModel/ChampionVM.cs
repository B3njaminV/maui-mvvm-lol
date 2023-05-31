using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ChampionVM : INotifyPropertyChanged
{
    public ChampionVM(Champion model)
    {
        _model = model;
    }

    public ChampionVM()
    {
        _model = new Champion("Heros", ChampionClass.Assassin);
    }

    private Champion _model;
    public Champion Model
    {
        get => _model;
        set
        {
            if (_model.Equals(value)) return;
            if (_model == null) return;
            _model = value;
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
            if (_model.Icon.Equals(value)) return;
            _model.Icon = value;
            OnPropertyChanged();
        }
    }

    public string Image
    {
        get => Model.Image.Base64;
        set
        {
            if (_model.Icon.Equals(value)) return;
            _model.Image.Base64 = value;
            OnPropertyChanged();
        }
    }

    public string Bio
    {
        get => Model.Bio;
        set
        {
            if (_model.Bio.Equals(value)) return;
            _model.Bio = value;
            OnPropertyChanged();
        }
    }

    public string Class { get => Model.Class.ToString(); }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

