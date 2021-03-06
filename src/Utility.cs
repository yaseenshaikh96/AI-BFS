public static class Utility
{
    public static void PrintError(string errMsg, bool exit = false)
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(errMsg);
        if (exit) Environment.Exit(0);
        System.Console.ResetColor();
    }
}