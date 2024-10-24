using Microsoft.AspNetCore.Mvc.ApplicationParts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer(); //for generating swagger tools
builder.Services.AddSwaggerGen(); //generate sawagger documentation

var app = builder.Build(); 

if(app.Environment.IsDevelopment()){
    app.UseSwagger();  //its a middleware
    app.UseSwaggerUI();  //showing swagger UI

}
app.UseHttpsRedirection();

app.MapGet("/",() =>{
return "Api is working fine";
});
app.MapGet("/hello",() =>{
return "Get method";
});


app.MapPost("/hello",() =>{
    return "this is post method";
});
 
 app.MapPut("/hello",() =>{
    return "put method :hello";
 });

 app.MapDelete("/hello",() =>{
    return "Delete method :hello";
 });

app.Run();