using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using records_api.Models;
using records_api.Repository;
using records_api.Service;

namespace records_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArtistController : ControllerBase
	{
		private ArtistRepository _artistRepository;
		private ArtistService _artistService;

        public ArtistController()
        {
			_artistRepository = new ArtistRepository();
			_artistService = new ArtistService(_artistRepository);
        }

        [HttpGet]
		public IEnumerable<Artist> Get()
		{
			return _artistRepository.GetArtists();
		}

		[HttpGet("{id}")]
		public async Task<Artist> GetArtist(Guid id)
		{
			return await _artistRepository.GetArtist(id);
		}

		[HttpPost]
		public async Task<IActionResult> CreateArtist(Artist artist)
		{
			var result = await _artistService.CreateArtist(artist);

			if (result.IsFailed)
			{
				return BadRequest(result.Errors);
			}

			return CreatedAtAction(nameof(GetArtist), new {id = result.Value.ArtistId}, result.Value);
		}

		[HttpDelete("{id}")]
		public async Task DeleteArtist(Guid id)
		{
			await _artistRepository.RemoveArtist(id);
		}
	}
}
