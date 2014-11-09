using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using _2K.Core.Entity.Base;
using _2K.Core.Resources;

namespace _2K.Core.Entity
{
    public class Topic: BaseItem
    {
        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Display(Name = "Display_Title", ResourceType = typeof(_2KLabels))]
        [StringLength(256)]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
