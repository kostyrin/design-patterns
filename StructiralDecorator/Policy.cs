using System;
using System.Collections.Generic;
using System.Text;

namespace StructuralDecorator
{
    public abstract class CarDecoratorCarPolicy
    {
        public abstract bool TypeAdditionAllowed(Type type, IList<Type> allType);
        public abstract bool ApplicationAllowed(Type type, IList<Type> allType);
    }

    public class ThrowOnCarPolicy : CarDecoratorCarPolicy
    {
        
        public override bool ApplicationAllowed(Type type, IList<Type> allType)
        {
            return Handler(type, allType);
        }

        public override bool TypeAdditionAllowed(Type type, IList<Type> allType)
        {
            return Handler(type, allType);
        }

        private bool Handler(Type type, IList<Type> allTypes)
        {
            if (allTypes.Contains(type))
            {
                throw new InvalidOperationException($"Honda detected! Type is already a {type.FullName}");
            }
            return true;
        }
    }

    public class AbsorbCarPolicy : CarDecoratorCarPolicy
    {
        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return !allTypes.Contains(type);
        }
    }

    public class CarAllowedPolicy : CarDecoratorCarPolicy
    {
        public override bool TypeAdditionAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }

        public override bool ApplicationAllowed(Type type, IList<Type> allTypes)
        {
            return true;
        }
    }
}
