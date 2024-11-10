using Microsoft.AspNetCore.Mvc;
using records_api.Models;
using records_api.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace records_api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RecordController : ControllerBase
	{
		private RecordRepository recordRepository;

        public RecordController()
        {
            recordRepository = new RecordRepository();
        }
        // GET: api/<RecordController>
        [HttpGet]
		public IEnumerable<Record> Get()
		{
			return recordRepository.GetRecords();
		}

		// GET api/<RecordController>/5
		[HttpGet("{id}")]
		public async Task<Record> GetAsync(Guid id)
		{
			return await recordRepository.GetRecordAsync(id);
		}

		// POST api/<RecordController>
		[HttpPost]
		public void Post([FromBody] Record record)
		{
			recordRepository.Add(record);
		}

		// PUT api/<RecordController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] Record record)
		{
		}

		// DELETE api/<RecordController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{

		}
	}
}
