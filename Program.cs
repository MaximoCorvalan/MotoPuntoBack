using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyInjection;
using MotoPuntoBack.Mappings;
using MotoPuntoBack.Models;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
var builder = WebApplication.CreateBuilder(args);{

    builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile));

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddAuthorization();

    builder.Services.AddAuthentication("Bearer").AddBearerToken(opt =>
    {
        var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!));
        var SignalCredentials = new SigningCredentials(signingKey,SecurityAlgorithms.HmacSha256Signature);

        
    });


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<MotopuntoContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MotoPuntoDb")));
    builder.Services.AddControllers()
        .AddJsonOptions(x =>
            x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles);

  
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger(options => options.OpenApiVersion =
Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0);
        builder.Services.AddEndpointsApiExplorer();

    }

    app.UseCors(builder =>
    {
        builder
            .AllowAnyOrigin() // o especificá tu frontend ej: WithOrigins("http://localhost:3000")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });


    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
