﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class BloggerDBContext : DbContext
    {
        public BloggerDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
    }
}
