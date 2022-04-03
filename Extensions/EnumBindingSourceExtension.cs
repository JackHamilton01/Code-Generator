using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Chord_Generator.Extensions
{
    public class EnumBindingSourceExtension : MarkupExtension
    {
        public Type EnumType { get; private set; }

        public EnumBindingSourceExtension(Type enumType)
        {
            if (enumType is null || !enumType.IsEnum)
            {
                throw new Exception("Enum type must not be null and of type enum.");
            }

            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }
}
