using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace UsuarioCrudMaui.ViewModels;

public class BaseViewModel : ObservableObject
{
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    bool isBusy;
    public bool IsBusy
    {
        get => isBusy;
        set { isBusy = value; OnPropertyChanged(); }
    }

    string title = string.Empty;
    public string Title
    {
        get => title;
        set { title = value; OnPropertyChanged(); }
    }
}
