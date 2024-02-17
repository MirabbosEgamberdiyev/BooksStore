using Amazon.Runtime;
using Amazon.S3;
using BookStore.StorageService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var accessKey = builder.Configuration["AWS : AccessKey"];
var secretKey = builder.Configuration["AWS : SecretAccessKey"];
var awsCredentail = new BasicAWSCredentials(accessKey, secretKey);
builder.Services.AddSingleton<IAmazonS3>(new AmazonS3Client(awsCredentail, Amazon.RegionEndpoint.EUNorth1));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IS3Service, S3Service>();
builder.Services.AddSwaggerGen();

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

app.Run();
