using System.IO;

namespace PluginBase
{
  public interface IEffect
  {
	string EffectName { get; }

	/// <summary>
	/// Applies the specified file.
	/// </summary>
	/// <param name="file">The file.</param>
	/// <param name="size">The size.</param>
	/// <returns></returns>
	MemoryStream Apply(MemoryStream file, int size);
  }
}
