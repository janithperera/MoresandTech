using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MoresandTech.Api.Dtos;
using MoresandTech.Api.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MoresandTech.Api.Controllers
{
  [Route("api/[controller]")]
  [Consumes("application/json", "application/json-patch+json", "multipart/form-data")]
  [ApiController]
  public class ImagesController : ControllerBase
  {
	private readonly IImageEffectHandler imageEffectHandler;
	public ImagesController(IImageEffectHandler imageEffectHandler) 
	{
	  this.imageEffectHandler = imageEffectHandler;
	}

	/// <summary>
	/// Processes the image.
	/// </summary>
	/// <param name="files">The files.</param>
	/// <param name="filesData">The files data.</param>
	/// <returns></returns>
	[HttpPost("Process")]
	public ActionResult ProcessImage(ICollection<IFormFile> files, string filesData)
	{
	  var memoryStreams = new List<MemoryStream>();
	  var data = JsonConvert.DeserializeObject<List<FileDataDto>>(Base64UrlEncoder.Decode(filesData));
	  foreach (var file in files)
	  {

	  }
	  this.imageEffectHandler.effects[0].Apply(new MemoryStream(), 1);
	  return Ok();
	}
  }
}
