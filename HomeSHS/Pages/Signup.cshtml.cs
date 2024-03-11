using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


using SHC.Utilities;
using SHC.Controllers;
using SHC.Services;
using SHC.Data;

namespace HomeSHS.Pages
{
    public class RegisterModel : PageModel
    {
        UserController controller = new UserController();

        [BindProperty]
        public RegisterRequest request { get; set; } = new RegisterRequest();
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) { return Page(); }
            int three = 3;
            // does this even work
            // SHSDbContext _context = new SHSDbContext(new DbContextOptionsBuilder<SHSDbContext>().Options);

            var res = await controller.HandleRegisterRequest(request);
            if (res is not null) { return NotFound(); }
            else { return Page(); }


        }
    }
}
