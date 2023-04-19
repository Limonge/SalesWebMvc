using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController (SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] // indica que a ação é post
        [ValidateAntiForgeryToken] // para evitar ataques CRSF
        public IActionResult Create (Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index)); // redireciona para Index 
        }
    }
}
