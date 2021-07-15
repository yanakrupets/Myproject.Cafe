using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyProject.EfStuff.Model;
using MyProject.EfStuff.Repositories;
using MyProject.Models;
using MyProject.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    public class UserController : Controller
    {
        public IUserRepository _userRepository;
        public IUserService _userService;
        public IMapper _mapper;

        public UserController(IUserRepository userRepository, IUserService userService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            var model = new RegistrationViewModel();
            var returnUrl = Request.Query["ReturnUrl"];
            model.ReturnUrl = returnUrl;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = _userRepository.Get(model.Login);

            if (user == null || user.Password != model.Password)
            {
                return View(model);
            }

            await HttpContext.SignInAsync(
                _userService.GetPrincipal(user));

            if (!string.IsNullOrEmpty(model.ReturnUrl))
            {
                return Redirect(model.ReturnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Registration()
        {
            var model = new RegistrationViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var isUserUniq = _userRepository.Get(model.Login) == null;
            if (isUserUniq)
            {
                var user = _mapper.Map<User>(model);
                _userRepository.Save(user);

                await HttpContext.SignInAsync(
                    _userService.GetPrincipal(user));

                return RedirectToAction("Profile", "User");
            }

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Profile()
        {
            var user = _userService.GetCurrent();
            var viewModel = _mapper.Map<ProfileViewModel>(user);
            return View(viewModel);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult UpdateLang(string lang)
        {
            var user = _userService.GetCurrent();
            if (user != null)
            {
                user.Language = (Language)Enum.Parse(typeof(Language), lang);
                _userRepository.Save(user);
                return Json(true);
            }

            return Json(false);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Form()
        {
            var model = new UserFormViewModel();
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Form(UserFormViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            var user = _userService.GetCurrent();
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Birthday = model.Birthday ?? new DateTime();
            user.Email = model.Email;
            _userRepository.Save(user);

            return RedirectToAction("Profile", "User");
        }
    }
}
