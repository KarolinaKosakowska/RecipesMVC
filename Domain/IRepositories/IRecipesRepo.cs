using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
     public interface IRecipesRepo
    {
        Task <RecipesDTO> Add(RecipesDTO item);
        Task <bool> Update(RecipesDTO item);
        Task <bool> Delete(int id);
        Task <RecipesDTO> Get(int id);
        Task <List<RecipesDTO>> GetList();
    }
}
