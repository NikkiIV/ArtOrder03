using ArtOrder03.Core.Models.Commission;
using ArtOrder03.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace ArtOrder03.Controllers
{
    public class CommissionInfoController : Controller
    {
        private readonly ApplicationDbContext data;

        public CommissionInfoController(ApplicationDbContext data)
        {
            this.data = data;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Success()
        {
            return View();
        }

        public IActionResult Add()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddCommissionFormModel commission)
        {
            
            var commissionData = new CommissionInfo
            {
                Name = commission.Name,
                Type = commission.Type,
                Details = commission.Details,
                Description = commission.Description
            };

            this.data.CommissionInfos.Add(commissionData);
            this.data.SaveChanges();

            return RedirectToAction(nameof(Success));
        }
    }
}
