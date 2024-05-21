using AbraAssignment.Server.DTO;
using AbraAssignment.Server.Models;
using AbraAssignment.Server.Repositories;
using Microsoft.AspNetCore.DataProtection.Repositories;

namespace AbraAssignment.Server.Services
{
	public class PetService
	{
		private readonly IRepository<Pet> m_PetRepository;

		public PetService(IRepository<Pet> petRepository)
		{
			m_PetRepository = petRepository;
		}

		public async Task<List<PetDto>> GetAllPetsAsync()
		{
			
			var pets = await m_PetRepository.GetAllAsync();
			return pets.Select(pet => new PetDto(pet._id, pet.Name, pet.CreatedAt, pet.Type, pet.Color, pet.Age))
			.ToList();
		}

		public async Task<PetDto> CreatePetAsync(PetDto petDto)
		{

			var pet = new Pet { Name = petDto.name, CreatedAt = petDto.created_at, Type = petDto.type, 
			Color = petDto.color, Age = petDto.age};
			if (pet.Validate())
			{
				pet = await m_PetRepository.CreateAsync(pet);
				return new PetDto(pet._id, pet.Name, pet.CreatedAt, pet.Type, pet.Color, pet.Age);
			}
			else 
			{
				throw new Exception("Not Valid Input, try again");
			}
		}

	}
}
