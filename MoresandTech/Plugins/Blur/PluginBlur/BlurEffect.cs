using PluginBase;
using System;
using System.IO;

namespace PluginBlur
{
  public class BlurEffect : IEffect
  {
	public string EffectName => "Blur";

	/// <summary>
	/// Applies the specified file.
	/// </summary>
	/// <param name="file">The file.</param>
	/// <param name="size">The size.</param>
	/// <returns></returns>
	public MemoryStream Apply(MemoryStream file, int size)
	{
	  Console.WriteLine("Executed");
	  return file;
	}
  }
}
