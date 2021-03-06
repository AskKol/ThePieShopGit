﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThePieShopGit.Models;

namespace ThePieShopGit.Controllers
{
    public class OrderController:Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingcart;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingcart)
        {
            _orderRepository = orderRepository;
            _shoppingcart = shoppingcart;
        }

        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            var items = _shoppingcart.GetShoppingCartItems();
            _shoppingcart.ShoppingCartItems = items;

            if (_shoppingcart.ShoppingCartItems.Count==0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingcart.ClearCart();
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicioso pie(s)!";
            return View();
        }
    }
}
