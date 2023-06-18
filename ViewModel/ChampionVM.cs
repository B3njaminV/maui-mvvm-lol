using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Controls;
using Model;

namespace ViewModel;

public class ChampionVM : PropertyChange
{

    private ObservableCollection<CharacteristicVM> _characteristics { get; set; } = new ObservableCollection<CharacteristicVM>();
    public ObservableCollection<CharacteristicVM> Characteristics { get; private set; }
    private ObservableCollection<SkillVM> _skills { get; set; } = new ObservableCollection<SkillVM>();
    public ObservableCollection<SkillVM> Skills { get; private set; }

    public ChampionVM(Champion model)
    {
        _model = model;
    }

    public ChampionVM()
    {
        _model = new Champion("Heros", ChampionClass.Assassin);
        Characteristics = new ObservableCollection<CharacteristicVM>(_characteristics);
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
        _characteristics.Clear();
        foreach (var item in _model.Characteristics)
        {
            Characteristics.Add(new CharacteristicVM { Key = item.Key, Value = item.Value });
        }
        OnPropertyChanged(nameof(Characteristics));
    }

    private async Task LoadSkill()
    {
        _skills.Clear();
        foreach (var item in Model.Skills)
        {
            _skills.Add(new SkillVM(item));
        }
    }

    public void AddCharacteristic(Tuple<string, int> characteristic)
    {
        Model.AddCharacteristics(characteristic);
        LoadCharacteristic();
    }

    public void AddSkill(string name)
    {
        Model.AddSkill(new Skill(name, SkillType.Unknown, "Une simple description"));
        LoadSkill();
    }
}

