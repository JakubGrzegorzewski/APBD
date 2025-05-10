using Microsoft.AspNetCore.Mvc;
using Task3.Model;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/animals/{animalId}/[controller]")]
    public class VisitsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetVisits(int animalId)
        {
            var visits = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
            return Ok(visits);
        }

        [HttpPost]
        public IActionResult AddVisit(int animalId, [FromBody] Visit visit)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == animalId);
            if (animal == null)
                return NotFound("Animal not found.");

            visit.AnimalId = animalId;
            Database.Visits.Add(visit);
            return CreatedAtAction(nameof(GetVisits), new { animalId = animalId }, visit);
        }
    }
}