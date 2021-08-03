using System.ComponentModel.DataAnnotations;

namespace soa.common.dtos.Vms.Accounts
{
  public class AccountForCreationUiModel
  {
    [Editable(true)] public string Title { get; set; }
    [Editable(true)] public string Body { get; set; }
    [Editable(true)] public int PersonId { get; set; }
    [Editable(true)] public int ParentId { get; set; }

    [Editable(true)] public bool AddedView { get; set; }
    [Editable(true)] public bool AddedFlag { get; set; }
    [Editable(true)] public bool AddedVote { get; set; }
  }
}