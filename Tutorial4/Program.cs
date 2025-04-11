using Tutorial3.Models;

namespace Tutorial3;

public class Program
{
    public static void Main(string[] args)
    {
        var emps = Database.GetEmps();
        var depts = Database.GetDepts();
        var salgrades = Database.GetSalgrades();
    }
}