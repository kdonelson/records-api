using Microsoft.EntityFrameworkCore;
using records_api.Models;

namespace records_api.Repository
{
	public class ArtistRepository
	{
		public IEnumerable<Artist> GetArtists()
		{
			List<Artist> artists;
			using var context = new RecordCollectionContext();
			artists = [.. context.Artists];
			return artists;
		}

		public async Task<Artist> GetArtist(Guid id)
		{
			using var context = new RecordCollectionContext();
			return await context.Artists.SingleAsync(a => a.ArtistId == id);
		}

		public async Task<Artist> GetArtistByName(string name)
		{
			using var context = new RecordCollectionContext();
			return await context.Artists.SingleOrDefaultAsync(a => a.ArtistName == name);
		}

		public async Task<Artist> CreateArtist(Artist artist)
		{
			artist.ArtistId = Guid.NewGuid();

			using var context = new RecordCollectionContext();
			context.Artists.Add(artist);
			await context.SaveChangesAsync();
			return artist;
		}

		public async Task RemoveArtist(Guid id)
		{
			using var context = new RecordCollectionContext();
			Artist artist = await context.Artists.SingleAsync(a => a.ArtistId == id);
			context.Artists.Remove(artist);
			await context.SaveChangesAsync();
		}
	}
}
