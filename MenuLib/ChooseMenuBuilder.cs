namespace MenuLib;

public class ChooseMenuBuilder<T>
{
    private readonly Dictionary<string, T> _variants = new();

    public ChooseMenuBuilder<T> WithVariant(string label, T value)
    {
        if (!_variants.TryAdd(label, value))
            throw new ArgumentException("This label already exists");

        return this;
    }

    public ChooseMenu<T> Build(string label)
    {
        return new ChooseMenu<T>(label, _variants.AsReadOnly());
    }
}