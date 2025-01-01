using System.ComponentModel.DataAnnotations;

namespace HCTKanban.Models
{
	public class Locations
	{
		[Key]
		public int LocationId { get; set; }

		[Required]
		public string? LocationName { get; set; }
	}
}
