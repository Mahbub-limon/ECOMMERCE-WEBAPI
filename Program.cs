using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

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

