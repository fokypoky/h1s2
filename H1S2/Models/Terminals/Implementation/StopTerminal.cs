using System.Collections.Generic;
using H1S2.Models.Terminals.Interfaces;

namespace H1S2.Models.Terminals.Implementation;

public class StopTerminal : ITerminal
{
    public IEnumerable<ITerminal>? Terminals { get; set; }
    public string? Value { get; set; }
    public int ErrorCount { get; set; }
    public double Calculate() => 0;

    public StopTerminal()
    {
        Value = "Stop";
        ErrorCount = 0;
    }
}