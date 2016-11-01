using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SPA.Models
{
    public class UserRepository : IRepository<User>
    {
        const string Url = "http://localhost:53720/api/Users/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task Create(User item)
        {
            using (HttpClient client = GetClient())
            {
                var response = await client.PostAsync(Url,
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8, "application/json"));


                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось создать пользователя");
            }
        }

        public async Task Delete(int id)
        {
            using (HttpClient client = GetClient())
            {
                var response = await client.DeleteAsync(Url + id);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось удалить пользователя");
            }
        }

        public async Task<User> Get(int id)
        {
            using (HttpClient client = GetClient())
            {
                var result = await client.GetAsync(Url + id.ToString());
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;
                return JsonConvert.DeserializeObject<User>(await result.Content.ReadAsStringAsync());
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (HttpClient client = GetClient())
            {
                var result = await client.GetAsync(Url);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;
                return JsonConvert.DeserializeObject<IEnumerable<User>>(await result.Content.ReadAsStringAsync());
            }
        }

        public async Task Update(User item)
        {
            using (HttpClient client = GetClient())
            {
                var response =await client.PutAsync(Url + item.Id,
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось обновить пользователя");
            }
        }
    }
}