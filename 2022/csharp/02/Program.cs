await Solver.RunSolutionsWith(TheSolver);

static async Task<string> TheSolver(IAsyncEnumerable<string> lines)
{
    StringBuilder sb = new();
    await foreach (string line in lines)
    {
        sb.Append(new string(line.Reverse().ToArray())).Append(line).AppendLine();
    }

    return sb.ToString();
}
