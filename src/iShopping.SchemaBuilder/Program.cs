// See https://aka.ms/new-console-template for more information
using iShopping.Entities;
using iShopping.SchemaBuilder;
using Microsoft.EntityFrameworkCore;

AppDbContextFactory factory = new AppDbContextFactory();
AppDbContext dbContext = factory.CreateDbContext(args);
await dbContext.Database.MigrateAsync();