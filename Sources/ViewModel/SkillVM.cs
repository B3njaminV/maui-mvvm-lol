using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SkillVM : PropertyChange
    {

        public SkillVM(Skill model)
        {
            Model = model;
        }

        private Skill _model;
        public Skill Model
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

        public SkillType Type { get => Model.Type; }

        public string Name
        {
            get => Model.Name;
        }

        public string Description
        {
            get => Model.Description;
            set
            {
                if (_model.Description.Equals(value)) return;
                _model.Description = value;
                OnPropertyChanged();
            }
        }

    }
}
