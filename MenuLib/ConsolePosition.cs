namespace MenuLib;

internal record ConsolePosition(int Left, int Top)
{
    internal ConsolePosition((int, int) consoleInput): this(consoleInput.Item1, consoleInput.Item2) { }
}