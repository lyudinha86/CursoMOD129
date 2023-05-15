using CursoMOD129.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace CursoMOD129.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }


        public DbSet<Cliente> Clients { get; set; } = default!;
        public DbSet<WorkRole> WorkRoles { get; set; } = default!;
        public DbSet<TeamMember> TeamMembers { get; set; } = default!;

        public DbSet<Appointment> Appointments { get; set; } = default;
       
    }
}