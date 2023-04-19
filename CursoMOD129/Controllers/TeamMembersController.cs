using CursoMOD129.Data;
using CursoMOD129.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CursoMOD129.Controllers
{
    public class TeamMembersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public TeamMembersController(ApplicationDbContext context) 
        {
            _context=context;
        }

        public IActionResult Index()
        {
            var teamMembers = _context
                .TeamMembers
                .Include(tm => tm.WorkRole)
                .ToList();
            foreach (var teamMember in teamMembers)
            {
                var x = teamMember.IsSpecialtyValid(_context);
            Console.WriteLine(x);
            }

            return View(teamMembers);
        }
        
        //Get:TeamMembers/Create

        public IActionResult Create()
        {

            ViewData["WorkRoleID"] = new SelectList(_context.WorkRoles, "ID", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TeamMember newTeamMember ) 
        {
            if(newTeamMember.IsSpecialtyValid(_context))
            {
                ViewData["IaSpecialtyValidError"] = "Specialty is not valid!";
            }
            if(ModelState.IsValid )
            {

                _context.Add(newTeamMember);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            ViewData["WorkRoleID"] = new SelectList(_context.WorkRoles, "ID", "Name");
            return View(newTeamMember);

        }
    }
}
