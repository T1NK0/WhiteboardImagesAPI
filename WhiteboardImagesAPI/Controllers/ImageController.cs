using Microsoft.AspNetCore.Mvc;

namespace WhiteboardImagesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {

        [HttpGet(Name = "getImages")]
        public string GetImg()
        {
            //C:\Users\mtm\source\repos\WhiteboardImagesAPI\WhiteboardImagesAPI\Images\
            var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Images\");
            var random = new Random().Next(0, files.Length-1);
            byte[] imageArray = System.IO.File.ReadAllBytes(files[random]);
            string base64ImageRepresentation = Convert.ToBase64String(imageArray);
            Console.WriteLine("Api is sending image " + random.ToString());
            return base64ImageRepresentation;
        }
    }
}