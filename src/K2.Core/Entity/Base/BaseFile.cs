using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2K.Core.Entity.Base
{
    public class BaseFile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ScaffoldColumn(false)]
        public Guid ItemId { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }

        public int Counter { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
