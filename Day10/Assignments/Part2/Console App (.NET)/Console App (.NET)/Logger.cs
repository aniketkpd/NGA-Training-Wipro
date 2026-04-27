using System;
using System.IO;

public static class Logger
{
    private static string path = "log.txt";

    public static void Log(string message)
    {
        File.AppendAllText(path,
            $"{DateTime.Now} INFO: {message}\n");
    }

    public static void LogError(string message)
    {
        File.AppendAllText(path,
            $"{DateTime.Now} ERROR: {message}\n");
    }
}