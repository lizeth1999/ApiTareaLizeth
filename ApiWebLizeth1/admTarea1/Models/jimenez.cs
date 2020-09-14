namespace admTarea1.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public enum CategoryType
    {
        Bolivia,
        USA,
        China,
        Argentina,
        Colombia
    }
    public class jimenez
    {
        [Key]
        public int JimenezID { get; set; }

        [Required]
        [DisplayName("Nombre Completo")]
        [StringLength(24, ErrorMessage = "THE FIELD MUST CONTAIN BETWEEN 2 AND 24 CHARACTERS", MinimumLength = 2)]
        public string FriendofJimenez { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "THE EMAIL IS NOT VALID")]
        public string Email { get; set; }

        [DisplayName("Cumpleanos")]
        public DateTime Birthday { get; set; }

        [Required]
        public CategoryType Place { get; set; }
    }
}