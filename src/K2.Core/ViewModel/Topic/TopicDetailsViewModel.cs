using System.Collections.Generic;
using System.Web.Mvc;

namespace _2K.Core.ViewModel.Topic
{
    public class TopicDetailsViewModel
    {
        public TopicDetailsViewModel(List<Entity.Post> posts)
        {
            Posts = posts;
        }

        public int ItemId { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }

        public List<Entity.Post> Posts { get; set; }
    }
}
