using System.Linq;

namespace _2K.Core.ViewModel.Post
{
    public class PostListViewModel
    {
        //public PostListViewModel()
        //{
        //    GridData = new List<PostListItemViewModel>();
        //}
        public int TotalCount { get; set; }
        public string SearchString { get; set; }
        public IQueryable<PostListItemViewModel> GridData { get; set; }

        public class PostListItemViewModel
        {
            public PostListItemViewModel()
            {
                Votes = 0;
            }

            public int ItemId { get; set; }

            public string Title { get; set; }

            public int CommentCount { get; set; }

            public int? Votes { get; set; }

            public string CreatedBy { get; set; }
        }
    }
}
