using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FcisArchiveBlazor.Areas.Identity.Pages.Account.Manage;

public class LoginInternal : ControllerBase
{
	private readonly UserManager<FCISQuestionsHub.Core.Models.StudentUser> _userManager;
	private readonly SignInManager<FCISQuestionsHub.Core.Models.StudentUser> _signInManager;

	public LoginInternal(
		UserManager<FCISQuestionsHub.Core.Models.StudentUser> userManager,
		SignInManager<FCISQuestionsHub.Core.Models.StudentUser> signInManager)
	{
		_userManager = userManager;
		_signInManager = signInManager;
	}


	[HttpGet("/Account/RefreshSignIn")]
	[Authorize]
	public async Task<IActionResult> Login(string id)
	{
		try
		{
			var user = await _userManager.FindByIdAsync(id);
			await _signInManager.RefreshSignInAsync(user);
			return Redirect("Manage?");
			return Redirect("Manage?");
			// return Ok("Refreshed SignIn Success");
		}
		catch (Exception ex)
		{
			return BadRequest(ex.Message);
		}
	}
}

