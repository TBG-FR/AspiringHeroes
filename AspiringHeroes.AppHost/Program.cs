var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");
var heroREST = builder.AddProject<Projects.AspiringHeroes_Api>("heroes-REST-api");
var heroGRPC = builder.AddProject<Projects.AspiringHeroes_Grpc>("heroes-GRPC-service");

builder.AddProject<Projects.AspiringHeroes_Web>("webUI")
    .WithReference(cache)
    .WithReference(heroREST)
    .WithReference(heroGRPC);

builder.Build().Run();
