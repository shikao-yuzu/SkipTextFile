using System.IO;
using System.Text;
using System.Linq;

namespace SkipTextFile
{
  public class SkipTextFileCore
  {
    private InputManager inputManager;


    public SkipTextFileCore(InputManager input)
    {
      this.inputManager = input;

    }


    public void Parse()
    {
      using (StreamWriter sw = new StreamWriter(this.inputManager.OutputFilePath, false, Encoding.GetEncoding("Shift_JIS")))
      {
        foreach (var line in File.ReadLines( this.inputManager.InputFilePath,
                                             Encoding.GetEncoding("Shift_JIS")).Skip(this.inputManager.SkipHeader)
                                                                               .Where((str, idx) => idx % this.inputManager.SkipLines == 0) )
        {
          sw.WriteLine(line);
        }
      }
    }
  }
}
