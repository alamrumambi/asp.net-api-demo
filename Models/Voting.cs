using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo_Test.Models
{
    public partial class Voting
    {
        public Voting()
        {
            Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Voting's name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }

        [Required]
        [Display(Name = "Voters Count")]
        public int VotersCount { get; set; }

        [Required(ErrorMessage = "Due Date required!")]
        [Display(Name = "Due Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Choose category!")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
    }
}
