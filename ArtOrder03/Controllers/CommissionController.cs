﻿using ArtOrder03.Core.Models.Commission;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ArtOrder03.Controllers
{
    public class CommissionController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommissionController(ApplicationDbContext data)
        {
            this.data = data;
        }
                
        public IActionResult Success()
        {
            return View();
        } 
        
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCommissionFormModel commission)
        {            
            var commissionData = new Commission
            {
                Name = commission.Name,
                Type = commission.Type,
                Details = commission.Details,
                Description = commission.Description,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            };

            this.data.Commissions.Add(commissionData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(Success));
        }

        public IActionResult All()
        {
            var commissions = this.data.Commissions
               .OrderBy(s => s.Id)
               .Select(s => new CommissionListingViewModel
               {
                   Id = s.Id,
                   Name = s.Name,
                   Type = s.Type,
                   Details = s.Details,
                   Description = s.Description,

               }).ToList();

            return View(commissions);
        }

        [Authorize]
        public IActionResult MyCommissions()
        {
            var commissionsQuery = this.data.Commissions.AsQueryable();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var commissions = commissionsQuery
                .Where(r => r.UserId == userId)
                .Select(r => new CommissionListingViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                    Type = r.Type,
                    Details = r.Details,
                    Description = r.Description,

                }).ToList();

            var returnModel = new UserCommissionViewModel
            {
                UserId = userId,
                Commissions = commissions
            };

            return View(returnModel);
        }

    }
}
