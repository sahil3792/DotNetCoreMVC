using System.Net;
using CodeFirstApproachSahil.Data;
using CodeFirstApproachSahil.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstApproachSahil.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext db;
        private IWebHostEnvironment env;
        public ProductController(ApplicationDbContext db, IWebHostEnvironment env) 
        {
            this.db = db;
            this.env = env;
        }

        public IActionResult Index()
        {
            var data=db.products.ToList();
            return View(data);
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel pm)
        {
            var path = env.WebRootPath;
            var filePath = "Content/Images/" + pm.Picture.FileName;
            var fullPath = Path.Combine(path, filePath);
            UploadFile(pm.Picture, fullPath);
            var obj = new Product()
            {
                Pname = pm.Pname,
                Pcat = pm.Pcat,
                Price = pm.Price,
                Picture = filePath
            };
            db.Add(obj);
            db.SaveChanges();
            TempData["msg"] = "Product Added Sucessfully";

            return RedirectToAction("Index");


        }
        public void UploadFile(IFormFile file,string fullPath)
        {
            FileStream stream = new FileStream(fullPath, FileMode.Create);
            file.CopyTo(stream);
        }
    }
}
