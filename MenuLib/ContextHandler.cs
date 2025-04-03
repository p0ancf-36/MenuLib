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
    
    public double ReadDouble(
        double min = double.NegativeInfinity,
        double max = double.PositiveInfinity,
        string label = "enter double value: ",
        string invalidInput = "you introduced not double value!\n",
        string overflowInput = "double that you introduced is not in bounds\n")
    {
        double result;
        bool isSuccess;

        Begin();

        do
        {
            Write(label);
            isSuccess = double.TryParse(Console.ReadLine(), out result);

            Clear();
            if (!isSuccess)
            {
                Write(invalidInput);
            }
            else if (result < min || result > max)
            {
                isSuccess = false;
                Write(overflowInput);
            }
        } while (!isSuccess);

        End();

        return result;
    }
}