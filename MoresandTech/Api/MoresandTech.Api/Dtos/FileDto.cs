using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MoresandTech.Api.Dtos
{
  public class FileDto
  {
	public MemoryStream MemoryStream { get; set; }
	public int Size { get; set; }
  }
}
