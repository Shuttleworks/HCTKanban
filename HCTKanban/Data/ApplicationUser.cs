using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace HCTKanban.Data
{
	public class ApplicationUser
	{
		[Key]
		public int UserId { get; set; }
		public required string Email { get; set; }
		public required string Name { get; set; }

		public string Password { get; set; } = string.Empty;

		public string Salt { get; set; } = string.Empty;
	}
}
