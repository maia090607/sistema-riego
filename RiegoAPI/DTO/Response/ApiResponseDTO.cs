using System.Collections.Generic;
using System;

namespace RiegoAPI.DTOs.Response
{
    
        public class ApiResponse
        {
            public bool success { get; set; }
            public string? message { get; set; }
            public DateTime timestamp { get; set; }
        }
    

}