using Dapper;
using records_api.Models;
using System.Data;

namespace records_api.Repository
{
	public class RecordRepository
	{
		private List<Record> records;
		private DataContext context;

        public RecordRepository()
        {
            //records = BuildRecords();
			context = new DataContext("Host=localhost:5432; Database=record-collection; Username=postgres; Password=collection;");
        }

        public IEnumerable<Record> GetRecords()
		{
			return records;
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
			using IDbConnection connection = context.CreateConnection();
			string query =	$"SELECT record.record_id AS RecordId, record.title AS Title, artist.artist_name AS Artist " +
							$"FROM record " +
							$"INNER JOIN artist ON record.artist_id = artist.artist_id " +
							$"WHERE record_id = '{id}'";
			Record record = await connection.QueryFirstAsync<Record>(query);
			if (record == null)
			{
				throw new ArgumentNullException(nameof(record));
			}
			return record;
		}

		public void Add(Record record)
		{
			records.Add(record);
		}
		public void Update(Record record)
		{

		}
		public void Delete(Record record)
		{

		}

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
