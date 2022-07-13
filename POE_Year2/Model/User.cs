using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POE_Year2.Model
{
    public class User
    {
        //Database generating values
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }

        [MaxLength(24)]
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
