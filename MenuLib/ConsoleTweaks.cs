namespace MenuLib;

internal static class ConsoleTweaks
{
    public static void ClearInterval(ConsolePosition from, ConsolePosition to)
    {
        int leftOffset = from.Left;
        int topOffset = from.Top;
        int rightOffset = Console.BufferWidth - to.Left;
        int bottomOffset = Console.BufferHeight - to.Top;
        
        Console.SetCursorPosition(from.Left, from.Top);
        Console.Write(new string(' ', (bottomOffset - topOffset) * Console.BufferWidth + (rightOffset - leftOffset)));
        Console.SetCursorPosition(from.Left, from.Top);
    }

    public static void SetColorscheme(Colorscheme colorscheme)
    {
        Console.ForegroundColor = colorscheme.Foreground;
        Console.BackgroundColor = colorscheme.Background;
    }

    public static void ResetColorscheme() => SetColorscheme(Colorscheme.Default);

    public static class Keys
    {
        public static bool Up(ConsoleKey key) => key == ConsoleKey.UpArrow;
        public static bool Down(ConsoleKey key) => key == ConsoleKey.DownArrow;
        public static bool Choose(ConsoleKey key) => key == ConsoleKey.Enter;
    }
}