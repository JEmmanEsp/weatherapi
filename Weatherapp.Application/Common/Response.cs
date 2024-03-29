﻿using System.Text.Json.Serialization;

namespace Weatherapp.Application.Common
{
    public static class Response
    {
        public static Response<T> Ok200<T>(T data)
        {
            return new Response<T>(data, "Success", 200, true);
        }

        public static Response<T> Fail404NotFound<T>(string message, T data = default)
        {
            return new Response<T>(data, message, 404, false);
        }

        public static Response<T> Fail500ServiceError<T>(string message, T data = default)
        {
            return new Response<T>(data, message, 500, false);
        }
    }

    public class Response<T> : BasicResponse
    {

        public T Data { get; set; }
        public int StatusCode { get; set; }

        public Response(T data, string message, int statusCode, bool success) : base(message, success)
        {
            Data = data;
            StatusCode = statusCode;
        }
    }
}
