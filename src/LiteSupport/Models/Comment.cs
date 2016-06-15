using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentMsg { get; set; }
        public DateTime DateCreatedC { get; set; }

        public int TicketId { get; set; }
        public int EmployeeId { get; set; }

        public Ticket Ticket { get; set; }
        public Employee Employee { get; set; }
    }
}
