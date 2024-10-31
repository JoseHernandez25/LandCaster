using LandCaster.BLL.helpers;
using LandCaster.BLL.ILogic;
using LandCaster.DAL.Migrations;
using LandCaster.DAL.Repository.IRepository;
using LandCaster.Entities.DTOs;
using LandCaster.Entities.DTOs.Discounts;
using LandCaster.Entities.DTOs.DoorsModels;
using LandCaster.Entities.DTOs.Hinges;
using LandCaster.Entities.Entities;
using LandCaster.Entities.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LandCaster.BLL.Logic
{
    public class VolumeRangeLogic : IVolumeRangeLogic
    {
        private readonly IUnitOfWork _unitOfWork;

        public VolumeRangeLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
       

        public async Task<IEnumerable<VolumeRange>> GetVolumeRangeAsync()
        {
            var volumeRanges = await _unitOfWork.VolumeRange.Get(
                properties: "DiscountTypes",
                isTracking: false
            );
            return volumeRanges;
        }

        public async Task<IEnumerable<DiscountType>> GetDiscountTypeAsync()
        {
            var discountType = await _unitOfWork.DiscountType.Get(
                properties: "VolumeRanges",
                isTracking: false
            );
            return discountType;
        }




        public async Task<VolumeRange> AddVolumeRangeAsync(AddVolumeRangeDTO addVolumeRangeDTO)
        {
            //Obtener todos los registros de VolumeRange
            var volumeRanges = await _unitOfWork.VolumeRange.Get();

            if (addVolumeRangeDTO.VolumeRange.EndRange.HasValue &&
            addVolumeRangeDTO.VolumeRange.EndRange != -1 &&
            addVolumeRangeDTO.VolumeRange.EndRange < addVolumeRangeDTO.VolumeRange.StartRange)
            {
                throw new ArgumentException("El rango final no puede ser menor que el rango inicial");
            }

            // Filtrar los registros existentes para el DiscountType proporcionado
            var existingRanges = volumeRanges
                                 .Where(vr => vr.DiscountType == addVolumeRangeDTO.VolumeRange.DiscountType)
                                 .OrderBy(vr => vr.StartRange)
                                 .ToList();

            // Verificar que el nuevo rango no se sobreponga con rangos existentes
            foreach (var range in existingRanges)
            {
                if (addVolumeRangeDTO.VolumeRange.StartRange <= range.EndRange &&
                    addVolumeRangeDTO.VolumeRange.EndRange >= range.StartRange)
                {
                    throw new ArgumentException("Este rango ya existe");
                }

                //if (addVolumeRangeDTO.VolumeRange.StartRange <= range.StartRange &&
                //    addVolumeRangeDTO.VolumeRange.EndRange >= range.EndRange)
                //{
                //    throw new ArgumentException("El rango no puede comenzar antes que el último");
                //}
            }

            // Filtrar por DiscountType y encontrar el último registro con EndRange igual a -1, null
            var lastVolumeRange = existingRanges
                                  .Where(vr => vr.EndRange == -1 || vr.EndRange == null)
                                  .OrderByDescending(vr => vr.Id)
                                  .FirstOrDefault();

            if (lastVolumeRange != null)
            {
                //Actualizar el EndRange del último registro
                lastVolumeRange.EndRange = addVolumeRangeDTO.VolumeRange.StartRange - 1;

                //Validar que el nuevo EndRange no sea menor que StartRange
                if (lastVolumeRange.EndRange < lastVolumeRange.StartRange)
                {
                    throw new ArgumentException("El rango final no puede ser menor que el rango inicial");
                }

                var updateVolumeRangeDTO = new UpdateVolumenRangeDTO
                {
                    VolumeRange = lastVolumeRange,
                    DiscountTypesIds = lastVolumeRange.DiscountTypes.Select(dt => dt.Id).ToArray()
                };
                await _unitOfWork.VolumeRange.UpdateVolumeRangeAsync(lastVolumeRange.Id, updateVolumeRangeDTO);


            }
            var created = await _unitOfWork.VolumeRange.AddVolumeRangeAsync(addVolumeRangeDTO);

            if (addVolumeRangeDTO.VolumeRange.EndRange != -1)
            {
                var volumeRange = new VolumeRange();
                volumeRange.StartRange = addVolumeRangeDTO.VolumeRange.EndRange.Value + 1;
                volumeRange.EndRange = -1;
                volumeRange.DiscountType = addVolumeRangeDTO.VolumeRange.DiscountType;
                
                await _unitOfWork.VolumeRange.Create(volumeRange);
            }
            //Crear el nuevo registro

            await _unitOfWork.Save();

            return created;
        }



        public async Task<VolumeRange> UpdateVolumeRangeAsync(int id, UpdateVolumenRangeDTO updateVolumeRangeDTO)
        {
            var volumeRange = await _unitOfWork.VolumeRange.Fisrt(
                                filter: vr => vr.Id == id,
                                properties: "DiscountTypes",
                                isTracking: false);

            if (volumeRange == null)
            {
                throw new Exception("DoorModel not found.");
            }

            if (updateVolumeRangeDTO.VolumeRange != null)
            {
                volumeRange.EndRange = updateVolumeRangeDTO.VolumeRange.EndRange;
                volumeRange.StartRange = updateVolumeRangeDTO.VolumeRange.StartRange;
                volumeRange.DiscountType = updateVolumeRangeDTO.VolumeRange.DiscountType;


            }

            volumeRange.DiscountTypes.Clear();

            // Obtener los nuevos TypesBoxJourneys basados en los IDs proporcionados en updateDoorModelDTO
            var discountType = await _unitOfWork.DiscountType.Get(
                                            filter: tb => updateVolumeRangeDTO.DiscountTypesIds.Contains(tb.Id));

            // Agregar los nuevos TypesBoxJourneys al DoorModel
            foreach (var discountTypes in discountType)
            {
                volumeRange.DiscountTypes.Add(discountTypes);
            }


            _unitOfWork.VolumeRange.Update(volumeRange);

            await _unitOfWork.Save();

            return volumeRange;
        }

        //public async Task<VolumeRange> UpdateVolumeRangeAsync(int id, VolumeRange volumeRange)
        //{
        //    var volumeRangec = await _unitOfWork.VolumeRange.Fisrt(
        //                        filter: vr => vr.Id == id,
        //                        properties: "DiscountTypes",
        //                        isTracking: false);

        //    volumeRangec.DiscountTypes.ForEach(dt =>
        //    {
        //        dt.Value = 155;
        //    });


        //    if (volumeRangec == null)
        //    {
        //        throw new Exception("");
        //    }

        //    if (volumeRange != null)
        //    {
        //        volumeRange.EndRange = volumeRange.EndRange;
        //        volumeRange.StartRange = volumeRange.StartRange;
        //        volumeRange.DiscountType = volumeRange.DiscountType;


        //    }

        //    volumeRange.DiscountTypes.Clear();


        //    _unitOfWork.VolumeRange.Update(volumeRange);

        //    await _unitOfWork.Save();

        //    return volumeRange;
        //}


    }

}
