using System.Collections.Generic;

namespace H1S2.Models.Terminals.Interfaces;

public interface ITerminal
{
    IEnumerable<ITerminal>? Terminals { get; set; }
    string? Value { get; set; }
    int ErrorCount { get; set; }
    double Calculate();
}