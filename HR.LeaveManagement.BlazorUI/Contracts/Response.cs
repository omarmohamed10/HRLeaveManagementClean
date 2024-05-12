﻿namespace HR.LeaveManagement.BlazorUI.Contracts
{
    public class Response<T>
    {
        public string Message { get; set; }
        public string ValidationErrors { get; set; }
        public bool Success { get; set; } = true;
        public T Data { get; set; }
    }
}
