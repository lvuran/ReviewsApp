using System.ComponentModel.DataAnnotations;

namespace VuranProjekt.Models
{
	public class CommentViewModel
	{
		[Required]
		public string Content { get; set; }

		public int ReviewId { get; set; }
	}

}
