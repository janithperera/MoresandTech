using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoresandTech.Api.Dtos
{
  public class FileDataDto
  {
	public string FileName { get; set; }
	public List<EffectDto> Effects { get; set; }
  }
}
