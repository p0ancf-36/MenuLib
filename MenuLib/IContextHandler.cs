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

    public double ReadDouble(
        double min = double.NegativeInfinity,
        double max = double.PositiveInfinity,
        string label = "enter double value: ",
        string invalidInput = "you introduced not double value!\n",
        string overflowInput = "double that you introduced is not in bounds\n");
}