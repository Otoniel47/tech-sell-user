using Tech_sell_user.Domain.Utils;
using Tech_sell_user.IoC.Context;
using Tech_sell_user.IoC.Mapper;
using Tech_sell_user.IoC.Repositories;
using Tech_sell_user.IoC.Services;

var builder = WebApplication.CreateBuilder(args);

var appSettingsSection = builder.Configuration.GetSection("TechSellUserSettings");
builder.Services.Configure<TechSellUserSettings>(appSettingsSection);
var appSettings = appSettingsSection.Get<TechSellUserSettings>();

builder.Services.AddMapper();
builder.Services.AddDatabase(appSettings?.ConnectionString);

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.UseAuthentication();    

app.MapControllers();

app.Run();