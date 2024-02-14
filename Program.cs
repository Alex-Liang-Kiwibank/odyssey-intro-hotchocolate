using Odyssey.MusicMatcher.Controller;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SpotifyService>();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterService<SpotifyService>();

builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(policyBuilder =>
        {
            policyBuilder
                .WithOrigins("https://studio.apollographql.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });


var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
