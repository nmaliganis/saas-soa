using System.ComponentModel.DataAnnotations;

namespace ms.common.dtos.Vms.Bases
{
    public interface IUiModel
    {
        [Key]
        int Id { get; set; }
        [Editable(false)]
        string Message { get; set; }
    }
}
