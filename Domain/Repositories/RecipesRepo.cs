using Domain.IRepositories;
using Domain.Models.DTO;
using Newtonsoft.Json;
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
        const string RecipesUri = "Recipes";
        public RecipesRepo()
        {
            client.BaseAddress = new Uri("http://localhost:12033/api/");
            client.DefaultRequestHeaders
                .Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("api-key", "aaa");
        }
        public async Task<RecipesDTO> Add(RecipesDTO item)
        {
            try
            {
                var response = await client.PostAsJsonAsync(RecipesUri, item);
                if (response.IsSuccessStatusCode)
                {
                    return item;
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var response = await client.DeleteAsync($"{RecipesUri}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RecipesDTO> Get(int id)
        {
            var result = new RecipesDTO();
            try
            {
                var response = await client.GetAsync($"{RecipesUri}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<RecipesDTO>(content);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<List<RecipesDTO>> GetList()
        {
            var result = new List<RecipesDTO>();
            try
            {
                var response = await client.GetAsync(RecipesUri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<List<RecipesDTO>>(content);
                }
                else
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public async Task<bool> Update(RecipesDTO item)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"{RecipesUri}/{item.ID}",item);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
