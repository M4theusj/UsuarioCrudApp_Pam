using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace UsuarioCrudMaui.Services;

public class Request
{
    public async Task<string> GetAsync(string uri)
    {
        using var http = new HttpClient();
        var res = await http.GetAsync(uri);
        var txt = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
            throw new Exception(txt);
        return txt;
    }

    public async Task<TResult> PostAsync<TResult>(string uri, object data)
    {
        using var http = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var res = await http.PostAsync(uri, content);
        var txt = await res.Content.ReadAsStringAsync();
        if (!res.IsSuccessStatusCode)
            throw new Exception(txt);
        return JsonConvert.DeserializeObject<TResult>(txt)!;
    }

    public async Task PutAsync(string uri, object data)
    {
        using var http = new HttpClient();
        var content = new StringContent(JsonConvert.SerializeObject(data));
        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        var res = await http.PutAsync(uri, content);
        if (!res.IsSuccessStatusCode)
            throw new Exception(await res.Content.ReadAsStringAsync());
    }

    public async Task DeleteAsync(string uri)
    {
        using var http = new HttpClient();
        var res = await http.DeleteAsync(uri);
        if (!res.IsSuccessStatusCode)
            throw new Exception(await res.Content.ReadAsStringAsync());
    }
}
