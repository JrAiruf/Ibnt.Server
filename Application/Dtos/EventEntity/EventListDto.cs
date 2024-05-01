using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ibnt.Application.Dtos.EventEntity
{
    public  class EventListDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime? PostDate { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
    }
}
