using Microsoft.AspNetCore.Mvc;

namespace WhiteboardImagesAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ImageController : ControllerBase
    {
        private static List<string> _images = new List<string>();

        public ImageController()
        {
            if (_images.Count == 0)
            {
                var files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + @"Images\");

                foreach (var file in files)
                {
                    byte[] imageFileToByteArray = System.IO.File.ReadAllBytes(file);
                    string base64FileToString = Convert.ToBase64String(imageFileToByteArray);
                    _images.Add(base64FileToString);
                }
            }
        }

        [HttpGet(Name = "get")]
        public string GetImg()
        {
            var random = new Random().Next(0, _images.Count-1);
            string randomImageBase64 = _images[random];

            Console.WriteLine("Api is sending image " + random.ToString());
            return randomImageBase64;

        }

        [HttpPost(Name = "save")]
        public IActionResult SaveImg([FromForm]string image)
        {;
            _images.Add(image);
            Console.WriteLine("Api saved image");
            return Ok();
        }

    }
}