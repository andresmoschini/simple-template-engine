using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTemplateEngine.Parser
{
    public class ModelProperty
    {
        public bool BooleanValue { get; set; }
        public string StringValue { get; set; }
        public Object[] ListValue { get; set; }

        public static readonly ModelProperty Empty = new ModelProperty()
        {
            BooleanValue = false,
            StringValue = "[Empty]",
            ListValue = new object[] { }
        };

        public static ModelProperty FromObject(object model, string propertyName)
        {
            if (model == null)
            {
                return Empty;
            }
            var property = model.GetType().GetProperty(propertyName);
            if (property == null)
            {
                return Empty;
            }
            var type = property.PropertyType;
            var value = property.GetGetMethod().Invoke(model, null);

            if (value == null)
            {
                return Empty;
            }
            else if (type == typeof(string))
            {
                var str = (string)value;
                return new ModelProperty()
                {
                    BooleanValue = str.Length > 0,
                    StringValue = str,
                    ListValue = new object[] { }
                };
            }
            else if (type == typeof(bool))
            {
                return new ModelProperty()
                {
                    BooleanValue = (bool)value,
                    StringValue = value.ToString(),
                    ListValue = new object[] { }
                };
            }
            else if (type.GetInterfaces().Contains(typeof(IEnumerable)))
            {
                var list = ((IEnumerable)value).Cast<object>().ToArray();
                var count = list.Count();
                return new ModelProperty()
                {
                    BooleanValue = count > 0,
                    StringValue = count == 0 ? "[Empty]" : (count == 1 ? "[1 item]" : string.Format("[{0} items]", count)),
                    ListValue = list
                };
            }
            else
            {
                var str = value.ToString();
                return new ModelProperty()
                {
                    BooleanValue = str.Length > 0,
                    StringValue = str,
                    ListValue = new object[] { }
                };
            }
        }
    }
}
