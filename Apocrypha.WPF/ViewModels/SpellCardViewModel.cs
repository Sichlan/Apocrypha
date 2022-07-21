using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;
using Apocrypha.CommonObject.Models.Spells;

namespace Apocrypha.WPF.ViewModels;

public class SpellCardViewModel : BaseViewModel
{
    private string _spellName;
    private string _casterClass;
    private int _spellLevel;
    private ObservableCollection<SpellSchool> _spellSchools = new ObservableCollection<SpellSchool>();
    private ObservableCollection<SpellSubSchool> _spellSubSchools = new ObservableCollection<SpellSubSchool>();
    private ObservableCollection<SpellDescriptor> _spellDescriptors = new ObservableCollection<SpellDescriptor>();

    public LinearGradientBrush BackgroundBrush
    {
        get
        {
            var value = new LinearGradientBrush()
            {
                StartPoint = new Point(0, 0.5),
                EndPoint = new Point(1, 0.5)
            };

            if (SpellSchools == null || SpellSchools.Count == 0)
            {
                value.GradientStops.Add(new GradientStop(GetSpellSchoolColor(9), 0));

                return value;
            }

            var offsetDistance = SpellSchools.Count > 1 ? 1d / (SpellSchools.Count - 1) : 0d;
            var offset = 0d;

            foreach (var spellSchool in SpellSchools.OrderBy(x => x.Id))
            {
                var stop = new GradientStop()
                {
                    Offset = offset,
                    Color = GetSpellSchoolColor(spellSchool.Id)
                };
                value.GradientStops.Add(stop);
                offset += offsetDistance;
            }

            return value;
        }
    }

    public string SpellName
    {
        get
        {
            return _spellName;
        }
        set
        {
            _spellName = value;
            OnPropertyChanged();
        }
    }

    public string CasterClass
    {
        get
        {
            return _casterClass;
        }
        set
        {
            _casterClass = value;
            OnPropertyChanged();
        }
    }

    public int SpellLevel
    {
        get
        {
            return _spellLevel;
        }
        set
        {
            _spellLevel = value;
            OnPropertyChanged();
        }
    }

    public string SpellSchoolString
    {
        get
        {
            return string.Join(',', SpellSchools.OrderBy(x => x.Id).Select(x => x.Name));
        }
    }

    public ObservableCollection<SpellSchool> SpellSchools
    {
        get
        {
            return _spellSchools;
        }
        set
        {
            _spellSchools = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(BackgroundBrush));
            OnPropertyChanged(nameof(SpellSchoolString));
        }
    }

    public string SpellSubSchoolString
    {
        get
        {
            return string.Join(',', SpellSubSchools.OrderBy(x => x.Id).Select(x => x.Name));
        }
    }

    public ObservableCollection<SpellSubSchool> SpellSubSchools
    {
        get
        {
            return _spellSubSchools;
        }
        set
        {
            _spellSubSchools = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SpellSubSchoolString));
        }
    }

    public string SpellDescriptorString
    {
        get
        {
            return string.Join(',', SpellDescriptors.OrderBy(x => x.Id).Select(x => x.Name));
        }
    }

    public ObservableCollection<SpellDescriptor> SpellDescriptors
    {
        get
        {
            return _spellDescriptors;
        }
        set
        {
            _spellDescriptors = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(SpellDescriptorString));
        }
    }

    /// <summary>
    /// Creates a SpellCardViewModel with filled values based on a SpellVariant.
    /// </summary>
    /// <param name="spellVariant"></param>
    public static SpellCardViewModel SpellCardFromSpellVariant(SpellVariant spellVariant)
    {
        var spellCardViewModel = new SpellCardViewModel();

        spellCardViewModel.SpellName = spellVariant.Spell.Name;
        spellCardViewModel.SpellSchools = new ObservableCollection<SpellSchool>(spellVariant.SpellSchools);
        spellCardViewModel.SpellSubSchools = new ObservableCollection<SpellSubSchool>(spellVariant.SpellSubSchools);
        spellCardViewModel.SpellDescriptors = new ObservableCollection<SpellDescriptor>(spellVariant.SpellDescriptors);

        return spellCardViewModel;
    }

    private Color GetSpellSchoolColor(int spellSchoolId)
    {
        byte r, g, b;

        switch (spellSchoolId)
        {
            case 1:
                r = 109;
                g = 196;
                b = 213;

                break;
            case 2:
                r = 180;
                g = 066;
                b = 135;

                break;
            case 3:
                r = 089;
                g = 050;
                b = 105;

                break;
            case 4:
                r = 057;
                g = 063;
                b = 125;

                break;
            case 5:
                r = 125;
                g = 191;
                b = 093;

                break;
            case 6:
                r = 216;
                g = 204;
                b = 068;

                break;
            case 7:
                r = 126;
                g = 068;
                b = 054;

                break;
            case 8:
                r = 053;
                g = 124;
                b = 084;

                break;
            default:
                r = 159;
                g = 159;
                b = 159;

                break;
        }

        return Color.FromArgb(255, r, g, b);
    }
}