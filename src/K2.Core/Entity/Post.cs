using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;
using _2K.Core.Entity.Base;
using _2K.Core.Resources;

namespace _2K.Core.Entity
{
    public class Post :BaseItem
    {
        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Display(Name = "Display_Title", ResourceType = typeof(_2KLabels))]
        [StringLength(256)]
        public string Title { get; set; }

        [AllowHtml]
        [Required(ErrorMessageResourceName = "requiredfield", ErrorMessageResourceType = typeof(_2KErrors))]
        [Column(TypeName = "ntext")]
        public string Content { get; set; }


        public int TopicId { get; set; }

        public virtual Topic Topic { get; set; }

        /// <summary>
        /// Get or sets the tags.
        /// </summary>
        public virtual ICollection<Tag> Tags { get; set; }

        /// <summary>
        /// Get or sets the comments.
        /// </summary>
        public virtual ICollection<PostComment> Comments { get; set; }

        /// <summary>
        /// Get or sets the files.
        /// </summary>
        public virtual ICollection<PostFile> Files { get; set; }

    }
}
