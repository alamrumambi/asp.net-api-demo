using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Demo_Test.Models
{
    public partial class Category
    {
        public Category()
        {
            Votings = new HashSet<Voting>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Category's name required!")]
        [Display(Name = "Category's Name")]
        public string Name { get; set; }

        public virtual ICollection<Voting> Votings { get; set; }
    }
}
