using microservice_map_info;

var builder = WebApplication.CreateBuilder(args);

//Custom startup
var configuration = new ConfigurationBuilder();
var startup = new Startup();

startup.ConfigureServices (builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);


// Add services to the container.

////builder.Services.AddControllers();
//ConfigureServices(builder.Services);
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();



//void ConfigureServices(IServiceCollection services)
//{
//    services.AddTransient<GoogleMapInfo.GoogleDistanceApi>();
//    services.AddControllers();
//}
