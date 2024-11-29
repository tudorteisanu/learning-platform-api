using LearningPlatform.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.Configure<RouteOptions>(options => { 
    options.LowercaseUrls = true;
}); 
builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
    options.Conventions.Add(new KebabCaseRouteConvention()); 
});

builder.Services.AddJwtAuth(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.InjectServices();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCustomSwagger();
builder.Services.SetupCors();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCustomSwagger();
}

// app.UseHttpsRedirection();
app.EnableCors();
app.EnableAuth();
app.MapControllers();
app.UseStaticFiles();

app.Run();

