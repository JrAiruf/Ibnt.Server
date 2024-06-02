﻿using Ibnt.Domain.Entities.TimeLine;

namespace Ibnt.Server.Domain.Entities.TimeLine
{
    public class TimeLineEntity : TimeLineContent
    {
        public TimeLineEntity()
        {
            Title = "Timeline IBNT";
        }
        public List<EventEntity>? Events { get; set; }   
        public List<BibleMessageEntity>? BibleMessages { get; set; }
    }
}
