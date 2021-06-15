using PluginBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoresandTech.Api.Interfaces
{
  public interface IImageEffectHandler
  {
	IList<IEffect> effects { get; set; }
  }
}
