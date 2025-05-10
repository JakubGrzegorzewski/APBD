using Microsoft.AspNetCore.Mvc;
using Task3.Model;

namespace Task3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(Database.Animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }

        [HttpPost]
        public IActionResult AddAnimal([FromBody] Animal animal)
        {
            Database.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();
            
            animal.Name = updatedAnimal.Name;
            animal.Weight = updatedAnimal.Weight;
            animal.Color = updatedAnimal.Color;
            animal.Category = updatedAnimal.Category;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();
            
            Database.Animals.Remove(animal);
            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchAnimals([FromQuery] string name)
        {
            var animals = Database.Animals.Where(a => a.Name.Contains(name)).ToList();
            return Ok(animals);
        }
    }
}