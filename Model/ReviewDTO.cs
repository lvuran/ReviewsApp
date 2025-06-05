using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ReviewDTO
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

     
        public UserDTO? appUser { get; set; }
        public string Author { get; set; }


      
        public GenreDTO? Genre { get; set; }


  
        public string review { get; set; } = "";


        public DateTime? Read { get; set; }


       

    }
}
