using Model;

namespace VuranProjekt.Models
{


    public class CreateReviewViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int? GenreId { get; set; }
        public DateTime Read { get; set; }
        public string review { get; set; }

    
        public List<int> SelectedTagIds { get; set; } = new();


        public List<Tag> AvailableTags { get; set; } = new();
    }

}
