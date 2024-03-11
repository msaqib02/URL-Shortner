using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection;
using url_shortner.Models;

public class UrlShortnerContext : DbContext
{
    public DbSet<ShortUrls> ShortUrls { get; set; }
    public UrlShortnerContext(DbContextOptions<UrlShortnerContext> options) : base(options)
    {

    }
}
