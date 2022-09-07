using System.Collections.ObjectModel;
using RedOctoberCorporation.Enums;

namespace RedOctoberCorporation.MVVM.Models;

internal class TreeBranch
{
    public string? Name { get; set; }

    public TreeBranchType Type { get; set; }

    public ObservableCollection<TreeBranch>? TreeBranches { get; set; }
}
