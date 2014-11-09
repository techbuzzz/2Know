using System.Collections.Generic;

namespace _2K.Core.ViewModel.Post
{
    public class PostNewViewModel
    {
        
        public string Title { get; set; }
        
        public string Content { get; set; }

        public int TopicId { get; set; }
        public Entity.Topic Topic { get; set; }
        public List<Entity.Topic> Topics { get; set; }

    }
}
