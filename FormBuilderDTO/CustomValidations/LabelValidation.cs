﻿using FormBuilderDTO.Constants;
using FormBuilderDTO.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace FormBuilderDTO.CustomValidations
{
    public class LabelValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var controlsDto = (ControlsDto)validationContext.ObjectInstance;

            var validationResults = new List<ValidationResult>();

            if (Enum.TryParse(controlsDto.InputType, true, out HtmlType inputType))
            {
                var allowedInputTypes = new List<HtmlType> {
                    HtmlType.Text,
                    HtmlType.Number,
                    HtmlType.Date,
                    HtmlType.Email,
                    HtmlType.File,
                    HtmlType.CheckBox,
                    HtmlType.RadioButton,
                    HtmlType.Textarea,
                    HtmlType.Select
                };

                // Perform validation for input types not included in the allowed list
                if (!allowedInputTypes.Contains(inputType))
                {
                    if (!string.IsNullOrEmpty(controlsDto.Label))
                    {
                        var allowedTypesMessage = string.Join(", ", allowedInputTypes);
                        var errorMessage = $"Label should be empty or null for input types other than {allowedTypesMessage}.";
                        validationResults.Add(new ValidationResult(errorMessage));
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(controlsDto.Label))
                    {
                        var errorMessage = $"Label is required for this input type.";
                        validationResults.Add(new ValidationResult(errorMessage));
                    }
                }
            }
            else
            {
                validationResults.Add(new ValidationResult($"Invalid InputType: {controlsDto.InputType}"));
            }

            return validationResults.Count is not 0 ? new ValidationResult(string.Join(", ", validationResults)) : ValidationResult.Success;
        }
    }
}
