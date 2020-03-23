using System;
using System.Collections.Generic;
using System.Text;

namespace MiniFramework2d
{
    public class RandomEvent
    {
        public string Description{ get; }
        public Action Event { get; }

        public RandomEvent()
        {
            
        }

        public RandomEvent(string description, Action @event)
        {
            Description = description;
            Event = @event;
        }
    }
}
