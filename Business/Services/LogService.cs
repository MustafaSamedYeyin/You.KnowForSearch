using System;
using System.IO;
using Core.Interfaces;

namespace Business.Services;

public class FileLogService : ILogService
{
    private readonly object _lockObject = new object();

    public void Log(string filePath, string file, string message)
    {
        var splitedFilePath = filePath.Split("/");
        var logFilePath = string.Empty;
        foreach (var combinePath in splitedFilePath)
        {
            logFilePath = Path.Combine(logFilePath, combinePath);
        }
        logFilePath = Path.Combine(logFilePath, "log.txt");

        lock (_lockObject)
        {
            using (var fileStream = new FileStream(logFilePath, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message + Environment.NewLine);
                fileStream.Write(bytes, 0, bytes.Length);
            }
        }
    }

    public void Log(string structure, string message)
    {
        throw new NotImplementedException();
    }

    public void Log(string structure, string message, Exception exception)
    {
        throw new NotImplementedException();
    }
}
