
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AppUser : IdentityUser
    {

        public string? Name { get; set; }

        public Boolean IsAdmin { get; set; }
        
        public string? About {  get; set; }

	

		public virtual ICollection<Comment>? UserComments { get; set; }
		public virtual ICollection<Review>? UserReviews { get; set; }
        public virtual ICollection<Tag>? TagsCreated { get; set; }


    }
}
