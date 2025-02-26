using Dapper;
using Microsoft.EntityFrameworkCore;
using records_api.DomainModels;
using records_api.Models;
using System.Data;

namespace records_api.Repository
{
	public class RecordRepository
	{
        public IEnumerable<Record> GetRecords()
		{
			using var context = new RecordCollectionContext();
			return [.. context.Records
					.Include(r => r.RecordLabel)
					.Include(r => r.Artist)];
		}

		//public Record GetRecord(int id)
		//{
		//	Record record = records.FirstOrDefault(r => r.RecordId == id);
		//	if (record == null)
		//	{
		//		throw new ArgumentNullException(nameof(record));
		//	}
		//	return record;
		//}

		public async Task<Record> GetRecordAsync(Guid id)
		{
			using var context = new RecordCollectionContext();
			return await context.Records
				.Include(r => r.RecordLabel)
				.Include(r => r.Artist)
				.SingleAsync(r => r.RecordId == id);
		}

		public void Add(Record record)
		{
			using var context = new RecordCollectionContext();
			
		}
		public void Update(Record record)
		{

		}
		public void Delete(Record record)
		{

		}

		//private RecordModel buildRecordModel(Record record)
		//{
		//	return new RecordModel
		//	{
		//		RecordId = record.RecordId,
		//		Title = record.Title,
		//		Artist = record.Artist.ArtistName,
		//		ReleaseDate = record.ReleaseDate.ToDateTime(TimeOnly.MinValue),
		//		RecordLabel = record.RecordLabel.RecordLabelName,
		//		AlbumArt = record.AlbumArt
		//	};
		//}

		//private Record buildRecord(RecordModel recordModel)
		//{

		//}

		//private static List<Record> BuildRecords()
		//{
		//	return
		//	[
		//		new Record
		//		{
		//			RecordId = 1,
		//			Title = "Waking the Fallen",
		//			Artist = "Avenged Sevenfold",
		//			RecordLabel = "Hopeless Records",
		//			ReleaseDate = new DateTime(2003,8,26),
		//			Photo = "/assets/waking-the-fallen.jpg"
		//		},
		//		new Record
		//		{
		//			RecordId = 2,
		//			Title = "Heaven:x:Hell",
		//			Artist = "Sum 41",
		//			RecordLabel = "Rise Records",
		//			ReleaseDate = new DateTime(2024,3,29),
		//			Photo = "/assets/heaven-hell.png"
		//		},
		//		new Record
		//		{
		//			RecordId = 3,
		//			Title = "Shadows of the Dying Sun",
		//			Artist = "Insomnium",
		//			RecordLabel = "Century Media Records",
		//			ReleaseDate = new DateTime(2014,4,29),
		//			Photo = "/assets/Shadows_of_the_Dying_Sun.jpg"
		//		},
		//		new Record
		//		{
		//			RecordId = 4,
		//			Title = "Anno 1696",
		//			Artist = "Insomnium",
		//			RecordLabel = "Century Media Records",
		//			ReleaseDate = new DateTime(2023,2,24),
		//			Photo = "/assets/anno-1696.png"
		//		}
		//	];
		//}
	}
}
