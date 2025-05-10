using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;

namespace WpfLearn.Examples;

public partial class RadioIsCheckedBindingGroupExampleViewModel : ObservableValidator
{
    [ObservableProperty]
    [NotifyDataErrorInfo]
    [CustomValidation(typeof(RadioIsCheckedBindingGroupExampleViewModel), nameof(ValidateSelected))]
    public partial MyEnum? SelectedValue { get; set; } = MyEnum.A;

    public static ValidationResult? ValidateSelected(MyEnum? value)
    {
        // Simulate some constraints
        if (value != MyEnum.A && value != MyEnum.B)
        {
            return new ValidationResult("Select either A or B");
        }
        return ValidationResult.Success;
    }

    [RelayCommand]
    public void Validate()
    {
        ValidateAllProperties();
    }
}

public enum MyEnum
{
    A,
    B,
    C,
}
