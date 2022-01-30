using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Assignment.API.Models;

namespace Assignment.API.Models
{
    public class DALDbContext: DbContext
    {
        public DALDbContext(DbContextOptions<DALDbContext> options) : base(options)
        { }

        public DbSet<ChapterModel> chapterModels { get; set; }
        public DbSet<CategoryModel> categoryModels { get; set; }
        public DbSet<MappingModel> mappingModels { get; set; }
    }
}
