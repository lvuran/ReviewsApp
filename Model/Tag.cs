using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Tag
    {
		[Key]
		public int Id { get; set; }
		public string Name { get; set; }

		[ForeignKey(nameof(AppUser))]
		public string? AppUserId { get; set; }
		public AppUser? appUser { get; set; }

		public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
