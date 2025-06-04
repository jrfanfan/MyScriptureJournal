using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MyScriptureJournal.Models
{
    public class Scripture
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Display(Name = "Added Date")]
        [DataType(DataType.Date)]
        public DateTime AddedDate { get; set; }
        public string? Reference { get; set; }
        public string? Text { get; set; }
        public string? Notes { get; set; }
        public string? Book { get; set; }
        public string? Author { get; set; }
        public int? Chapter { get; set; }
        public int? Verses { get; set; }



    }
}
