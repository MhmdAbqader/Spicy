using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using spice.Data;
using spice.Models;
using spice.Utility;

namespace spice.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RegisterModel( ApplicationDbContext db,
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _roleManager = roleManager;
        }
       

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
         
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required,MaxLength(10)]
            public string Name { get; set; }

            public string Streataddress { get; set; }
            public string PostalCode { get; set; }
            public string City { get; set; }

            public string State { get; set; }
            [Required]
            public string PhoneNumber { get; set; }
            public string Role { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    Name=Input.Name,
                    UserName = Input.Email,
                    Email = Input.Email,
                    City = Input.City,  
                    State = Input.State,
                    PhoneNumber = Input.PhoneNumber,
                    Streataddress = Input.Streataddress,
                    PostalCode = Input.PostalCode,                    
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    
                    if (! await _roleManager.RoleExistsAsync(SD.ManagerRoleUser))
                    {
                       await _roleManager.CreateAsync(new IdentityRole(SD.ManagerRoleUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.KitchenRoleUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.KitchenRoleUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.CustomerRoleUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.CustomerRoleUser));
                    }
                    if (!await _roleManager.RoleExistsAsync(SD.ForntDescRoleUser))
                    {
                        await _roleManager.CreateAsync(new IdentityRole(SD.ForntDescRoleUser));
                    }

                    // await  _userManager.AddToRoleAsync(user,SD.ManagerRoleUser);

                    string role = Input.Role;

                    if (role  == null)
                    {
                        await _userManager.AddToRoleAsync(user, SD.CustomerRoleUser);
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user , role );
                    }

                    return RedirectToAction("Index","Users",new { Areas="Admin" });

                    /*_logger.LogInformation("User created a new account with password.");

                    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    //code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    //var callbackUrl = Url.Page(
                    //    "/Account/ConfirmEmail",
                    //    pageHandler: null,
                    //    values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                    //    protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                     $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");
                     */

                    if(_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
