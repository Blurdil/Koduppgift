using Newtonsoft.Json;
using System.Collections.Generic;

namespace Koduppgift.Models
{
    public class Comments
    {
        public string author { get; set; }
        public string content { get; set; }
        public string created_at { get; set; }
        public AuthorDetails author_details { get; set; }
    }

    public class AuthorDetails
    {
        public string name { get; set; }
        public string username { get; set; }
        public double? rating { get; set; }
    }

    public class CommentList
    {
        public int page { get; set; }
        public int total_pages { get; set; }
        public List<Comments> results { get; set; }
    }

    public class CommentsTransform
    {
        public string JsonToComments(string o)
        {
            var comments = JsonConvert.DeserializeObject<CommentList>(o);
            return JsonConvert.SerializeObject(comments);
        }
    }
    
}
