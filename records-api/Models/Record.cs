namespace records_api.Models
{
	public class Record
	{
        public Guid RecordId { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public DateTime ReleaseDate { get; set; } = new DateTime();
        public string RecordLabel { get; set; } = string.Empty;
        public string AlbumArt { get; set; } = string.Empty;
    }
}
