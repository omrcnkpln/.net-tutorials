// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

ApplicationDbContext context = new();
//var aaa = new Type()
//{
//    Name = "test"
//};

//context.Types.Add(aaa);
//context.Types.Add(aaa); // ama bi tane ekler
//context.Types.Add(aaa);


//context.SaveChanges();

var tipler = await context.Types.ToListAsync();
var tipler2 = await context.Types.ToListAsync();
tipler[0].Name = "test";
context.Types.Remove(tipler[1]);
tipler[2].Name = "deneme";

var datas = context.ChangeTracker.Entries();

Console.WriteLine();

public class Type
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Mattress
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ApplicationDbContext : DbContext
{
    public DbSet<Type> Types { get; set; }
    public DbSet<Mattress> Mattresss { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("User ID=postgres;Password=;Server=;Port=5432;Database=omrcnkplnTest;Integrated Security=true;Pooling=true;");
    }
}

