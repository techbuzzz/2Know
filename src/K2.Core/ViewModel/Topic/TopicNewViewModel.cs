using System.Web.Mvc;

namespace _2K.Core.ViewModel.Topic
{
    public class TopicNewViewModel
    {
        public string Title { get; set; }

        [AllowHtml]
        public string Content { get; set; }
    }
}
