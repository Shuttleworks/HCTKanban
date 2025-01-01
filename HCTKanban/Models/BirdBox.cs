using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCTKanban.Models
{

	public class BirdBoxType
	{
		[Key]
		public int BirdBoxTypeId { get; set; }

		public required string BirdBoxName { get; set; }

		public ICollection<BirdBox> BirdBoxes { get; } = new List<BirdBox>();
	}

	public class BirdBox
	{
		[Key]
		public int BirdBoxId { get; set; }

		public int BirdBoxStatusId { get; set; }

		public string JSidentifier { get; set; } = "";

		public int BirdBoxTypeId { get; set; }

		public BirdBoxType? BirdBoxType { get; set; }
	}


	


	public class Status
	{
		[Key]
		public int StatusId { get; set; }

		public required string Name { get; set; }
	}
}
