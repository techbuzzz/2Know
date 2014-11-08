using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using _2K.Core.Resources;

namespace _2K.Core.Entity
{
    public class Tag
    {
        public Tag()
        {
            CreatedOn = DateTime.Now;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid ItemId { get; set; }

        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Display(Name = "Display_Title", ResourceType = typeof(_2KLabels))]
        public string Title { get; set; }

        public DateTime? CreatedOn { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
