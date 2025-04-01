namespace MenuLib;

public interface IContextHandler
{
    public void Begin();
    public void BeginLabeled(string label)
    {
        Begin();
        Writeln(label);
        Begin();
    }
    
    public void End();
    public void End(int count)
    {
        for (int i = 0; i < count; i++)
        {
            End();
        }
    }
    public void EndLabeled() => End(2);

    public void Clear();
    public void Reset();

    public void Write(string s);
    public void Writeln(string s);

    public ConsoleKey WaitKey();
}