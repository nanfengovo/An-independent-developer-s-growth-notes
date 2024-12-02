
using BCVP.NET8.Extensions;
using BCVP.NET8.IService;
using BCVP.NET8.Repository.Base;
using BCVP.NET8.Service;

namespace BCVP.NET8
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMappings();

            //“¿¿µ◊¢»Î
            builder.Services.AddScoped(typeof(IBaseRepository< >),typeof(BaseRepository< >));
            builder.Services.AddScoped(typeof(IBaseServices<,>), typeof(BaseServices<,>));

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
        }
    }
}
