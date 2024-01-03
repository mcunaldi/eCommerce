using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddCors(configure=>
{
	configure.AddDefaultPolicy(policy=> policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
	options.TokenValidationParameters = new()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true, //expire s�resini i�letmek i�in. false olursa s�n�rs�z token g�c� olur.
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
		ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value ?? ""))
	};
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

//app.UseAuthorization(); service k�sm�nda eklenecek. 

app.MapControllers();

app.Run();
