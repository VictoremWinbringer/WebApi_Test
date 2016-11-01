using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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

        public void Create(User item)
        {
            HttpClient client = GetClient();
            var response = client.PostAsync(Url,
                new StringContent(
                    JsonConvert.SerializeObject(item),
                    Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.StatusCode + " " + "Не удалось создать пользователя");
        }

        public void Delete(int id)
        {
            HttpClient client = GetClient();
            var response = client.DeleteAsync(Url  + id).Result;
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.StatusCode + " " + "Не удалось удалить пользователя");
        }

        public User Get(int id)
        {
            using (HttpClient client = GetClient())
            {
                var result = client.GetAsync(Url + id.ToString()).Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;
                return JsonConvert.DeserializeObject<User>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public IEnumerable<User> GetAll()
        {
            using (HttpClient client = GetClient())
            {
                var result = client.GetAsync(Url).Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;
                return JsonConvert.DeserializeObject<IEnumerable<User>>(result.Content.ReadAsStringAsync().Result);
            }
        }

        public void Update(User item)
        {
            HttpClient client = GetClient();
            var response = client.PutAsync(Url + item.Id,
                new StringContent(
                    JsonConvert.SerializeObject(item),
                    Encoding.UTF8, "application/json")).Result;

            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(response.StatusCode + " " + "Не удалось удалить пользователя");
        }
    }
}