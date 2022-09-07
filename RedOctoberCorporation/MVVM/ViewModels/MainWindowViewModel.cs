using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using RedOctoberCorporation.MVVM.Models;
using RedOctoberCorporation.Commands;

namespace RedOctoberCorporation.MVVM.ViewModels;

internal class MainWindowViewModel : BaseViewModel
{
    private int _counter = 0;
    private readonly TreeBranch _rootTreeViewItem = new() { 
        Name = "Заводоуправление", 
        Type = Enums.TreeBranchType.Root,
        TreeBranches = new() };
    private object _selectedItem;

    private ObservableCollection<TreeBranch> _tree;

    public MainWindowViewModel()
    {
        Tree = new() { _rootTreeViewItem };

        AddBranch = new RelayCommand(OnAddBranchExecuted, CanAddBranchExecute);
    }

    public ObservableCollection<TreeViewItem> TrieViewItems { get; set; }

    public object SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }

    public ObservableCollection<TreeBranch> Tree
    {
        get => _tree;
        set => Set(ref _tree, value);
    }

    public ICommand AddBranch { get; }

    private bool CanAddBranchExecute(object p) => true;

    private void OnAddBranchExecuted(object p)
    {
        if (SelectedItem is not TreeBranch selectedItem) return;

        TreeBranch treeBranch = new()
        {
            Name = $"{_counter++} item",
            Type = Enums.TreeBranchType.Department,
            TreeBranches = new()
        };

        selectedItem.TreeBranches.Add(treeBranch);



        //Tree.Add(new Node() { Name = selectedItem.GetHashCode().ToString() , Nodes = new() { selectedItem } });
    }
}
