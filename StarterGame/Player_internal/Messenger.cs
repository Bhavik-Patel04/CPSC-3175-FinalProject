using System;

public class Messenger
{
    private string name;

    public Messenger(string name) {
        this.name = name;
    }

    public void OutputMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ColoredMessage(string message, ConsoleColor newColor)
    {
        ConsoleColor oldColor = Console.ForegroundColor;
        Console.ForegroundColor = newColor;
        OutputMessage(message);
        Console.ForegroundColor = oldColor;
    }

    public void NormalMessage(string message)
    {
        ColoredMessage(message, ConsoleColor.White);
    }

    public void InfoMessage(string message)
    {
        ColoredMessage(message, ConsoleColor.Blue);
    }

    public void WarningMessage(string message)
    {
        ColoredMessage(message, ConsoleColor.DarkYellow);
    }

    public void ErrorMessage(string message)
    {
        ColoredMessage(message, ConsoleColor.Red);
    }

    public void ReplyMessage(string message)
    {
        ColoredMessage($"[{name}] : "+message, ConsoleColor.Magenta);
    }
}
