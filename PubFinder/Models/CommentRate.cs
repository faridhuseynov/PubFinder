using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.Models
{
    class CommentRate
    {
        public int Id { get; set; }
        public int VoteId { get; set; }
        public Vote Vote { get; set; }
        public int UserId { get; set; }
        public int PubId { get; set; }
        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}
