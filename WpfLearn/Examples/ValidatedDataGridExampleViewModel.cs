using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace WpfLearn.Examples;

public partial class ValidatedDataGridExampleViewModel : ObservableValidator
{
    public ObservableCollection<ItemViewModel> Items { get; } = new(GenerateItems());

    private static ItemViewModel[] GenerateItems()
    {
        return Enumerable.Range(1, 50).Select(i => new ItemViewModel()
        {
            Name = $"Name {i}",
        }).ToArray();
    }

    public partial class ItemViewModel : ObservableValidator
    {
        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required]
        public partial string Name { get; set; } = "";

        internal void TriggerValidate()
        {
            ValidateAllProperties();
        }
    }
}
