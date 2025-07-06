using Microsoft.EntityFrameworkCore;
using Shifts_Logger.Models;

namespace Shifts_Logger.Data;

public class ShiftsDbContext : DbContext
{
    public ShiftsDbContext(DbContextOptions<ShiftsDbContext> options)
        : base(options) { }

    public DbSet<Shift> Shifts { get; set; }

    public void SeedData()
    {
        Shifts.RemoveRange(Shifts);
        Shifts.AddRange(
            new Shift
            {
                EmployeeName = "Alice Smith",
                Position = "Manager",
                ShiftNumber = 1,
                StartTime = DateTime.Now.AddHours(-8),
                EndTime = DateTime.Now.AddHours(-4),
            },
            new Shift
            {
                EmployeeName = "Bob Johnson",
                Position = "Cashier",
                ShiftNumber = 2,
                StartTime = DateTime.Now.AddHours(-6),
                EndTime = DateTime.Now.AddHours(-2),
            },
            new Shift
            {
                EmployeeName = "Charlie Brown",
                Position = "Stock Clerk",
                ShiftNumber = 3,
                StartTime = DateTime.Now.AddHours(-5),
                EndTime = DateTime.Now.AddHours(-1),
            }
        );

        SaveChanges();
    }
}
