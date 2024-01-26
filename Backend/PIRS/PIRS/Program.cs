using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PIRS.Models;
using PIRS.Models.TransactionModel;
using PIRS.Models.UserModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();

builder.Services.AddDbContext<PirsContext>(options => {
    options.UseSqlServer(builder.Configuration.
        GetConnectionString("MyConnection"));
});



builder.Services.AddIdentity<AppUser, IdentityRole>().
AddEntityFrameworkStores<PirsContext>().
AddDefaultTokenProviders();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
