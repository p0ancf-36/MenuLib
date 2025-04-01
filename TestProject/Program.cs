using MenuLib;

namespace TestProject;

class Program
{
    private static void Main(string[] args)
    {
        var contextHandler = new ContextHandler();
        var menu = new ChooseMenuBuilder<int>()
            .WithVariant("a", 1)
            .WithVariant("b", 2)
            .WithVariant("c", 52)
            .WithVariant("aboba", 228)
            .Build("Test menu:");

        var result = menu.Choose(contextHandler);
        contextHandler.Writeln(result.ToString());
        contextHandler.WaitKey();
    }
}

