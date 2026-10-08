using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;

    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(environment.ContentRootPath, "Logs");

    }

    public IEnumerable<LogEntry> Read()
    {
        string[] logFiles = Directory.GetFiles(_logDirectory, "*.json");
        IEnumerable<LogEntry> logEntries = new List<LogEntry>();
        LogEntry? entry;
        foreach (string logFile in logFiles)
        {
            string[] lines = File.ReadAllLines(logFile);

            foreach (string line in lines)
            {
                try
                {
                    entry = JsonSerializer.Deserialize<LogEntry>(line);
                }
                catch (JsonException e)
                {
                     entry = new LogEntry();
                     entry.Message = e.Message;
                     entry.Exception = e.StackTrace;
                     entry.Level = "Error";
                }
                if (entry.Level == null || entry.Level.IsWhiteSpace())
                {
                    entry.Level = "Information";
                }
                logEntries = logEntries.Append(entry);
            }
        }
        return logEntries;
    }
}
