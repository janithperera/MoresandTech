using Microsoft.Extensions.Configuration;
using MoresandTech.Api.Interfaces;
using PluginBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MoresandTech.Api
{
  public class ImageEffectHandler : IImageEffectHandler
  {
	private readonly List<string> plugins;
	private readonly IConfiguration  configuration;

	public IList<IEffect> effects { get; set; }

	public ImageEffectHandler(IConfiguration configuration)
	{
	  this.configuration = configuration;
	  this.plugins = this.configuration.GetSection("Plugins").Get<string[]>().ToList();

	  effects = new List<IEffect>();
	  foreach (var plugin in plugins)
	  {
		var pluginAssembly = LoadPlugin(plugin);
		var effect = CreateEffects(pluginAssembly);
		effects = effect.ToList();
	  }

	 // effects = plugins.SelectMany(pluginPath =>
	 // {
		//Assembly pluginAssembly = LoadPlugin(pluginPath);
		//return CreateEffects(pluginAssembly);
	 // }).ToList();
	}

	static Assembly LoadPlugin(string relativePath)
	{
	  string root = Path.GetFullPath(Path.Combine(
			Path.GetDirectoryName(
				Path.GetDirectoryName(
					Path.GetDirectoryName(
						Path.GetDirectoryName(
							Path.GetDirectoryName(
								Path.GetDirectoryName(typeof(Program).Assembly.Location))))))));

	  string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
	  Console.WriteLine($"Loading commands from: {pluginLocation}");
	  PluginHandler loadContext = new PluginHandler(pluginLocation);
	  var assembly = loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
	  return assembly;
	}

	static IEnumerable<IEffect> CreateEffects(Assembly assembly)
	{
	  int count = 0;

	  foreach (Type type in assembly.GetTypes())
	  {
		if (typeof(IEffect).IsAssignableFrom(type))
		{
		  IEffect result = Activator.CreateInstance(type) as IEffect;
		  if (result != null)
		  {
			count++;
			yield return result;
		  }
		}
	  }

	  if (count == 0)
	  {
		string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
		throw new ApplicationException(
			$"Can't find any type which implements IEffect in {assembly} from {assembly.Location}.\n" +
			$"Available types: {availableTypes}");
	  }
	}
  }
}
