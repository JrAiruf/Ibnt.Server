using App.Infra.Config;
using Microsoft.Extensions.FileProviders;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.EnviromentConfig();
builder.Inject();
builder.Migrate();
builder.ConfigAuth();
builder.ConfigSwagger();

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

var imageDirectoryCreated = Directory.Exists("./Images/Events");
var userDirectoryCreated = Directory.Exists("./Images/Users");
if (!imageDirectoryCreated)
{
    Directory.CreateDirectory("./Images/Events");
}

if (!userDirectoryCreated)
{
    Directory.CreateDirectory("./Images/Users");
}

app.UseCors(
    opt =>
    {
        _ = opt.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });

app.UseAuthentication();

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = new PathString("/Images")
});

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
