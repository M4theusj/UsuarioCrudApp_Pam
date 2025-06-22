using Microsoft.Maui.Controls;
using UsuarioCrudMaui.ViewModels;

namespace UsuarioCrudMaui.Views;

public partial class UsuarioFormPage : ContentPage
{
    public UsuarioFormPage(UsuarioFormViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    void OnBackClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }
}
