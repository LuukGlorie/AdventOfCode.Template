using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly IReadOnlyList<string> _input;

    public Day01()
    {
        _input = File.ReadLines(InputFilePath).ToList();
    }

    public override async ValueTask<string> Solve_1() 
    {
        var values = _input
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        
        var firstColumn = values.Select(x => x.First()).Order();
        var secondColumn = values.Select(x => x.Last()).Order();

        var result = firstColumn.Zip(secondColumn, (x, y) => Math.Abs(x - y)).Sum();
        return result.ToString();
    }

    public override async ValueTask<string> Solve_2() 
    {
        var values = _input
            .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
        
        var firstColumn = values.Select(x => x.First());
        var secondColumn = values.Select(x => x.Last())
            .GroupBy(x => x, (x, ys) => (x, ys.Count()))
            .ToDictionary(x => x.x, x => x.Item2);

        var result = firstColumn.Select(x => x * (secondColumn.TryGetValue(x, out var y) ? y : 0)).Sum();
        return result.ToString();
    }
}
