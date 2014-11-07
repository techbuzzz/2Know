using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using K2.Core.Resources;

namespace K2.Core.ViewModel.Post
{
    public class PostNewViewModel
    {
        
        public string Title { get; set; }

        
        public string Content { get; set; }
    }
}
