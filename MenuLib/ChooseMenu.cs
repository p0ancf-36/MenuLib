namespace MenuLib;

public class ChooseMenu<T>(string label, IReadOnlyDictionary<string, T> variants)
{
    public T Choose(IContextHandler contextHandler)
    {
        contextHandler.BeginLabeled(label);
        
        int pos = 0;
        ConsoleKey key;

        do
        {
            var variant = variants.ElementAt(pos).Key;
            Print(contextHandler, variant);
            key = contextHandler.WaitKey();

            if (ConsoleTweaks.Keys.Up(key)) pos -= 1;
            else if (ConsoleTweaks.Keys.Down(key)) pos += 1;

            pos = (pos + variants.Count) % variants.Count;

        } while (!ConsoleTweaks.Keys.Choose(key));
        
        contextHandler.EndLabeled();
        return variants.ElementAt(pos).Value;
    }

    private void Print(IContextHandler contextHandler, string chosen)
    {
        contextHandler.Clear();
        foreach (var (variantName, index) in variants.Keys.Select((variantName, index) => (variantName, index)))
        {
            ConsoleTweaks.SetColorscheme(variantName.Equals(chosen) ? Colorscheme.Active : Colorscheme.Default);
            contextHandler.Writeln($"{index + 1,4}: {variantName}");
        }
        ConsoleTweaks.ResetColorscheme();
    }
}