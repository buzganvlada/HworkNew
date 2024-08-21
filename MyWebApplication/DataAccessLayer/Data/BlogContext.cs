using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class BlogContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<WeatherForecast> WeatherForecast { get; set; }

    public string DbPath { get; }

    public BlogContext()
    {
        var path = @"D:\C# Course\HworkNew\MyWebApplication\DataAccessLayer\Migrations";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        DbPath = Path.Combine(path, "blog.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}