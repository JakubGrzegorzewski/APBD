namespace Task1;

public interface IHazardNotifier
{
    public static void SendDangerNotification(Container container,String message)
    {
        Console.WriteLine($"{message} on container number: {container.SerialNumber}");
    }
}