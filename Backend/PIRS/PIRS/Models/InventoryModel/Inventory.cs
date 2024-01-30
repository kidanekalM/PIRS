using System.ComponentModel.DataAnnotations;

namespace PIRS.Models.InventoryModel
{
    public class Inventory
    {
        [Key]
        public Guid Id { get; set; }
    }
}
