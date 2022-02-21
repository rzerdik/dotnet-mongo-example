using AutoMapper;
using MongoExample.API.Dtos;
using MongoExample.API.Models;

namespace MongoExample.API.Profiles;

public class CarsProfile : Profile
{
    public CarsProfile()
    {
        CreateMap<Car, CarReadDto>();
        CreateMap<CarCreateDto, Car>();
    }
}