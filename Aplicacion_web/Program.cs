using Microsoft.EntityFrameworkCore;
using Aplicacion_web.DataAccess;
using Aplicacion_web.Services;

var builder = WebApplication.CreateBuilder(args);


// 2. Connection with SQL server express
const string CONNECTIONNAME = "UniversityDB";
var connetionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to Service of builder
builder.Services.AddDbContext<UniversityDBContext>(options => options.UseSqlServer(connetionString));


// Add services to the container.
builder.Services.AddControllers();

// 4. Add Custom Services
builder.Services.AddScoped<IStudentsService, StudentsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 5. CORS configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// 6. Tell app to use CORS

app.UseCors("CorsePolicy");

app.Run();
