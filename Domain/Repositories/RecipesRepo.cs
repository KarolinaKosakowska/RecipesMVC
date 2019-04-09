using Domain.IRepositories;
using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class RecipesRepo : IRecipesRepo
    {
        HttpClient client = new HttpClient();
        public RecipesRepo()
        {
            client.BaseAddress = new Uri("http://localhost:12033");
            client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api-key", "aaa");
        }
        public RecipesDTO Add(RecipesDTO item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(RecipesDTO item)
        {
            throw new NotImplementedException();
        }

        public RecipesDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<RecipesDTO>> GetList()
        {
            var result = new List<RecipesDTO>();
            var response = await client.GetAsync("/recipes");
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.Read<List<ProductHeaderValue>>();
            }
            return result;
        }

        public bool Update(RecipesDTO item)
        {
            throw new NotImplementedException();
        }
    }
}
