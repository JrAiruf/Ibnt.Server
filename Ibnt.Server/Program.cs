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

app.UseCors(
    opt =>
    {
        _ = opt.AllowAnyHeader()
           .AllowAnyMethod()
           .AllowAnyOrigin();
    });

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
