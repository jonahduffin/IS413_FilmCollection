using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace joel_hilton_film_collection.Models
{
    public class MovieSubmissionDbContext : DbContext
    {
        public MovieSubmissionDbContext (DbContextOptions<MovieSubmissionDbContext> options) : base (options)
        {

        }

        public DbSet<MovieSubmissionResponse> Submissions { get; set; }
    }
}
