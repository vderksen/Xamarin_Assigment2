using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace dogForYou.Model
{
    public class NetworkingManager
    {
        private string url = "https://api.thedogapi.com/v1";
        private HttpClient client = new HttpClient();

        public async Task<IEnumerable<BreedData>> GetAllBreeds()
        {
            var response = await client.GetStringAsync(url + "/breeds");
            return JsonConvert.DeserializeObject<List<BreedData>>(response);
        }

        public async Task<IEnumerable<RandomBreed>> GetRandomBreed()
        {
            var response = await client.GetStringAsync(url + "/images/search?limit=1?has_breeds=true");
            var result = JsonConvert.DeserializeObject<List<RandomBreed>>(response);
            return result;

        }


    }
}
