using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PIRS.Models;
using PIRS.Models.ReportModel;
using PIRS.Models.TransactionModel;
using PIRS.Models.UserModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PirsContext>(options => {
    options.UseSqlServer(builder.Configuration.
        GetConnectionString("MyConnection"))
    .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
    options.EnableSensitiveDataLogging();
});


builder.Services.AddIdentity<AppUser, IdentityRole>().
AddEntityFrameworkStores<PirsContext>().
AddDefaultTokenProviders();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
