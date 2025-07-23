using System;

namespace Core.Interfaces;

public interface ILogService
{
    public void Log(string structure, string message);
    public void Log(string structure, string message, Exception exception);
    public void Log(string structure, string message, string category);
}
