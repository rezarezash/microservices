using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.Dtos;
using PlatformService.Models;
using System.Collections.Generic;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;

        public PlatformsController(IPlatformRepository platformRepository
          , IMapper mapper)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatfromReadDto>> GetAllPlatforms()
        {
            var platformsModels = _platformRepository.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatfromReadDto>>(platformsModels));
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetPlatformById")]
        public ActionResult<PlatfromReadDto> GetPlatformById(int id)
        {
            var platform = _platformRepository.GetplatformById(id);
            if (platform == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<PlatfromReadDto>(platform));
        }

        [HttpPost]
        public ActionResult<PlatfromReadDto> CreatePlatform(PlatformCreateDto platformCreateDto)
        {
            if (platformCreateDto == null)
            {
                return BadRequest();
            }

            var platformModel = _mapper.Map<Platform>(platformCreateDto);
            _platformRepository.CreatePlatform(platformModel);
            _platformRepository.SaveChanges();
            var platformReadDto = _mapper.Map<PlatfromReadDto>(platformModel);

            return CreatedAtRoute(nameof(GetPlatformById), new { Id = platformReadDto.Id }, platformReadDto);          
        }

    }
}