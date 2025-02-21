using System.Globalization;
using Exemplo.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var services =  new ServiceCollection();

services.AddDbContext<ExampleDbContext>(options =>{

    // options.UseInMemoryDatabase("my-inmemory-database");

    var connBuilder = new SqlConnectionStringBuilder{
        TrustServerCertificate = true,
        IntegratedSecurity = true,
        DataSource = "localhost",
        InitialCatalog = "MyExampleDatabase",
    };

    options.UseSqlServer(connBuilder.ConnectionString);
});

var provider = services.BuildServiceProvider();

var scope = provider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ExampleDbContext>();
context.Database.EnsureCreated();

var obj1 = new EntityA{
    Name = "Trevisan"
};

var obj2 = new EntityA{
    Name = "Kauane"
};

var obj3 = new EntityB{
    Name = "Machado"
};

var obj4 = new EntityB{
    Name = "Martelo"
};



obj1.EntityBs.Add(obj3);
obj1.EntityBs.Add(obj4);
obj2.EntityBs.Add(obj4);

context.Add(obj1);
context.Add(obj2);
context.Add(obj3);
context.Add(obj4);
await context.SaveChangesAsync();



foreach (var person in context.EntityAs)
{
    Console.WriteLine($"{person.Name} tem:\n");
    foreach (var tool in person.EntityBs)
    {
        Console.WriteLine($"\t{tool.Name}");
    }
}


// Ja é tratado contra SqlInjection, e nao é link, o que o torna mais performatico
// var item = context.EntityAs
// .Where(x => x.Name == "Trevisan")
// .Select(x => x.Id);
// var item = from x in context.EntityAs
// where x.Name == "Trevisan"
// select x.Id;
