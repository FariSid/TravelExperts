﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelExperts.Models;

namespace TravelExperts.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
            private Repository<Package> data { get; set; }
            public CheckoutController(TravelExpertsContext ctx) => data = new Repository<Package>(ctx);


            private Cart GetCart()
            {
                var cart = new Cart(HttpContext);
                cart.Load(data);
                return cart;
            }

            public ViewResult Index()
            {
                var cart = GetCart();
                var builder = new PackagesGridBuilder(HttpContext.Session);

                var vm = new CartViewModel
                {
                    List = cart.List,
                    Subtotal = cart.Subtotal,
                    PackageGridRoute = builder.CurrentRoute
                };
                return View(vm);
            }

            [HttpPost]
            public RedirectToActionResult Add(int id)
            {
                var package = data.Get(new QueryOptions<Package>
                {
                    //Include = "Supplier, Product",
                    Where = b => b.PackageId == id
                });
                if (package == null)
                {
                    TempData["message"] = "Unable to add package to cart.";
                }
                else
                {
                    var dto = new PackageDTO();
                    dto.Load(package);
                    CartItem item = new CartItem
                    {
                        Package = dto,
                        Quantity = 1  // default value
                    };

                    Cart cart = GetCart();
                    cart.Add(item);
                    cart.Save();

                    TempData["message"] = $"{package.PkgName} added to cart";
                }

                var builder = new PackagesGridBuilder(HttpContext.Session);
                return RedirectToAction("Index", "Cart", builder.CurrentRoute);
            }

            [HttpPost]
            public RedirectToActionResult Remove(int id)
            {
                Cart cart = GetCart();
                CartItem item = cart.GetById(id);
                cart.Remove(item);
                cart.Save();

                TempData["message"] = $"{item.Package.PkgName} removed from cart.";
                return RedirectToAction("Index");
            }

            [HttpPost]
            public RedirectToActionResult Clear()
            {
                Cart cart = GetCart();
                cart.Clear();
                cart.Save();

                TempData["message"] = "Cart cleared.";
                return RedirectToAction("Index");
            }


            public IActionResult Edit(int id)
            {
                Cart cart = GetCart();
                CartItem item = cart.GetById(id);
                if (item == null)
                {
                    TempData["message"] = "Unable to locate cart item";
                    return RedirectToAction("List");
                }
                else
                {
                    return View(item);
                }
            }

            [HttpPost]
            public RedirectToActionResult Edit(CartItem item)
            {
                Cart cart = GetCart();
                cart.Edit(item);
                cart.Save();

                TempData["message"] = $"{item.Package.PkgName} updated";
                return RedirectToAction("Index");
            }

            public ViewResult Checkout() => View();
        }
    }
