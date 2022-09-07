using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace RedOctoberCorporation.Behaviors;

internal class BindableSelectedItemBehavior : Behavior<TreeView>
{
    public static readonly DependencyProperty? SelectedItemProperty = DependencyProperty.Register(
        "SelectedItem",
        typeof(object),
        typeof(BindableSelectedItemBehavior),
        new UIPropertyMetadata(null, OnSelectedItemChanged));

    public object SelectedItem
    {
        get => GetValue(SelectedItemProperty);
        set => SetValue(SelectedItemProperty, value);
    }

    private static void OnSelectedItemChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        if (e.NewValue is not TreeViewItem item) return;

        item.SetValue(TreeViewItem.IsSelectedProperty, true);
    }

    private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        SelectedItem = e.NewValue;
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        AssociatedObject.SelectedItemChanged += OnTreeViewSelectedItemChanged;
    }

    protected override void OnDetaching()
    {
        base.OnDetaching();

        if (AssociatedObject != null)
        {
            AssociatedObject.SelectedItemChanged -= OnTreeViewSelectedItemChanged;
        }
    }
}
