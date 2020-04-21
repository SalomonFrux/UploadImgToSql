using System.ComponentModel.DataAnnotations;

namespace ImageToSql.Models
{
    public class UserForm
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public byte[] Image { get; set; }
    }
}
