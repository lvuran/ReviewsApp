using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }


		[ForeignKey(nameof(AppUser))]
		public string? AppUserId { get; set; }
		public AppUser? appUser { get; set; }

		[ForeignKey(nameof(Review))]
		public int? ReviewId { get; set; }
		public Review? Review { get; set; }


		[Required]
		public string comment { get; set; } = "";


	
		public DateTime? Created { get; set; } = DateTime.UtcNow;

	}
}
