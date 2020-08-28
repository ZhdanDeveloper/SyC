using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Syc.Persistence;
using SyC.Entity;
using SyC.Services.Interfaces;
using SyCC.Models;

namespace SyCC.Controllers
{
    public class HomeController : Controller
    {
        private SycContext _context;
        private readonly ILogger<HomeController> _logger;
        private IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IContactService contactService, SycContext context)
        {
            _logger = logger;
            _context = context;
            _contactService = contactService;
        }

        [Authorize]
        public IActionResult Index()
        {
             ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst("Id").Value;
            var ContactList = _contactService.GetAllById(Convert.ToInt32(currentUserId));
            return View(ContactList);
        }
        [Authorize]
        public IActionResult CreateContact()
        {
            return View();
        }
        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateContact(ContactModel model)
        {


            if (ModelState.IsValid)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserId = currentUser.FindFirst("Id").Value;

                var Contact = new Contact
                {

                    FirstName = model.FirstName,
                    LasttName = model.LastName,
                    Phone = model.Phone,
                    UserId = Convert.ToInt32(currentUserId)


                };
               await _contactService.CreateAsync(Contact);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult ViewAll()
        {
           

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst("Id").Value;
            var contactColect = _contactService.GetAllById(Convert.ToInt32(currentUserId));
            
            return View(from customer in _context.Contacts where customer.UserId == Convert.ToInt32(currentUserId) select customer);
        }
    
       public async Task<IActionResult> Delete(int id)
       {
            await _contactService.DeleteById(id);
            return RedirectToAction("Index");
       }


        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }
            ContactModel model = new ContactModel
            {
                Id = contact.Id,
                FirstName = contact.FirstName,
                LastName = contact.LasttName,
                Phone =  contact.Phone,

            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ContactModel model)
        {

            var contact = _contactService.GetById(model.Id);
            contact.FirstName = model.FirstName;
            contact.LasttName = model.LastName;
            contact.Phone = model.Phone;
            await _contactService.UpdateAsync(contact);
            return RedirectToAction("Index");
        }


        public IActionResult ViewDetails(int id)
        {
            var contact = _contactService.GetById(id);
            ContactModel model = new ContactModel
            {
                FirstName = contact.FirstName,
                LastName = contact.LasttName,
                Phone = contact.Phone,
                Id = contact.Id
            };
            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
