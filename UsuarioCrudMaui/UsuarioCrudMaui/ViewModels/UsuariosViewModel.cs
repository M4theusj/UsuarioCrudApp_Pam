using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using UsuarioCrudMaui.Models;
using UsuarioCrudMaui.Services;
using UsuarioCrudMaui.Views;

namespace UsuarioCrudMaui.ViewModels;

public class UsuariosViewModel : BaseViewModel
{
    readonly UsuarioService service = new();

    public ObservableCollection<Usuario> Usuarios { get; } = new();

    Usuario? selected;
    public Usuario? Selected
    {
        get => selected;
        set { selected = value; OnPropertyChanged(); }
    }

    public ICommand LoadCommand { get; }
    public ICommand AddCommand { get; }
    public ICommand EditCommand { get; }
    public ICommand DeleteCommand { get; }

    public UsuariosViewModel()
    {
        Title = "Usuários";
        LoadCommand = new AsyncRelayCommand(LoadAsync);
        AddCommand = new AsyncRelayCommand(AddAsync);
        EditCommand = new AsyncRelayCommand<Usuario>(EditAsync);
        DeleteCommand = new AsyncRelayCommand<Usuario>(DeleteAsync);
    }

    async Task LoadAsync()
    {
        if (IsBusy) return;
        IsBusy = true;
        try
        {
            Usuarios.Clear();
            var list = await service.GetAllAsync();
            foreach (var u in list) Usuarios.Add(u);
        }
        finally { IsBusy = false; }
    }

    async Task AddAsync()
        => await Shell.Current.GoToAsync(nameof(Views.UsuarioFormPage));

    async Task EditAsync(Usuario u)
    {
        if (u == null) return;
        await Shell.Current.GoToAsync($"{nameof(Views.UsuarioFormPage)}?Id={u.Id}");
    }

    async Task DeleteAsync(Usuario u)
    {
        if (u == null) return;
        await service.DeleteAsync(u.Id);
        await LoadAsync();
    }   
}
