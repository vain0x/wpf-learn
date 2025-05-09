using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;

namespace WpfLearn.Examples;

// see also wpf's ListBox implementation

public class RadioSelector : Selector
{
    /// <summary>
    /// Same as RadioButton.GroupName
    /// </summary>
    public string? GroupName
    {
        get { return (string?)GetValue(GroupNameProperty); }
        set { SetValue(GroupNameProperty, value); }
    }
    public static readonly DependencyProperty GroupNameProperty =
        DependencyProperty.Register("GroupName", typeof(string), typeof(RadioSelector), new PropertyMetadata(null));

    protected override DependencyObject GetContainerForItemOverride()
    {
        var radio = new RadioButton();
        radio.SetBinding(RadioButton.GroupNameProperty, new Binding(nameof(GroupName)) { Source = this });
        radio.SetBinding(RadioButton.IsCheckedProperty, new Binding("(Selector.IsSelected)") { Source = radio });
        return radio;
    }

    protected override bool IsItemItsOwnContainerOverride(object item)
    {
        return item is RadioButton;
    }

    protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
    {
        base.PrepareContainerForItemOverride(element, item);

        if (element is RadioButton radio)
        {
            Debug.WriteLine($"container: prepare (item={item})");
            radio.Checked += RadioChecked;
            //radio.Unchecked += RadioUnchecked;
        }
    }

    protected override void ClearContainerForItemOverride(DependencyObject element, object item)
    {
        base.ClearContainerForItemOverride(element, item);

        if (element is RadioButton radio)
        {
            Debug.WriteLine($"container: clear (item={item})");
            radio.Checked -= RadioChecked;
        }
    }

    private void RadioChecked(object sender, RoutedEventArgs e)
    {
        var radio = (RadioButton)sender;
        if (radio.IsChecked == true)
        {
            var item = ItemContainerGenerator.ItemFromContainer(radio);
            SelectedItem = item;
            Debug.WriteLine($"radio: checked {item}");
        }
    }
}
