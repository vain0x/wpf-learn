using System.Windows.Controls;
using System.Windows.Media;

namespace WpfLearn.Examples;

/// <summary>
/// Interaction logic for RadioIsCheckedBindingGroupExample.xaml
/// </summary>
public partial class RadioIsCheckedBindingGroupExample : UserControl
{
    public RadioIsCheckedBindingGroupExample()
    {
        InitializeComponent();
    }

    private void ValidateButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        var button = (Button)sender;

        var valid = FormGroup.BindingGroup.UpdateSources();

        if (valid)
        {
            var viewModel = (RadioIsCheckedBindingGroupExampleViewModel)DataContext;
            viewModel.Validate();
            valid = !viewModel.HasErrors;
        }

        // Show validation result.
        if (valid)
        {
            button.Content = "Validate (OK)";
            button.BorderBrush = Brushes.Green;
        }
        else
        {
            button.Content = "Validate (NG)";
            button.BorderBrush = Brushes.Red;
        }
    }
}
