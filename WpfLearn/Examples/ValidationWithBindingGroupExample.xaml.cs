using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfLearn.Examples;

/// <summary>
/// Interaction logic for ValidationWithBindingGroupExample.xaml
/// </summary>
public partial class ValidationWithBindingGroupExample : UserControl
{
    public ValidationWithBindingGroupExample()
    {
        InitializeComponent();
    }

    private void NumberTextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        var textBox = (TextBox)sender;
        var be = textBox.GetBindingExpression(TextBox.TextProperty);
        if (be.HasValidationError)
        {
            be.UpdateSource();
        }
    }

    private void ValidateButton_Click(object sender, RoutedEventArgs e)
    {
        var valid = BindingGroup.UpdateSources();
        if (!valid)
        {
            var error = string.Join(", ", BindingGroup.ValidationErrors.Select(error => error.ErrorContent));

            MessageBox.Show("Validation failed: " + error);
            return;
        }

        MessageBox.Show("Validation success");
    }
}
