using HCTKanban.Data;
using HCTKanban.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HCTKanban.Controllers
{
	public class StateController : Controller
	{
		private readonly ApplicationDbContext _context;

		public StateController(ApplicationDbContext context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public void HelloWorld()

		{

			Locations newlocation = new Locations() { LocationName = "Hello World" };

			_context.Locations.Add(newlocation);

			_context.SaveChanges();

		}


		[HttpPost]
		public void AddBox([FromBody] NewBoxDTO newBox)
		{

			BirdBox newbox = new BirdBox() { BirdBoxTypeId =newBox.TypeId, BirdBoxStatusId = 1, JSidentifier = newBox.JsId };

			_context.BirdBox.Add(newbox);

			_context.SaveChanges();

			
		}

		[HttpPost]
		public void UpdateStatus([FromBody] BoxStatusDTO boxstatus)
		{

			BirdBox? boxupdate = _context.BirdBox.FirstOrDefault(x => x.JSidentifier == boxstatus.JsId);

			if (boxupdate != null) {
				boxupdate.BirdBoxStatusId = boxstatus.StatusId;
				_context.SaveChanges();
			}

		}

		[HttpPost]
		public void DeleteBox([FromBody] string jsboxId)
		{		
			BirdBox? boxupdate = _context.BirdBox.FirstOrDefault(x => x.JSidentifier == jsboxId);

			if (boxupdate != null)
			{
				_context.BirdBox.Remove(boxupdate);
				_context.SaveChanges();
			}

		}

		[HttpGet]
		public JsonResult GetBoxData()
		{
			List<BirdBox> boxes = _context.BirdBox.Where(x => !String.IsNullOrEmpty(x.JSidentifier)).Include(s => s.BirdBoxType).ToList();

			List<BoxDataDTO> boxdata = new List<BoxDataDTO>();
			foreach (BirdBox box in boxes)
			{
				boxdata.Add(new BoxDataDTO() { Id = box.JSidentifier, Content = box.BirdBoxType.BirdBoxName ?? "", Status = box.BirdBoxStatusId.ToString()});
			}

			return Json(boxdata);

		}
	}
}
