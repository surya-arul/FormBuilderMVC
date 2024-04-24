﻿using System.ComponentModel.DataAnnotations;

namespace FormBuilderMVC.DTOs.Base
{
    public class SurveysDto
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Survey title")]
        [Required]
        public string Title { get; set; } = null!;

        [Display(Name = "Open date")]
        [Required]
        public DateOnly OpenDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        [Display(Name = "End date")]
        [Required]
        public DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

        [Display(Name = "Form method")]
        public string? FormMethod { get; set; }

        [Display(Name = "Form action")]
        public string? FormAction { get; set; }
    }
}
