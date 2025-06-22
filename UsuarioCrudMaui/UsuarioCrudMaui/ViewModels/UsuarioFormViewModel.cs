using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using UsuarioCrudMaui.Models;
using UsuarioCrudMaui.Services;
using Microsoft.Maui.Controls;

namespace UsuarioCrudMaui.ViewModels;

[QueryProperty(nameof(Id), "Id")]
public class UsuarioFormViewModel : BaseViewModel
{
    readonly UsuarioService service = new();

    int id;
    public int Id
    {
        get => id;
        set
        {
            if (SetProperty(ref id, value))
            {
                _ = LoadAsync();
            }
        }
    }

    string nome = "";
    public string Nome
    {
        get => nome;
        set => SetProperty(ref nome, value);
    }

    string telefone = "";
    public string Telefone
    {
        get => telefone;
        set => SetProperty(ref telefone, value);
    }

    string senha = "";
    public string Senha
    {
        get => senha;
        set => SetProperty(ref senha, value);
    }

    public ICommand SaveCommand { get; }

    public UsuarioFormViewModel()
    {
        Title = "Cadastro";
        SaveCommand = new AsyncRelayCommand(SaveAsync);
    }
    async Task LoadAsync()
    {
        if (Id == 0)
            return;

        IsBusy = true;
        try
        {
            var u = await service.GetByIdAsync(Id);
            Nome = u.Nome;
            Telefone = u.Telefone;
            Senha = u.Senha;
        }
        finally
        {
            IsBusy = false;
        }
    }

    async Task SaveAsync()
    {
        IsBusy = true;
        try
        {
            var u = new Usuario
            {
                Id = Id,
                Nome = Nome,
                Telefone = Telefone,
                Senha = Senha
            };

            if (Id == 0)
                await service.CreateAsync(u);
            else
                await service.UpdateAsync(u);
        }
        finally
        {
            IsBusy = false;
        }

        await Shell.Current.GoToAsync("..");
    }
}
