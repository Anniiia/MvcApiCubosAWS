using MvcApiCubosAWS.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace MvcApiCubosAWS.Services
{
    public class ServiceApiCubos
    {
        private MediaTypeWithQualityHeaderValue header;

        private string UrlApi;

        public ServiceApiCubos(IConfiguration configuration)
        {
            this.UrlApi = configuration.GetValue<string>("ApiUrls:ApiCubos");
            this.header = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<List<Cubo>> GetCubosAsync()
        {

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    string request = "";
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Cubo> cubos = await response.Content.ReadAsAsync<List<Cubo>>();

                        return cubos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }

        public async Task<Cubo> FindCuboAsync(int id)
        {

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    string request = "find/"+id;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                    if (response.IsSuccessStatusCode)
                    {
                        Cubo cubos = await response.Content.ReadAsAsync<Cubo>();

                        return cubos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }

        public async Task CreateCuboAsync(string nombre, string marca,string imagen, int precio)
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    //string request = "api/personajes";
                    string request = "post";
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    Cubo cubo = new Cubo
                    {
                        IdCubo = 0,
                        Nombre = nombre,
                        Marca = marca,
                        Imagen = imagen,
                        Precio = precio
                    };

                    string json = JsonConvert.SerializeObject(cubo);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(this.UrlApi + request, content);
                }
            }

        }

        public async Task UpdateCuboAsync(int id, string nombre, string marca,string imagen, int precio)
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    //string request = "api/personajes";
                    string request = "put";
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    Cubo cubo = new Cubo
                    {
                        IdCubo = id,
                        Nombre = nombre,
                        Marca = marca,
                        Imagen = imagen, 
                        Precio = precio
                    };

                    string json = JsonConvert.SerializeObject(cubo);
                    StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PutAsync(this.UrlApi + request, content);
                }
            }

        }

        public async Task<List<string>> GetMarcasAsync()
        {

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    string request = "marcas";
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                    if (response.IsSuccessStatusCode)
                    {
                        List<string> marcas = await response.Content.ReadAsAsync<List<string>>();

                        return marcas;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }

        public async Task<List<Cubo>> GetCubosMarcaAsync(string marca)
        {

            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    string request = "/marcas/"+marca;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    HttpResponseMessage response = await client.GetAsync(this.UrlApi + request);
                    if (response.IsSuccessStatusCode)
                    {
                        List<Cubo> cubos = await response.Content.ReadAsAsync<List<Cubo>>();

                        return cubos;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

        }

        public async Task DeleteCuboAsync(int id)
        {
            using (HttpClientHandler handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicies) =>
                {
                    return true;
                };
                using (HttpClient client = new HttpClient(handler))
                {
                    //string request = "api/personajes";
                    string request = "delete/"+id;
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(this.header);
                    HttpResponseMessage response = await client.DeleteAsync(this.UrlApi + request);
                }
            }

        }
    }
}
