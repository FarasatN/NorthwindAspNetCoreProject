using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MvcWebUI.Helpers;
using MvcWebUI.Models;

namespace MvcWebUI.Controllers
{
	public class CartController : Controller
	{
		private ICartService _cartService;
		private ICartSessionHelper _cartSessionHelper;
		private IProductService _productService;

		public CartController(ICartSessionHelper cartSessionHelper, ICartService cartService, IProductService productService)
		{
			_cartSessionHelper = cartSessionHelper;
			_cartService = cartService;
			_productService = productService;
		}



		public IActionResult AddToCart(int productId)
		{
			Product product = _productService.GetById(productId);
			var cart = _cartSessionHelper.GetCart("cart");
			_cartService.AddToCart(cart,product);
			_cartSessionHelper.SetCart("cart",cart);
			return RedirectToAction("Index", "Product");
		}

		public IActionResult RemoveFromCart(int productId)
		{
			Product product = _productService.GetById(productId);
			var cart = _cartSessionHelper.GetCart("cart");
			_cartService.RemoveFromCart(cart,productId);

			return RedirectToAction("Index", "Cart");
		}

		public IActionResult Index()
		{
			var model = new CartListViewModel
			{
				Cart = _cartSessionHelper.GetCart("cart")
			};

			return View(model);
		}

		public IActionResult Complete()
		{
			var model = new ShippingDetailsViewModel
			{
				ShippingDetail = new ShippingDetail()
			};
			return View(model);
		}

		[HttpPost]
		public IActionResult Complete(ShippingDetail shippingDetail)
		{
			if(!ModelState.IsValid)
			{
				return View();
			}
			TempData.Add("message", "Your order has sauccessfully completed!");
			_cartSessionHelper.Clear();

			return RedirectToAction("Index", "Cart");
		}
	}
}
