using System.ComponentModel.DataAnnotations;

namespace PIRS.Models.RatingModel
{
    public class Rating
    {
        [Key]
        public Guid Id { get; set; }
    }
}
