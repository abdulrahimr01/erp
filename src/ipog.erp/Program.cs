using ipog.erp.DataSource.IRepository;
using ipog.erp.Mapping;
using ipog.erp.Workflow.IServices;
using ipog.erp.Workflow.Services;

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
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
builder.Services.AddScoped<IBusinesstypeRepository, BusinesstypeRepository>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IHsnRepository, HsnRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IBusinesstypeService, BusinesstypeService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IHsnService, HsnService>();
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
