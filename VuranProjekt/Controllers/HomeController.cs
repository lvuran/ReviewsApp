using DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using System.Diagnostics;
using System.Security.Claims;
using VuranProjekt.Models;

namespace VuranProjekt.Controllers;

public class HomeController(ReviewsAppDbContext _dbContext, ILogger<HomeController> _logger) : Controller
{


  

    public IActionResult Index()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize]
	[Route("my-profile")]
	public IActionResult Profile()
	{
		var client = _dbContext.appUsers.Include(u => u.TagsCreated)
            .Where(p => p.Id == User.FindFirstValue(ClaimTypes.NameIdentifier))
			.FirstOrDefault();

		return View(client);
	
	}

	[ActionName(nameof(Edit))]
	public IActionResult Edit(string id)
	{
		var model = _dbContext.appUsers.FirstOrDefault(c => c.Id == id);
		
		return View(model);
	}

	[HttpPost]
	[ActionName(nameof(Edit))]
	public async Task<IActionResult> EditPost(string id)
	{
		var client = _dbContext.appUsers.Single(c => c.Id == id);
		var ok = await this.TryUpdateModelAsync(client);

		if (ok && this.ModelState.IsValid)
		{
			_dbContext.SaveChanges();
			return RedirectToAction(nameof(Index));
		}

	
		return View();
	}


    public async Task<IActionResult> GetTags()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var tags = await _dbContext.tags
            .Where(t => t.AppUserId == userId)
            .ToListAsync();

        return View(tags);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTag(string tagName)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (!string.IsNullOrEmpty(tagName))
        {
            var tag = new Tag
            {
                Name = tagName,
                AppUserId = userId
            };

            _dbContext.tags.Add(tag);
            await _dbContext.SaveChangesAsync();
        }

        return RedirectToAction("Profile");
    }

}
