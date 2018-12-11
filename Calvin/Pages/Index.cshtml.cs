using Calvin.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Calvin.Pages
{
    public class LoginForm
    {
        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string Username { set; get; }

        [Required]
        [StringLength(64)]
        public string Password { set; get; }
    }

    public class IndexModel : PageModel
    {
        private readonly MathService MathMan;

        [BindProperty]
        public LoginForm Form { set; get; }

        [TempData]
        public string SuccessMessage { set; get; }

        public IndexModel(MathService mathService)
        {
            this.MathMan = mathService;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            // insert ke database
            this.SuccessMessage = "Berhasil hore";
            return RedirectToPage();
        }
    }
}