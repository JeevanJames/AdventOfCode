using System.Reflection;

namespace AdventOfCode;

public static class Solver
{
    public static async Task RunSolutionsWith(Func<IAsyncEnumerable<string>, Task<string>> solver)
    {
        await foreach (string solution in RunSolution(solver))
            WriteLine(solution);
    }

    private static async IAsyncEnumerable<string> RunSolution(Func<IAsyncEnumerable<string>, Task<string>> solver)
    {
        Assembly? asm = Assembly.GetEntryAssembly();
        Debug.Assert(asm is not null);

        var resources = asm.GetManifestResourceNames()
            .Where(r => r.EndsWith(".data1.txt") || r.EndsWith(".data2.txt"));
        foreach (string resource in resources)
        {
            Stream? resourceStream = asm.GetManifestResourceStream(resource);
            Debug.Assert(resourceStream is not null);
            using StreamReader reader = new(resourceStream);
            yield return await solver(EnumerateLines(reader));
        }
    }

    private static async IAsyncEnumerable<string> EnumerateLines(StreamReader reader)
    {
        string? line = await reader.ReadLineAsync();
        while (line is not null)
        {
            yield return line;
            line = await reader.ReadLineAsync();
        }
    }
}