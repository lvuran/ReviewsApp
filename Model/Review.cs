using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        
        public string Title { get; set; }

		[ForeignKey(nameof(AppUser))]
		public string? AppuserId { get; set; }
		public AppUser? appUser { get; set; }
		public string Author { get; set; }


		[ForeignKey(nameof(Genre))]
		public int? GenreId { get; set; }
		public Genre? Genre { get; set; }


		[Required]
		public string review { get; set; } = "";


		[Required]
		public DateTime? Read { get; set; }

		
		
		public DateTime? Created { get; set; }
	

		public List<Comment> Comments { get; set; } = new();
        [ForeignKey(nameof(Tag))]
        public int? TagId { get; set; }
        public Tag? Tag { get; set; }

    }
}
