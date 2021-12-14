using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTUDataEditor.ViewModels;

public class EnumFlagViewModel : ViewModelBase
{
    private object _EnumFlag = 0;
    public object EnumFlag
    {
        get => _EnumFlag;
        set => SetProperty(ref _EnumFlag, value, nameof(EnumFlag));
    }

    private bool _Selected = false;
    public bool Selected
    {
        get => _Selected;
        set
        {
            SetProperty(ref _Selected, value, nameof(Selected));
            SelectedChanged?.Invoke(this);
        }
    }

    private string _Name = "";
    public string Name
    {
        get => _Name;
        set => SetProperty(ref _Name, value, nameof(Name));
    }

    public event Action<EnumFlagViewModel>? SelectedChanged;
}
