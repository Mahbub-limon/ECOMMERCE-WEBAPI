using System.IO.Compression;
using Ecommerce_webApi.Models.Controllers;
using Ecommerce_webApi.Models.Controllers.Interfaces;
using Ecommerce_webApi.Models.Controllers.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddScoped<ICategoryService,CategoryService>(); 
builder.Services.AddControllers();  //Add services to the controller

// doing configure . api behaviour configure
builder.Services.Configure<ApiBehaviorOptions>(Options => {
  Options.InvalidModelStateResponseFactory = context => 
  {
            var errors = context.ModelState
                         .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                         .SelectMany(e => e.Value ?.Errors != null ? e.Value.Errors.Select(x => x.ErrorMessage) : new List<string>()).
                         ToList();

             return new BadRequestObjectResult(ApiReponse<object>.ErrorResponse(errors,400,"Validation failed"));
            };
       });

builder.Services.AddEndpointsApiExplorer(); //for generating swagger tools
builder.Services.AddSwaggerGen(); //generate sawagger documentation

var app = builder.Build(); 

if(app.Environment.IsDevelopment()){
    app.UseSwagger();  //its a middleware
    app.UseSwaggerUI();  //showing swagger UI
}
app.UseHttpsRedirection();
app.MapGet("/",() => "Api is working fine");

app.MapControllers();
app.Run();

