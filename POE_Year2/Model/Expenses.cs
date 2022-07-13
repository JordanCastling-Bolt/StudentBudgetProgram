using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_Year2.Model
{
    public class Expenses
    {
        //Database generating values
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal MonthlyBudget { get; set; }

    }
}
