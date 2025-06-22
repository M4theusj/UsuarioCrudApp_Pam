using Newtonsoft.Json;
using UsuarioCrudMaui.Models;

namespace UsuarioCrudMaui.Services;

public class UsuarioService : Request
{
    const string baseUrl = "https://usuariocrudpam-drg8c3fredhjg2cg.brazilsouth-01.azurewebsites.net/api/usuarios";

    public async Task<List<Usuario>> GetAllAsync()
        => JsonConvert.DeserializeObject<List<Usuario>>(
               await GetAsync(baseUrl))!;

    public async Task<Usuario> GetByIdAsync(int id)
        => JsonConvert.DeserializeObject<Usuario>(
               await GetAsync($"{baseUrl}/{id}"))!;

    public async Task<Usuario> CreateAsync(Usuario u)
        => await PostAsync<Usuario>(baseUrl, u);

    public async Task UpdateAsync(Usuario u)
        => await PutAsync($"{baseUrl}/{u.Id}", u);

    public async Task DeleteAsync(int id)
        => await DeleteAsync($"{baseUrl}/{id}");
}
