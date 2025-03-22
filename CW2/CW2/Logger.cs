namespace CW2;

public class Logger
{
    public static void Log(string toLog)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {toLog}");
    }
    
    public static void Log()
    {
        Console.WriteLine();
    }
}