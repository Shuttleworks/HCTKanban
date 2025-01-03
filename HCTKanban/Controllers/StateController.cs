using HCTKanban.Data;
using HCTKanban.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HCTKanban.Controllers
{
	public class StateController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IHttpContextAccessor _httpContext;

		public StateController(ApplicationDbContext context, IHttpContextAccessor httpContext)
		{
			_context = context;
			_httpContext = httpContext;
		}

		//public IActionResult Index()
		//{
		//	return View();
		//}

		

		[HttpPost]
		public void AddBox([FromBody] NewBoxDTO newBox)
		{
			if (_httpContext.HttpContext != null && _httpContext.HttpContext.User.Identity != null)
			{
				if (_httpContext.HttpContext.User.Identity.IsAuthenticated!)
				{
					BirdBox newbox = new BirdBox() { BirdBoxTypeId =newBox.TypeId, BirdBoxStatusId = 1, JSidentifier = newBox.JsId };

					_context.BirdBox.Add(newbox);

					_context.SaveChanges();
				}
			}
			else
			{
				Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			}
			

		}

		[HttpPost]
		public void UpdateStatus([FromBody] BoxStatusDTO boxstatus)
		{
			if (_httpContext.HttpContext != null && _httpContext.HttpContext.User.Identity != null)
			{
				if (_httpContext.HttpContext.User.Identity.IsAuthenticated!)
				{
					BirdBox? boxupdate = _context.BirdBox.FirstOrDefault(x => x.JSidentifier == boxstatus.JsId);

					if (boxupdate != null) {
						boxupdate.BirdBoxStatusId = boxstatus.StatusId;
						_context.SaveChanges();
					}

				}
			}else
			{
				Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			}

			
			
		}

		[HttpPost]
		public void DeleteBox([FromBody] string jsboxId)
		{
			if (_httpContext.HttpContext != null && _httpContext.HttpContext.User.Identity != null)
			{
				if (_httpContext.HttpContext.User.Identity.IsAuthenticated!)
				{
					BirdBox? boxupdate = _context.BirdBox.FirstOrDefault(x => x.JSidentifier == jsboxId);

					if (boxupdate != null)
					{
						_context.BirdBox.Remove(boxupdate);
						_context.SaveChanges();
					}
				}
			} else
			{
				Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			}

			
			
		}

		[HttpGet]
		public JsonResult GetBoxData()
		{
			if (_httpContext.HttpContext != null && _httpContext.HttpContext.User.Identity != null)
			{
				if (_httpContext.HttpContext.User.Identity.IsAuthenticated!)
				{
					List<BirdBox> boxes = _context.BirdBox.Where(x => !String.IsNullOrEmpty(x.JSidentifier)).Include(s => s.BirdBoxType).ToList();

					List<BoxDataDTO> boxdata = new List<BoxDataDTO>();
					foreach (BirdBox box in boxes)
					{
						boxdata.Add(new BoxDataDTO() { Id = box.JSidentifier, Content = box.BirdBoxType.BirdBoxName ?? "", Status = box.BirdBoxStatusId.ToString() });
					}

					return Json(boxdata);
				}
			}

			Response.StatusCode = (int)HttpStatusCode.Unauthorized;
			return Json(new { ErrorMessage = "Unauthorized Access" });

		}
	}
}
