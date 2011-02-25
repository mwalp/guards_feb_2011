using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Machine.Specifications;
using Machine.Specifications.DevelopWithPassion.Rhino;
using nothinbutdotnetstore.infrastructure;
using nothinbutdotnetstore.infrastructure.validation.attributes;
using Rhino.Mocks;

namespace nothinbutdotnetstore.specs
{
    class FallsInRangeSpecs
    {
        public abstract class when_validating_an_property : Observes<FallsInRangeAttribute>
        {
            Establish c = () =>
            {
                item = new ItemToValidate();
                item.PropertyToValidate = 19;
                item_property = an<ItemProperty>();
                item_property.Stub(x => x.get_value_from(item)).Return(item.PropertyToValidate);
                
                create_sut_using(()=> {return new FallsInRangeAttribute(10,20);});
            };

            Because b = () =>
                result = sut.is_valid(item);

            It should_return_true_if_the_property_value_is_in_range = () =>
                                                                                  {
                                                                                      result.ShouldBeTrue();
                                                                                  };



            static PropertyInfo property_info;
            private static ItemProperty item_property;
            private static ItemToValidate item;
            private static bool result;
        }
        
        public class ItemToValidate
        {
            public int PropertyToValidate { get; set; }
        }
    }
}
