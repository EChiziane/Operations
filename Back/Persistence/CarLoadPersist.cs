﻿using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Contextos;
using Persistence.Contratos;

namespace Persistence
{
    public class CarLoadPersist : ICarLoadPersist
    {
        private readonly OperationContext _context;

        public CarLoadPersist(OperationContext context)
        {
            _context = context;
        }


        public async Task<CarLoad[]> GetAllCarLoads(bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            IQueryable<CarLoad> query = _context.CarLoads.Include(car => car.Destination).Include(car => car.Person)
                .Include(car => car.Driver).Include(car => car.Material);
            query = query.AsNoTracking().OrderBy(carload => carload.Id);
            return await query.ToArrayAsync();
        }

        public Task<CarLoad> GetCarLoadById(int carloadId, bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            throw new System.NotImplementedException();
        }

        public async Task<CarLoad[]> GetCarLoadByMaterial(string material, bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            IQueryable<CarLoad> query = _context.CarLoads.Include(car => car.Destination).Include(car => car.Person)
                .Include(car => car.Driver).Include(car => car.Material);
            query = query.AsNoTracking().OrderBy(carload => carload.Id).Where(
                car => car.Material.MaterialType.Description == material);
            return await query.ToArrayAsync();
        }

        public async Task<CarLoad[]> GetCarLoadByDestination(string destination, bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            IQueryable<CarLoad> query = _context.CarLoads.Include(car => car.Destination).Include(car => car.Person)
                .Include(car => car.Driver).Include(car => car.Material);
            query = query.AsNoTracking().OrderBy(carload => carload.Id).Where(
                car => car.Destination.Description == destination);
            return await query.ToArrayAsync();
        }

        public async Task<CarLoad[]> GetCarLoadByDriver(string driver, bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            IQueryable<CarLoad> query = _context.CarLoads.Include(car => car.Destination).Include(car => car.Person)
                .Include(car => car.Driver).Include(car => car.Material);
            query = query.AsNoTracking().OrderBy(carload => carload.Id).Where(
                car => car.Driver.FistName == driver);
            return await query.ToArrayAsync();
        }

        public async Task<CarLoad[]> GetCarLoadByDate(string date, bool includeDestination = false
            , bool includePerson = false
            , bool includeDriver = false
            , bool includeMaterial = false)
        {
            IQueryable<CarLoad> query = _context.CarLoads.Include(car => car.Destination).Include(car => car.Person)
                .Include(car => car.Driver).Include(car => car.Material);
            query = query.AsNoTracking().OrderBy(carload => carload.Id).Where(
                car => car.Date.ToString() == date);
            return await query.ToArrayAsync();
        }
    }
}