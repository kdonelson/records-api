using FluentResults;
using records_api.DomainModels.Errors;
using records_api.Models;
using records_api.Repository;

namespace records_api.Service
{
	public class ArtistService
	{
		private readonly ArtistRepository repository;

		public ArtistService(ArtistRepository artistRepository) 
		{ 
			this.repository = artistRepository;
		}

		public async Task<Result<Artist>> CreateArtist(Artist artist)
		{
			var result = await validateForSave(artist);

			if (result.IsFailed)
			{
				return result;
			}

			var createdArtist = await repository.CreateArtist(artist);
			return Result.Ok(createdArtist);
		}

		private async Task<Result> validateForSave(Artist artist)
		{
			if (artist is null)
			{
				return new RecordNotFound("No Artist Provided");
			}

			var duplicate = await repository.GetArtistByName(artist.ArtistName);
			if (duplicate != null)
			{
				return new Duplicate("Artist Name is already in use");
			}

			if (string.IsNullOrWhiteSpace(artist.ArtistName))
			{
				return new Validation("Artist Name cannot be empty");
			}

			return Result.Ok();
		}
	}
}
