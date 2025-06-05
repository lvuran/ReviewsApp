using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;

namespace VuranProjekt.Controllers
{
    [Route("api/review")]
    [ApiController]
    public class ReviewApiController(
         ReviewsAppDbContext _dbContext) : Controller
    {


        [HttpGet]
        public List<ReviewDTO> Get()
        {
            var reviews = new List<ReviewDTO>();
            var reviewQuery = _dbContext.reviews.Include(p => p.Genre).Include(p=>p.appUser).AsQueryable();

            foreach (var review in reviewQuery)
            {
                reviews.Add(convert(review));
            }
            return reviews;
        }

        public ReviewDTO convert(Model.Review review)
        {
            var osvrt = new ReviewDTO();
            osvrt.review = review.review;
            osvrt.Title = review.Title;
            osvrt.Read = review.Read;
            var korisnik = new UserDTO();
            korisnik.id = review.AppuserId;
            if(review.appUser!=null)
            korisnik.username = review.appUser.UserName;
            osvrt.appUser = korisnik;
            if (review.Genre != null)
            {
                osvrt.Genre = new GenreDTO
                {
                    id = review.GenreId ?? 0, 
                    name = review.Genre.Name
                };
            }
            osvrt.Author = review.Author;
            osvrt.Id = review.Id;
            return osvrt;
        }

        [HttpGet("{id}")]
        public ReviewDTO Get(int id)
        {
            var osvrt = new ReviewDTO();
            var osvrtQuery = _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser).AsQueryable().Where(p => (p.Id == id));
            foreach (var review in osvrtQuery)
            {
                osvrt = convert(review);
            }

            return osvrt;

        }

        [HttpGet("pretraga/{q}")]
        public List<ReviewDTO> Get(string q)
        {
            var reviews = new List<ReviewDTO>();
            var reviewQuery = _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser).AsQueryable();

            reviewQuery = reviewQuery.Where(p => (p.Title).ToLower().Contains(q.ToLower()));

            foreach (var osvrti in reviewQuery)
            {
                reviews.Add(convert(osvrti));
            }
            return reviews;
        }


        [HttpPost]
        public async Task<ActionResult<ReviewDTO>> Post([FromBody] Model.Review model)
        {

      
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          
            var review = new Model.Review
            {
                Title = model.Title,
                AppuserId = model.AppuserId,
                Author = model.Author,
                Read = model.Read,
                review = model.review,
                Id = model.Id,
                GenreId = model.GenreId,
                Created = model.Created
            };

            _dbContext.reviews.Add(review);
            await _dbContext.SaveChangesAsync();

         
            var createdReview = await _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser)
                .FirstOrDefaultAsync(c => c.Id == review.Id);

            var reviewDTO = convert(createdReview);

            return CreatedAtAction(nameof(Get), new { id = reviewDTO.Id }, reviewDTO);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReviewDTO>> Put(int id, [FromBody] Model.Review model)
        {
            if (id != model.Id)
            {
                return BadRequest("ID mismatch.");
            }

            var review = await _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (review == null)
            {
                return NotFound();
            }

            review.Title = model.Title;
                review.AppuserId = model.AppuserId;
                review.Author = model.Author;
                review.Read = model.Read;
                review.review = model.review;
            review.Id = model.Id;
                review.GenreId = model.GenreId;
               review.Created = model.Created;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "An error occurred while updating the review.");
            }

       
            var updatedClient = await _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser)
                .FirstOrDefaultAsync(c => c.Id == id);

            return Ok(convert(updatedClient));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            
            var review = _dbContext.reviews.Include(p => p.Genre).Include(p => p.appUser).FirstOrDefaultAsync(p => p.Id == id);

           
            if (review == null)
            {
                return NotFound($"Review with ID {id} not found.");
            }

       
            _dbContext.reviews.Remove(await review);

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
          
                return StatusCode(500, $"Error deleting review: {ex.Message}");
            }


            return Ok();
        }

    }
}
