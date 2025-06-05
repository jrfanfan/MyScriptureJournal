using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string? Title { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }

        // Regular expression to ensure the reference starts with an uppercase letter followed by letters, numbers, and spaces
        [Display(Name = "Scripture Reference")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9\s]*$")]
        [Required]
        public string? Reference { get; set; }

        [Display(Name = "Scripture Text")]
        [StringLength(5000, MinimumLength = 10)]
        [Required]
        [DataType(DataType.MultilineText)]
        public string? Text { get; set; }

        [Display(Name = "Notes")]
        [StringLength(2000, MinimumLength = 5)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string? Notes { get; set; }

        [Display(Name = "Author")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string? Author { get; set; }

        [Display(Name = "Chapter")]
        [Range(1, int.MaxValue)]
        [Required]
        public int? Chapter { get; set; }


        [Display(Name = "Verses")]
        [Range(1, int.MaxValue)]
        [Required]
        public int? Verses { get; set; }

        [Display(Name = "Book")]
        [StringLength(15, MinimumLength = 2)]
        [Required]
        public string? Book { get; set; }



    }
}
