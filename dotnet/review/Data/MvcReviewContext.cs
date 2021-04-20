using Microsoft.EntityFrameworkCore;
using review.Models;

namespace review.Data
{
    public class MvcReviewContext : DbContext
    {
        public MvcReviewContext (DbContextOptions<MvcReviewContext> options)
            : base(options)
        {
        }

        public DbSet<Review> Review { get; set; }
    }
}