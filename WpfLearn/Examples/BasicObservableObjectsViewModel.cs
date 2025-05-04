using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WpfLearn.Examples; // <- file-scoped namespace

public partial class BasicObservableObjectsViewModel : ObservableObject
{
    [ObservableProperty]
    public partial string Text { get; set; } = "";

    // ResetCommand property is generated.
    [RelayCommand]
    public void Reset()
    {
        Text = "";
    }
}
