// See https://aka.ms/new-console-template for more information
using iShopping.Entities;
using iShopping.SchemaBuilder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using static System.Formats.Asn1.AsnWriter;

AppDbContextFactory factory = new AppDbContextFactory();
AppDbContext dbContext = factory.CreateDbContext(args);
await dbContext.Database.MigrateAsync();