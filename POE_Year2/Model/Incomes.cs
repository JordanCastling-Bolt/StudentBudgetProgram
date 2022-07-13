using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_Year2.Model
{
    public class Incomes
    {
        //Database generating values
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        public decimal UsersIncome { get; set; }
    }
}
