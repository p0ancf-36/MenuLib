namespace MenuLib;

public class ContextHandler : IContextHandler
{
    private readonly Stack<ConsolePosition> _sessions = new();
    private readonly ConsolePosition _start;

    public ContextHandler()
    {
        _start = Current;
        
        ConsoleTweaks.ResetColorscheme();
    }

    private ConsolePosition Current => new(Console.GetCursorPosition());

    public void Begin()
    {
        _sessions.Push(Current);
    }

    public void Clear()
    {
        var isSuccess = _sessions.TryPeek(out var position);

        if (!isSuccess || position == null)
            position = _start;
        
        ConsoleTweaks.ClearInterval(position, Current);
    }

    public void End()
    {
        Clear();
        _sessions.TryPop(out _);
    }

    public void Reset()
    {
        _sessions.Clear();
        ConsoleTweaks.ClearInterval(_start, Current);
    }

    public void Write(string s)
    {
        Console.Write(s);
    }

    public void Writeln(string s)
    {
        Write($"{s}\n");
    }

    public ConsoleKey WaitKey()
    {
        return Console.ReadKey().Key;
    }
}