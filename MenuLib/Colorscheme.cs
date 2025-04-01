namespace MenuLib;

public record Colorscheme(ConsoleColor Foreground, ConsoleColor Background)
{
    public static readonly Colorscheme Default = new (ConsoleColor.White, ConsoleColor.Black);
    public static readonly Colorscheme Active = new (ConsoleColor.Black, ConsoleColor.Cyan);
}