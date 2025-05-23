using System.Windows;
using System.Windows.Controls;

namespace WpfLearn.Examples;

/// <summary>
/// Interaction logic for DropDownButton.xaml
/// </summary>
public partial class DropDownButton : HeaderedContentControl
{
    public DropDownButton()
    {
        InitializeComponent();
    }

    public bool IsDropDownOpen
    {
        get { return (bool)GetValue(IsDropDownOpenProperty); }
        set { SetValue(IsDropDownOpenProperty, value); }
    }
    public static readonly DependencyProperty IsDropDownOpenProperty =
        DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(DropDownButton), new PropertyMetadata(false));

    private void PART_Button_Click(object sender, RoutedEventArgs e)
    {
    }

    private void PART_Button_Checked(object sender, RoutedEventArgs e)
    {
        IsDropDownOpen = true;
    }

    private void PART_Button_Unchecked(object sender, RoutedEventArgs e)
    {
        IsDropDownOpen = false;
    }

    private void PART_Popup_Closed(object sender, EventArgs e)
    {
        IsDropDownOpen = false;
    }
}
