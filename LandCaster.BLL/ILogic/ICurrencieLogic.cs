using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.ILogic
{
    public interface ICurrencieLogic
    {
        Task<List<Currencie>> GetCurrencieAsync();
        Task<Currencie> AddCurrencieAsync(Currencie Currencie);
    }
}
