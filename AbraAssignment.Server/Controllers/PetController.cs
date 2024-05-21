using AbraAssignment.Server.DTO;
using AbraAssignment.Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace AbraAssignment.Server.Controllers
{
	[Route("api/pet")]
	[ApiController]
	public class PetController : ControllerBase
	{

		private readonly PetService m_petService; 

		public PetController(PetService petService) 
		{
			m_petService = petService;
		}

		// GET: api/pet
		[HttpGet]
		public async Task<IActionResult> GetAllPets()
		{
			try
			{
				var pets = await m_petService.GetAllPetsAsync();
				return Ok(pets);
			}
			catch
			{
				return BadRequest();
			}
		}

	
		//POST: api/pet
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] PetDto newPetDto)
		{
			try
			{
				var newPet = await m_petService.CreatePetAsync(newPetDto);
				return Created();
			}
			catch
			{
				return BadRequest();
			}
		}
	}
}
