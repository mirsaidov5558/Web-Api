﻿namespace WebApi.Responses
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; } // Статус запроса 
        public string Message { get; set; } // Сообщение (ошибка, успех)
        public T Data { get; set; } // Данные ответа
                                    
        public ApiResponse(T data, string message = "") // Конструктор для успешного ответа
        {
            Success = true;
            Message = message;
            Data = default;
        }

        public ApiResponse(string errorMessage) // Конструктор для ответа с ошибкой
        {
            Success = false;
            Message = errorMessage;
            Data = default;
        }
    }
}
