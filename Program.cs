var buidler = WebApplication.CreateBuilder();

buidler.Services.AddApplicationServices(buidler.Configuration);

buidler
    .Build()
    .ConfigureApplicationServices()
    .Run();