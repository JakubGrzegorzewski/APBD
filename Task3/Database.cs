using Task3.Model;

namespace Task3;

public class Database
{
    public static List<Animal> Animals = new List<Animal>()
    {
        new Animal() { Id = 1, Name = "Burek", Category = AnimalCategory.Pies, Weight = 10.5f, Color = "Czarny" },
        new Animal() { Id = 2, Name = "Mruczek", Category = AnimalCategory.Kot, Weight = 5.0f, Color = "Biały" },
        new Animal() { Id = 3, Name = "Papuga", Category = AnimalCategory.Papugi, Weight = 0.5f, Color = "Zielony" }
    };
    public static List<Visit> Visits = new List<Visit>()
    {
        new Visit() { Id = 1, VisiDate = DateTime.Now, AnimalId = 1, Description = "Wizytka", Price = 100.0f },
        new Visit() { Id = 2, VisiDate = DateTime.Now, AnimalId = 2, Description = "Wizytka", Price = 200.0f },
        new Visit() { Id = 3, VisiDate = DateTime.Now, AnimalId = 3, Description = "Wizytka", Price = 300.0f }
    };
}