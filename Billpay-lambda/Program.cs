using Amazon.CognitoIdentityProvider;
using Billpay_lambda.Helpers;
using Billpay_lambda.Interfaces;
using Billpay_lambda.Managers;
using Billpay_lambda.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAWSLambdaHosting(LambdaEventSource.HttpApi);

// Add service dependencies
builder.Services.AddTransient<IBillPayservice, BillPayservice>();
builder.Services.AddTransient<BillPayManager>();

// Configure Swagger generator
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Billpay Web API",
        Version = "v1"
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
            });
});

// Setup AWS configuration and AWS Cognito Identity
builder.Services.AddCognitoIdentity();
var defaultOptions = Configuration.GetAWSOptions();
var cognitotOptions = Configuration.GetAWSCognitoClientOptions();
builder.Services.AddDefaultAWSOptions(defaultOptions);
builder.Services.AddSingleton(cognitotOptions);
builder.Services.AddSingleton(new CognitoClientSecretHelper(cognitotOptions));
builder.Services.AddAWSService<IAmazonCognitoIdentityProvider>();

// Setup authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var authority = $"https://cognito-idp.us-east-1.amazonaws.com/{cognitotOptions.UserPoolId}";
        var audience = cognitotOptions.UserPoolClientId;

        options.Audience = audience;
        options.Authority = authority;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = authority,
            ValidAudience = audience,
            IssuerSigningKey = new CognitoSigningKeyHelper(cognitotOptions.UserPoolClientSecret).ComputeKey()
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
        c.RoutePrefix = "swagger";
        c.OAuthClientId("swagger");
        c.OAuthAppName("Swagger UI");
    });
}

app.UseRouting();

app.UseCors("OpenSeason");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
