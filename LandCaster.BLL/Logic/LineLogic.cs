using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class LineLogic : ILineLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public LineLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PaginationResponse<Line>> GetLinesAsync(PaginationDTO parameters)
        {
            var term = parameters.Parameters.ContainsKey("term") ? parameters.Parameters["term"].ToString() : "";
            Func<IQueryable<Line>, IOrderedQueryable<Line>>? orderBy = null;

            // Determina el campo de ordenación y la dirección
            string? orderByField = parameters.Parameters.ContainsKey("orderBy") ? parameters.Parameters["orderBy"].ToString() : "";
            bool? orderByAsc = parameters.Parameters.ContainsKey("orderByAsc") ? bool.Parse(parameters.Parameters["orderByAsc"].ToString()) : bool.Parse("true");
            bool? withTrashed = parameters.Parameters.ContainsKey("withTrashed") ?
                (bool.TryParse(parameters.Parameters["withTrashed"].ToString(), out bool parsedValue) ? parsedValue : (bool?)null)
                : (bool?)true;

            Func<IQueryable<Line>, IOrderedQueryable<Line>>? value = orderByField switch
            {
                "name" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Name) : query.OrderByDescending(c => c.Name),
                "id" => query => Convert.ToBoolean(orderByAsc) ? query.OrderBy(c => c.Id) : query.OrderByDescending(c => c.Id),
                _ => null
            };

            orderBy = value;
            var lines = _unitOfWork.Line.PaginateGetAsync(
              parameters: parameters,
              filter: line => string.IsNullOrEmpty(term) || line.Name.Contains(term),
              orderBy: orderBy,
              relationships: "",
              isTracking: false
          );

            var paginationResponse = await PaginationHelper.CreatePaginationResponse(lines, parameters.PageNumber);

            return paginationResponse;

        }



        public async Task<Line> AddLineAsync(Line line)
        {
            var createColor = _unitOfWork.Line.Create(line);
            await _unitOfWork.Save();

            return line;
        }

        public async Task<Line> DeleteLineAsync(int id)
        {
            var line = await _unitOfWork.Line.Find(id);

            line.DeletedAt = DateTime.UtcNow;
            _unitOfWork.Line.Update(line);
            await _unitOfWork.Save();
            return line;
        }

        public async Task<Line> UpdateLineAsync(int id, Line line)
        {
            _unitOfWork.Line.Update(line);
            await _unitOfWork.Save();
            return line;
        }
    }
}
