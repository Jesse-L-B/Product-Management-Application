using Microsoft.AspNetCore.Mvc;
using ProductManagementSystem.Services;
using ProductManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;

namespace ProductManagementSystem.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _tempdata;

        public ProductController(IProductRepository tempdata)
        {
            _tempdata = tempdata;
        }
        
        [Authorize (Roles = "Employee")]
        public IActionResult Details(int? id)
        {
            var product = _tempdata.GetProduct(id);
            if (id == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [Authorize (Roles ="Employee")]
        public IActionResult DisplayAll()
        {
            {
                IndexViewModel model = new IndexViewModel();
                model.Products = _tempdata.ReadAll();
                return View(model);
            }
        }

        [HttpGet]
        [Authorize (Roles ="Admin")] // prompt to login
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create (Product obj)
        {
            if (ModelState.IsValid)
            {
                _tempdata.AddProduct(obj);
                ViewBag.Message = "Product added successfully!";
            }
            return View(obj); 
        }
        [HttpGet]
        [Authorize (Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            Product obj = _tempdata.GetProduct(id);
            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(Product obj, int id)
        {
            obj.Id = id;
            _tempdata.UpdateProduct(obj);
            return RedirectToAction("DisplayAll");
        }
        [Authorize (Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            _tempdata.DeleteProduct(id);
            return RedirectToAction("DisplayAll");
        }


    }
}

