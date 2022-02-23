//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using MongoDB.Driver;
//using MongoExample.API.Dtos;
//using MongoExample.API.Models;

//namespace MongoExample.API.Controllers;

//[Route("api/[controller]")]
//[ApiController]
//public class CarsController : ControllerBase
//{
//    private readonly IMapper _mapper;
//    private readonly ICarRepository _repository;

//    public CarsController(ICarRepository repository, IMapper mapper)
//    {
//        _repository = repository;
//        _mapper = mapper;
//    }

//    [HttpGet]
//    public ActionResult<IEnumerable<CarReadDto>> GetAllCars()
//    {
//        var cars = _repository.GetAllCars();

//        if (cars is null)
//            return NotFound();

//        return Ok(_mapper.Map<IEnumerable<CarReadDto>>(cars.ToList()));
//    }

//    [HttpGet("{VIN}", Name = "GetCarByVIN")]
//    public async Task<ActionResult<CarReadDto>> GetCarByVIN(int VIN)
//    {
//        var car = await _repository.GetCarByVINAsync(VIN);

//        if (car is null)
//            return NotFound();

//        return Ok(_mapper.Map<CarReadDto>(car));
//    }

//    [HttpPost]
//    public async Task<ActionResult<CarReadDto>> CreateCar(CarCreateDto carCreateDto)
//    {
//        var carModel = _mapper.Map<Car>(carCreateDto);
//        try
//        {
//            await _repository.CreateCarAsync(carModel);
//        }
//        catch (MongoWriteException)
//        {
//            return BadRequest("VIN code already exists. Please use a unique value");
//        }
//        catch (Exception e)
//        {
//            return BadRequest(e.Message);
//        }

//        var carReadDto = _mapper.Map<CarReadDto>(carModel);

//        return CreatedAtRoute("GetCarByVIN", new { VIN = carReadDto.VIN }, carReadDto);
//    }

//    [HttpDelete("{VIN}")]
//    public async Task<ActionResult> DeleteCar(int VIN)
//    {
//        var carModelFromRepo = await _repository.GetCarByVINAsync(VIN);

//        if (carModelFromRepo is null)
//            return NotFound();

//        await _repository.DeleteCarAsync(carModelFromRepo);

//        return NoContent();
//    }
//}


