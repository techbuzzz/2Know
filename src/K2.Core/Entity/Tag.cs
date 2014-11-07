using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using K2.Core.Resources;
using _2K.Core.Entity;

namespace K2.Core.Entity
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
