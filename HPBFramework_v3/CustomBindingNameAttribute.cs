using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPBFramework
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CustomBindingNameAttribute : Attribute
    {
        public CustomBindingNameAttribute(string propertyName)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { get; private set; }
    }
}
