using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace HCTKanban.Models
{
	public class NewBoxDTO
	{
		public int TypeId { get; set; }

		public string JsId { get; set; } = "";
	}

	public class BoxStatusDTO
	{
		public int StatusId { get; set; }

		public string JsId { get; set; } = "";
	}

	public class BoxDataDTO
	{
		public string Id { get; set; } = "";

		public string Content { get; set; } = "";

		public string Status { get; set; } = "";
	}
}
