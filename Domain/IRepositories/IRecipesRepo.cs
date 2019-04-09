using Domain.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepositories
{
    interface IRecipesRepo
    {
        RecipesDTO Add(RecipesDTO item);
        bool Update(RecipesDTO item);
        bool Delete(RecipesDTO item);
        RecipesDTO Get(int id);
        List<RecipesDTO> GetList();
    }
}
