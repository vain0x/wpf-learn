using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Markup;

namespace WpfLearn.Examples;

public partial class RadioSelectorExampleViewModel : ObservableObject
{
    // Basic usage
    private static readonly MyRadioItem[] StaticItems = [
        new(1, "One"),
        new(2, "Two"),
        new(3, "Three")
    ];

    public ObservableCollection<MyRadioItem> Items { get; } = [.. StaticItems];

    [ObservableProperty]
    public partial MyRadioItem? SelectedItem { get; set; }

    [ObservableProperty]
    public partial int? SelectedValue { get; set; }

    // Init/Set
    // (It works when SelectedItem has initial value and is set programatically.)
    [ObservableProperty]
    public partial MyRadioItem? SelectedItemInit { get; set; } = StaticItems[1];

    [ObservableProperty]
    public partial int? SelectedValueInit { get; set; } = (int)StaticItems[1].Value;

    // With BindingGroup
    // (It works with BindingGroup is specified.)
    [ObservableProperty]
    public partial MyRadioItem? SelectedItemBg { get; set; }

    // Enum case
    // (It works to select cases of an enum type.)
    [ObservableProperty]
    public partial MyRadioItem? SelectedItemEnum { get; set; }

    [ObservableProperty]
    public partial MyRadioEnum? SelectedValueEnum { get; set; }
}

// Helper types

public class MyRadioItem(object value, object display) : ObservableObject
{
    public object Value => value;
    public object Display => display;
    public override string ToString() => $"{value}:{display}";
}

public enum MyRadioEnum
{
    A,
    B,
    O,
    [Display(Name = "AB")]
    Ab,
}

[MarkupExtensionReturnType(typeof(MyRadioItem[]))]
internal class EnumValuesExtension(Type type) : MarkupExtension
{
    public Type Type => type;

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
        return Enum.GetValues(Type).Cast<object>().Select(value =>
        {
            var name = value.ToString()!;

            // Get display name from Display attribute if specified.
            var memberInfo = Type.GetMember(name)[0];
            var attributes = memberInfo.GetCustomAttributes(typeof(DisplayAttribute), false);
            var displayName = attributes is [DisplayAttribute a] && a.Name != null
                ? a.Name
                : name;

            return new MyRadioItem(value, displayName);
        }).ToArray();
    }
}
