﻿using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContext: DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

    }
}