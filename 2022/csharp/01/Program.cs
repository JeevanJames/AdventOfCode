await Solver.RunSolutionsWith(TheSolver);

static async Task<string> TheSolver(IAsyncEnumerable<string> lines)
{
    StringBuilder sb = new();
    await foreach (string line in lines)
    {
        sb.Insert(0, Environment.NewLine);
        sb.Insert(0, line);
    }

    return sb.ToString();
}
