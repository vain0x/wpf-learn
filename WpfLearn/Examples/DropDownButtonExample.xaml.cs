using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace WpfLearn.Examples;

/// <summary>
/// Interaction logic for DropDownButtonExample.xaml
/// </summary>
public partial class DropDownButtonExample : UserControl
{
    public DropDownButtonExample()
    {
        InitializeComponent();
    }

    private void MenuListBox_Selected(object sender, RoutedEventArgs e)
    {
        var listBox = (ListBox)sender;
        var selectedItem = (ListBoxItem)listBox.SelectedItem;
        Debug.WriteLine($"Menu selected: {selectedItem.Content}");
    }

    private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
    {
        Debug.WriteLine($"Menu selected: {sender}");
        MenuToggle.IsDropDownOpen = false;
    }
}
