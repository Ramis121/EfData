using Domain.Model;
using EfData.Data_;
using EfData.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EfData.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AplicationContext context;

        public HomeController(ILogger<HomeController> logger, AplicationContext context)
        {
            _logger = logger;
            this.context = context
                ?? throw new ArgumentException(nameof(context));
        }

        public IActionResult Index()
        {
            return View(context.users.ToList());
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                var res = await context.users.FirstOrDefaultAsync(a => a.id == id);
                if (res != null)
                    return View(res);
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user)
        {
            context.users.Update(user); 
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> Delete_User(int? id)
        {
            if (id != null)
            {
                var res = await context.users.FirstOrDefaultAsync(a => a.id == id);
                if (res != null)
                    return View(res);
            }
            return BadRequest();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                var res = await context.users.FirstOrDefaultAsync(a => a.id == id);
                if (res != null)
                {
                    context.users.Remove(res);
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return BadRequest();
        }

        public async Task<IActionResult> Deteils(int? id)
        {
            if (id != null)
            {
                var res = await context.users.FirstOrDefaultAsync(a => a.id == id);
                return View(res);
            }
            return BadRequest();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
