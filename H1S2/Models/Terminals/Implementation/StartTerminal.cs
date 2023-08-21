using System.Collections.Generic;
using H1S2.Models.Terminals.Interfaces;

namespace H1S2.Models.Terminals.Implementation;

public class StartTerminal : ITerminal
{
    public IEnumerable<ITerminal>? Terminals { get; set; }
    public string? Value { get; set; }
    public int ErrorCount { get; set; }
    public double Calculate() => 0;

    public StartTerminal()
    {
        ErrorCount = 0;
        Value = "Start";
    }
}