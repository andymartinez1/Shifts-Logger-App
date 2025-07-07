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
                StartTime = new DateTime(2025, 7, 6, 0, 0, 0),
                EndTime = new DateTime(2025, 7, 6, 8, 0, 0),
            },
            new Shift
            {
                EmployeeName = "Bob Johnson",
                Position = "Cashier",
                ShiftNumber = 2,
                StartTime = new DateTime(2025, 7, 6, 8, 0, 0),
                EndTime = new DateTime(2025, 7, 6, 16, 0, 0),
            },
            new Shift
            {
                EmployeeName = "Charlie Brown",
                Position = "Stock Clerk",
                ShiftNumber = 3,
                StartTime = new DateTime(2025, 7, 6, 16, 0, 0),
                EndTime = new DateTime(2025, 7, 7, 0, 0, 0),
            }
        );

        SaveChanges();
    }
}
