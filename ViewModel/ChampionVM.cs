using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Model;

namespace ViewModel;

public class ChampionVM : PropertyChange
{

    private Dictionary<string, int> _characteristic = new Dictionary<string, int>();
    public ObservableCollection<KeyValuePair<string, int>> Characteristic { get; set; }

    private ObservableCollection<SkillVM> _skills = new ObservableCollection<SkillVM>();

    public ObservableCollection<SkillVM> Skills { get; private set; }

    public ChampionVM(Champion model)
    {
        _model = model;
    }

    public ChampionVM()
    {
        _model = new Champion("Heros", ChampionClass.Assassin);
        Characteristic = new ObservableCollection<KeyValuePair<string, int>>(_characteristic);
        Skills = new ObservableCollection<SkillVM>(_skills);
        LoadCharacteristic();
        LoadSkill();
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

    private async Task LoadCharacteristic()
    {
        _characteristic.Clear();
        foreach (var item in _model.Characteristics)
        {
            Characteristic.Add(item);
        }
    }

    private async Task LoadSkill()
    {
        _skills.Clear();
        foreach (var item in Model.Skills)
        {
            _skills.Add(new SkillVM(item));
        }
    }
}

