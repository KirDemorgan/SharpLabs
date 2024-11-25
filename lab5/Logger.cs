namespace lab5;

public class Logger
{
    private readonly string _logFilePath;
    private bool _append;

    public Logger(string logFilePath, bool append)
    {
        _logFilePath = logFilePath;
        _append = append;

        if (!append)
        {
            File.WriteAllText(_logFilePath, string.Empty);
        }
    }

    public void Info(string message)
    {
        WriteToFile($"{DateTime.Now} | [INFO]    | {message}");
    }

    public void Error(string message)
    {
        WriteToFile($"{DateTime.Now} | [ERROR]   | {message}");
    }

    public void Warning(string message)
    {
        WriteToFile($"{DateTime.Now} | [WARNING] | {message}");
    }

    private void WriteToFile(string message)
    {
        if (_append)
        {
            File.AppendAllText(_logFilePath, message + Environment.NewLine);
        }
        else
        {
            File.WriteAllText(_logFilePath, message + Environment.NewLine);
            _append = true;
        }
    }
}