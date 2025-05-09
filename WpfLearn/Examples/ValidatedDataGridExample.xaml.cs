using System.Windows;
using System.Windows.Controls;

namespace WpfLearn.Examples;

/// <summary>
/// Interaction logic for ValidatedDataGridExample.xaml
/// </summary>
public partial class ValidatedDataGridExample : UserControl
{
    public ValidatedDataGridExample()
    {
        InitializeComponent();
    }

    private void ValidateButton_Click(object sender, RoutedEventArgs e)
    {
        DataGridRow? found = null;
        object? foundItem = null;
        foreach (var item in dataGrid.Items)
        {
            var row = (DataGridRow?)dataGrid.ItemContainerGenerator.ContainerFromItem(item);
            if (row == null) continue;

            row.BindingGroup.UpdateSources();
            //if (item is ValidatedDataGridExampleViewModel.ItemViewModel itemViewModel)
            //{
            //    itemViewModel.TriggerValidate();
            //}

            if (row.BindingGroup.ValidationErrors.Count != 0)
            {
                found = row;
                foundItem = item;
                break;
            }
        }
        if (found != null)
        {
            found.BringIntoView();
            found.Focus();
            found.IsSelected = true;
            return;
        }

        MessageBox.Show("Validation success");
    }
}
