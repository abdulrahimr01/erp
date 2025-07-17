using ipog.bureaucrats.DataSource.IRepository;
using ipog.bureaucrats.Mapping;
using ipog.bureaucrats.Workflow.IServices;
using ipog.bureaucrats.Workflow.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "AllowAnyCorsPolicy",
        policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()
    );
});
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<MapperProfile>();
});
builder.Services.AddScoped<IMapping, Mapping>();

builder.Services.AddScoped<INpgsqlQuery, NpgsqlQuery>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IMenuRepository, MenuRepository>();
builder.Services.AddScoped<IExamsRepository, ExamsRepository>();
builder.Services.AddScoped<IPapersRepository, PapersRepository>();
builder.Services.AddScoped<IContactInfoRepository, ContactInfoRepository>();
builder.Services.AddScoped<IDefaultPageRepository, DefaultPageRepository>();

builder.Services.AddScoped<IPapersService, PapersService>();
builder.Services.AddScoped<IExamsService, ExamsService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IContactInfoService, ContactInfoService>();
builder.Services.AddScoped<IDefaultPageService, DefaultPageService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
