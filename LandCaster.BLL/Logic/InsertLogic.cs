using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    
        public class InsertLogic : IInsertLogic
        {
            private readonly IUnitOfWork _unitOfWork;

            public InsertLogic(IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
            }
            public async Task<PaginationResponse<Insert>> GetInsertAsync(PaginationDTO parameters)
            {
                var term = parameters.Parameters["term"].ToString();

                if (term == null) term = "";

                var insert = _unitOfWork.Insert.PaginateGetAsync(
                    parameters: parameters,
                    i => (i.Name.Contains(term)) ||
                      (string.IsNullOrEmpty(term) || i.Code.Contains(term)),
                    orderBy: null,
                    relationships: "DoorModelInserts.DoorModel",
                    isTracking: false
                );


                var paginationResponse = await PaginationHelper.CreatePaginationResponse(insert, parameters.PageNumber);

                return paginationResponse;
            }

            public async Task<Insert> AddInsertAsync(Insert insert)

            {
                // Puedes realizar validaciones adicionales aquí antes de agregar el color, si es necesario.

                var createdInsert = _unitOfWork.Insert.Create(insert);
                await _unitOfWork.Save();

                return insert;
            }

            public async Task<Insert> UpdateInsertAsync(int id, Insert insert)
            {
                _unitOfWork.Insert.Update(insert);
                await _unitOfWork.Save();
                return insert;
            }

            public async Task<Insert> DeleteInsertAsync(int id)
            {
                var insert = await _unitOfWork.Insert.Find(id);

            insert.DeletedAt = DateTime.UtcNow;
                _unitOfWork.Insert.Update(insert);
                await _unitOfWork.Save();
                return insert;
            }
        }
    
}
