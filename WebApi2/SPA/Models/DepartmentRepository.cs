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
    public class DepartmentRepository : IRepository<Department>
    {
        const string Url = "http://localhost:53669/api/Departments/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<Department> Create(Department item)
        {
            using (HttpClient client = GetClient())
            {
                var response = await client.PostAsync(Url,
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8, "application/json"));


                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось создать Департамент");
             return   JsonConvert.DeserializeObject<Department>(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Delete(int id)
        {
            using (HttpClient client = GetClient())
            {
                var response = await client.DeleteAsync(Url + id);
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось удалить департамент");
            }
        }

        public async Task<Department> Get(int id)
        {
            using (HttpClient client = GetClient())
            {
                var result = await client.GetAsync(Url + id.ToString());
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return null;
                return JsonConvert.DeserializeObject<Department>(await result.Content.ReadAsStringAsync());
            }
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            using (HttpClient client = GetClient())
            {
                var result = await client.GetAsync(Url);
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                    return new List<Department>();
                return JsonConvert.DeserializeObject<IEnumerable<Department>>(await result.Content.ReadAsStringAsync());
            }
        }

        public async Task Update(Department item)
        {
            using (HttpClient client = GetClient())
            {
                var response = await client.PutAsync(Url + item.Id,
                    new StringContent(
                        JsonConvert.SerializeObject(item),
                        Encoding.UTF8, "application/json"));

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(response.StatusCode + " " + "Не удалось обновить департамент");
            }
        }
    }
}