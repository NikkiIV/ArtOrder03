//using ArtOrder03.Core.Models.Commission;
//using ArtOrder03.Infrastructure.Data;
//using Microsoft.AspNetCore.Mvc;

//namespace ArtOrder03.Controllers
//{
//    public class CommissionController : Controller
//    {
//        private readonly ApplicationDbContext data;

//        public CommissionController(ApplicationDbContext data)
//        {
//            this.data = data;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }
        
//        public IActionResult Success()
//        {
//            return View();
//        }

//        public IActionResult Add()
//        {           
//            return View();
//        }

//        [HttpPost]
//        public IActionResult Add(AddCommissionFormModel commission)
//        {
            
//            var commissionData = new Commission
//            {
//                Name = commission.Name,
//                Type = commission.Type,
//                Details = commission.Details,
//                Description = commission.Description
//            };

//            this.data.Commissions.Add(commissionData);
//            this.data.SaveChanges();

//            return RedirectToAction(nameof(Success));
//        }
//    }
//}
