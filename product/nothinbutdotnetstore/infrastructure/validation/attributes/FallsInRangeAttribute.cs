using System;

namespace nothinbutdotnetstore.infrastructure.validation.attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FallsInRangeAttribute : Attribute
    {
        int start;
        int end;
        private ItemProperty property { get; set; }
        
        public FallsInRangeAttribute(int start,int end)
        {
            this.start = start;
            this.end = end;
        }

        public bool is_valid(object item)
        {
            int value= (int)property.get_value_from(item);
            if (value >= start && value <= end) return true;
            return false;
        }

    }
}