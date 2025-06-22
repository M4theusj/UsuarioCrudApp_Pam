using UsuarioCrudMaui.ViewModels;

namespace UsuarioCrudMaui.Views;

public partial class UsuariosPage : ContentPage
{
    public UsuariosPage(UsuariosViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        (BindingContext as UsuariosViewModel)?.LoadCommand.Execute(null);
    }
}
