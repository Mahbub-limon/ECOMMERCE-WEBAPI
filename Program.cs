using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

//Data annotation
builder.Services.AddControllers().ConfigureApiBehaviorOptions(Options => //ConfigureApiBehaviorOptions = opening api behavior optins
{
  Options.SuppressModelStateInvalidFilter = true;  //Disable automatic model validation response
});

builder.Services.AddControllers();  //Add services to the controller
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

