using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_webApi.Models.Controllers
{
    public class ApiReponse<T>
    {
       public bool Success{get;set;} 
       public string Message{get;set;} = string.Empty;
       public T? Data {get;set;}  //T is a generic data type(anyhow)
        public List<string>? Errors{get;  set;}  // here are multiple errors.List<string> for multiple errors
        public int StatusCode{get;set;}
        public DateTime TimeStamp{get;set;}
    
    //Constructor for successful response
    private ApiReponse(bool success,string message,T? data ,List<string>? errors, int statusCode){
        Success = success;
        Message = message;
        Data = data;
        Errors = errors;
        StatusCode  = statusCode;
        TimeStamp = DateTime.UtcNow; 
    }

    //static method for creating a successful response
    public static ApiReponse<T> SuccessResponse( T? data,int statusCode,string message =" " )
    {
        return new ApiReponse<T>(true, message,data,null,statusCode);
    }

 //static method for creating an error response
 public static ApiReponse<T> ErrorResponse(List<string>errors,int statusCode,string message = " ")
 {
    return new ApiReponse<T>(false,message,default(T),errors,statusCode);
 }
    
    }
}