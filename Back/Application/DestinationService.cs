

using System;
using System.Threading.Tasks;
using Application.IServices;
using Domain;
using Persistence.Contratos;

namespace Application
{
    public class DestinationService:IDestinationService

    {
    private readonly IDestinationPersist _destinationPersist;
    private readonly IGeralPersist _geralPersist;

    public DestinationService(IDestinationPersist destinationPersist, IGeralPersist geralPersist)
    {
        _destinationPersist = destinationPersist;
        _geralPersist = geralPersist;
    }

    public async Task<Destination> AddDestination(Destination model)
    {
        try
        {
            _geralPersist.Add(model);
            if (await _geralPersist.SaveChangesAsync()) ;
            return await _destinationPersist.GetDestinationById(model.Id);
            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Destination> UpdateDestination(int destinationId, Destination model)
    {
        try
        {
            var destination = await _destinationPersist.GetDestinationById(destinationId);
            if (destination is null) 
                throw  new  Exception("No Destination Type with that Id");
            _geralPersist.Update(model);
            if (await _geralPersist.SaveChangesAsync())
            {
                return await _destinationPersist.GetDestinationById(model.Id);
            }

            return null;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> DeleteDestination(int destinationId)
    {
        try
        {
            var destination = await _destinationPersist.GetDestinationById(destinationId);
            if (destination is null) 
                throw  new  Exception("No Destination Type with that Id");
            _geralPersist.Delete(destination);
            return await _geralPersist.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Destination[]> GetAllDestinationsAsync()
    {
        try
        {
            var destinations = await _destinationPersist.GetAllDestinations();
            if (destinations is null) return null;
            return destinations;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Destination[]> GetAllDestinationByNameAsync(string name)
    {
        try
        {
            var destinations = await _destinationPersist.GetDestinationByDescription(name);
            if (destinations is null) return null;
            return destinations;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Destination> GetDestinationByIdAsync(int destinationId)
    {
        try
        {
            var destinations = await _destinationPersist.GetDestinationById(destinationId);
            if (destinations is null) return null;
            return destinations;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
    }
}