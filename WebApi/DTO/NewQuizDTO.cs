﻿using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class NewQuizDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(200)]
        public string Title { get; set; }
    }
}
