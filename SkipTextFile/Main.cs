using System;
using SkipTextFile;

public static class Entry
{
  public static void Main(string[] args)
  {
    InputManager input = new InputManager(args);

    if (input.CheckArguments() == false)
    {
      return;
    }

    try
    {
      input.SetArguments();

      SkipTextFileCore core = new SkipTextFileCore(input);
      core.Parse();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
    }
  }
}
