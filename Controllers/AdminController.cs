using Abc.Northwind.Business.Abstract;
using Abc.Northwind.Entitites.Concrete;
using Abc.Northwind.MvcWebbUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Abc.Northwind.MvcWebbUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;

        public AdminController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }
            public IActionResult Index()
        {
            var productListViewModel = new ProductListViewModel
            {
                Products = _productService.GetAll()
            };
            return View(productListViewModel);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            _productService.Add(product);
            TempData.Add("message", "okey");
            return View();
        }
        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel
            {
                Product = _productService.GetById(productId),
                Categories = _categoryService.GetAll()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Ürün Güncellendi");
                
            }
            return RedirectToAction("Update");
        }
        public ActionResult Delete(int productId)
        {
            var product = _productService.GetById(productId);
            _productService.Delete(product);
            TempData.Add("message", "Ürün Silindi");
            return RedirectToAction("Index");
        }
            /*
             * 
             *             var product = _productService.GetById(productId);
            _productService.Delete(product);
            TempData.Add("message", "Ürün Silindi");
            return RedirectToAction("Index");
             *             _productService.Delete(Product);
            TempData.Add("message", "okey");            _productService.Delete(productId);
            TempData.Add("message", "Ürün Silindi");
            return RedirectToAction("Index");

                       
            var product = _productService.GetById(productId);
            _productService.Delete(product);
            TempData.Add("message", "Ürün Silindi");
            return RedirectToAction("Index");
            */
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
    
    }
}

    
