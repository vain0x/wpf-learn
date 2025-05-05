using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfLearn.Examples;

public partial class ValidationWithBindingGroupExampleViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string Title { get; set; } = "";

    [ObservableProperty]
    public partial int Number { get; set; } = 1;
}
