#region usings
using API.ExtensionsMethods;
using Data.Repositories.Context;
#endregion

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddResponseCompression();
builder.Services.AddSessionServices().AddCORS();
builder.Services.AddControllers();
builder.Services.AddSwagger();
builder.Services.AddDbContext<YouDbContext>();
builder.Services.AddServices().AddElasticSearch(builder.Configuration).AddRedis().AddJwt(builder.Configuration);

var app = builder.Build();

var isDevelopment = app.Environment.IsDevelopment();
app.UseSwaggerExtension(isDevelopment);
app.UseHttpsRedirection();
app.UseCORSExtension(isDevelopment);
app.UseAuthentication().UseAuthorization();
//app.UseHsts();
app.UseResponseCompression();
app.MapControllers();

app.Run();