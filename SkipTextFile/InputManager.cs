using System;
using System.IO;

namespace SkipTextFile
{
  public class InputManager
  {
    public string InputFilePath  { private set; get; }
    public string OutputFilePath { private set; get; }
    public int    SkipHeader     { private set; get; }
    public int    SkipLines      { private set; get; }

    private string[] arguments;

    private const int ARGUMENT_SIZE = 4;


    public InputManager(string[] args)
    {
      this.arguments = args;
    }


    public bool CheckArguments()
    {
      if (this.arguments.Length != ARGUMENT_SIZE)
      {
        Console.WriteLine("[Usage]");
        Console.WriteLine("> SkipTextFile.exe InputFilePath OutoutFilePath SkipHeader SkipLines\n");
        Console.WriteLine("[Example]");
        Console.WriteLine("> SkipTextFile.exe input.txt output.txt 3 10");
        return false;
      }

      return true;
    }

    public void SetArguments()
    {
      this.setInputFilePath (this.arguments[0]);
      this.setOutputFilePath(this.arguments[1]);
      this.setSkipHeader    (this.arguments[2]);
      this.setSkipLines     (this.arguments[3]);
    }


    private void setInputFilePath(string arg)
    {
      string path = arg.Trim();

      if (File.Exists(path) == false)
      {
        throw new FileNotFoundException(path + "が存在しません．");
      }

      this.InputFilePath = path;
    }

    private void setOutputFilePath(string arg)
    {
      this.OutputFilePath = arg.Trim();
    }

    private void setSkipHeader(string arg)
    {
      int skip = int.Parse(arg);

      if (skip < 0)
      {
        throw new ArgumentOutOfRangeException("SkipHeaderは0以上の整数である必要があります．");
      }

      this.SkipHeader = skip;
    }

    private void setSkipLines(string arg)
    {
      int skip = int.Parse(arg);

      if (skip < 1)
      {
        throw new ArgumentOutOfRangeException("SkipLinesは正の整数である必要があります．");
      }

      this.SkipLines = skip;
    }
  }
}