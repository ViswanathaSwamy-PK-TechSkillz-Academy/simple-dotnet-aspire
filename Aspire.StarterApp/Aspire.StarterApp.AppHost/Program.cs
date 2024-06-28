var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sqldbConnectionString = builder.AddConnectionString("SqlDbConnectionString");

var apiService = builder.AddProject<Projects.Aspire_StarterApp_ApiService>("apiservice")
    .WithReference(sqldbConnectionString);

builder.AddProject<Projects.Aspire_StarterApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.Build().Run();
