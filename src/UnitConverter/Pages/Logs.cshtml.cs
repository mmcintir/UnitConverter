using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class Logs : PageModel
{
    private readonly ILogger<Logs> _logger;
    private readonly ILogReader _reader;

    [BindProperty(SupportsGet = true)]
    public IEnumerable<LogEntry> Entries { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string Level { get; set; }

    [BindProperty(SupportsGet = true)]
    public string ConversionType { get; set; }


    public Logs(ILogger<Logs> logger, ILogReader reader)
    {
        _logger = logger;
        _reader = reader;
    }

    public void OnGet()
    {
        Entries = _reader.Read();
    }
}
