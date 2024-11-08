﻿using IkJetApp.Areas.Personnel.Models;
using IkJetApp.Helpers;
using IkJetApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace IkJetApp.Areas.HRManager.Controllers
{
    [Area("HRManager")]
    [Authorize(Roles = "HRManager")]
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly AuthenticatedUser _authenticatedUser;

        public HomeController(IHttpClientFactory httpClientFactory, AuthenticatedUser authenticatedUser)
        {
            _httpClientFactory = httpClientFactory;
            _authenticatedUser = authenticatedUser;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userViewModel= await _authenticatedUser.GetUserByIdAsync(userId);

            return View(userViewModel);
        }



    }
}
