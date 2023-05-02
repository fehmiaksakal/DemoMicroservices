using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }
        [JsonIgnore]
        public int StatusCode { get; private set; }
        [JsonIgnore]
        public bool IsSuccessful { get; private set; }

        public List<string> Errors { get; set; } = new List<string>();
        public static ResponseDto<T> Success(T data, int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = data, IsSuccessful = true };
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = default(T), IsSuccessful = true };
        }
        public static ResponseDto<T> Fail(List<string> errors, int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = default(T), Errors = errors, IsSuccessful = false };
        }

        public static ResponseDto<T> Fail(string error, int statusCode)
        {
            return new ResponseDto<T> { StatusCode = statusCode, Data = default(T), Errors = new List<string>() { error }, IsSuccessful = false };
        }
    }
}
