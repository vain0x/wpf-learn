using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Windows;

namespace WpfLearn.Examples;

public partial class ValidationWithAnnotationsExampleViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    [MaxLength(40, ErrorMessage = "Title is at most 40 letters")]
    public partial string Title { get; set; } = "";

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Range(0, 100, ErrorMessage = "Priority must be from 0 to 100")]
    public partial int Priority { get; set; } = 50;

    [ObservableProperty]
    public partial bool EnableReminder { get; set; } = false;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Display(Name = "RemindAt")]
    [CustomValidation(typeof(ValidationWithAnnotationsExampleViewModel), nameof(ValidateDateTime))]
    public partial DateTime? RemindAt { get; set; }

    // Method to be called by CustomValidation
    public static ValidationResult? ValidateDateTime(DateTime? value, ValidationContext context)
    {
        var it = (ValidationWithAnnotationsExampleViewModel)context.ObjectInstance;
        if (it.EnableReminder)
        {
            if (!value.HasValue)
            {
                return new ValidationResult($"{context.DisplayName} is required");
            }

            var now = DateTime.Now;
            if (value < now)
            {
                return new ValidationResult($"{context.DisplayName} cannot be past");
            }
        }
        return ValidationResult.Success;
    }

    public void TriggerValidateAll()
    {
        ValidateAllProperties();
    }

    public void TriggerValidateProperty(object? value, string propertyName)
    {
        ValidateProperty(value, propertyName);
    }

    // `ValidateCommand`
    [RelayCommand]
    public void Validate()
    {
        ValidateAllProperties();
        if (HasErrors) return;

        MessageBox.Show("Validation success");
    }
}
