using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using K2.Core.Resources;
using _2K.Core.Entity;
using _2K.Core.Entity.Base;

namespace K2.Core.Entity
{
    public class PostComment:BaseItem
    {
        [StringLength(50)]
        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Display(Name = "Display_Title", ResourceType = typeof(_2KLabels))]
        public string Title { get; set; }

        [AllowHtml]
        [StringLength(2500)]
        public string Comment { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int ParentId  { get; set; }
    }
}
