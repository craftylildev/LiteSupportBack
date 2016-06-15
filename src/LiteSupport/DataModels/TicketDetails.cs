using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiteSupport.DataModels
{
    public class TicketDetails
    {
        public int TicketId { get; set; }
        public string Title { get; set; }
        public DateTime DateCreatedT { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
        public DateTime DateClosed { get; set; }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string URL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public int TtypeId { get; set; }
        public string TtypeName { get; set; }

        public int PriorityId { get; set; }
        public string PriorityName { get; set; }

        public int CommentId { get; set; }
        public string CommentMsg { get; set; }
        public DateTime DateCreatedC { get; set; }

    }
}
