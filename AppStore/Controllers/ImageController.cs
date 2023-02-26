using Microsoft.AspNetCore.Mvc;

namespace AppStore.Controllers
{
    public class ImageController : Controller
    {
        string path = @"C:\Users\user\source\repos\AppStore\AppStore\wwwroot\images\";//TODO: change path
        private List<string> images = new List<string>();
        public ImageController()
        {//get all file names and types from folder
            foreach (string f in Directory.GetFiles(path))
            {
                images.Add(Path.GetFileName(f));
            }
            images.Sort();
        }
        
    


        public FileResult Get(string name)
        {
            if(images.BinarySearch(name)<0)
                throw new FileNotFoundException("There is no image with name "+name);

            string path = Path.Combine(this.path, name);
            return PhysicalFile(path,"image/jpeg");
        }
        public IActionResult AddToDB()//TODO: image adding page
        {
            return View();
        }
    }
}
