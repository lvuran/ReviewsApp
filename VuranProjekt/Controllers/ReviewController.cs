using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Diagnostics;
using System.Security.Claims;
using VuranProjekt.Models;

namespace VuranProjekt.Controllers;



public class ReviewController(
       ReviewsAppDbContext _dbContext) : Controller
{

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Discover()
    {
        var reviews = _dbContext.reviews.
                Include(p => p.appUser).Include(p => p.Tag).Include(p => p.Genre)
                .ToList();
        return View(reviews);
    }



    [Authorize]
    public IActionResult Create()
    {

        ViewBag.AllTags = _dbContext.tags
        .Where(t => t.AppUserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
        .ToList();

        this.FillDropdownValues();
        this.FillTags();
        return View();
    }

    [HttpPost, Authorize]
    public IActionResult Create(Review model)
    {
        model.Created = DateTime.Now;
        model.AppuserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        Console.WriteLine(model);
        ModelState.Remove("Created");
        if (ModelState.IsValid)
        {

            _dbContext.reviews.Add(model);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Discover));
        }
        else
        {
            this.FillDropdownValues();
            this.FillTags();
            return View();
        }
    }

    private void FillDropdownValues()
    {
        var selectItems = new List<SelectListItem>();

        var listItem = new SelectListItem();
        listItem.Text = "- select -";
        listItem.Value = "";
        selectItems.Add(listItem);

        foreach (var genre in _dbContext.genres)
        {
            listItem = new SelectListItem(genre.Name, genre.Id.ToString());
            selectItems.Add(listItem);
        }

        ViewBag.PossibleGenres = selectItems;
    }

    private void FillTags()
    {
        var selectItems = new List<SelectListItem>();


        var listItem = new SelectListItem();
        listItem.Text = "- select -";
        listItem.Value = "";
        selectItems.Add(listItem);

        foreach (var tag in _dbContext.tags.Where(p => p.AppUserId == User.FindFirstValue(ClaimTypes.NameIdentifier)))
        {
            listItem = new SelectListItem(tag.Name, tag.Id.ToString());
            selectItems.Add(listItem);
        }

        ViewBag.PossibleTags = selectItems;
    }

    [ActionName(nameof(Edit))]
    public IActionResult Edit(int id)
    {
        var model = _dbContext.reviews.Include(p => p.Genre).Include(p => p.Tag).FirstOrDefault(c => c.Id == id);
        this.FillDropdownValues();
        this.FillTags();
        return View(model);
    }

    [HttpPost]
    [ActionName(nameof(Edit))]
    public async Task<IActionResult> EditPost(int id)
    {
        var review = _dbContext.reviews.Single(c => c.Id == id);
        var ok = await this.TryUpdateModelAsync(review);

        if (ok && this.ModelState.IsValid)
        {
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Discover));
        }

        return View();
    }


    public IActionResult Article(int id)
    {
        var model = _dbContext.reviews.Include(p => p.Genre).Include(p => p.Tag).Include(p => p.Comments)
        .ThenInclude(c => c.appUser).FirstOrDefault(p => p.Id == id);
        this.FillDropdownValues();
        this.FillTags();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PostComment(CommentViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return RedirectToAction("Article", new { id = model.ReviewId });
        }

        var user = User.FindFirstValue(ClaimTypes.NameIdentifier);

        var comment = new Comment
        {
            comment = model.Content,
            ReviewId = model.ReviewId,
            AppUserId = user,
            Created = DateTime.UtcNow
        };

        _dbContext.comments.Add(comment);
        await _dbContext.SaveChangesAsync();

        return RedirectToAction("Article", new { id = model.ReviewId });
    }
    public async Task<IActionResult> ByTag(int tagId)
    {
        var tag = await _dbContext.tags
            .Include(t => t.Reviews)
            .ThenInclude(r => r.Genre)
            .FirstOrDefaultAsync(t => t.Id == tagId);

        if (tag == null)
        {
            return NotFound();
        }

        ViewBag.TagName = tag.Name;
        return View("Discover", tag.Reviews.ToList());

    }

    [HttpPost]
    [ActionName(nameof(Delete))]
    public async Task<IActionResult> Delete(int id)
    {
        {
            var review = _dbContext.reviews.FirstOrDefault(a => a.Id == id);
            if (review != null)
            {


                _dbContext.reviews.Remove(review);
                _dbContext.SaveChanges();
            }
            var reviews = _dbContext.reviews.
               Include(p => p.appUser).Include(p => p.Tag).Include(p => p.Genre)
               .ToList();

            return View("Discover", reviews);
        }
    }
}
