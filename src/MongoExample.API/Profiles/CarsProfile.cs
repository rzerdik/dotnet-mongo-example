using AutoMapper;
using MongoExample.API.Dtos;
using MongoExample.API.Models;

namespace MongoExample.API.Profiles;

public class CarsProfile : Profile
{
    public CarsProfile()
    {
        _ = CreateMap<Car, CarReadDto>();
        _ = CreateMap<CarCreateDto, Car>();
    }
}
