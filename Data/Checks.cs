using System;

namespace TeamSL.Infrastructure.Data
{
    public class Checks
    {
        public static void NotNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException();
        }

        public static void NotNull(object obj, string argumentName)
        {
            if (obj == null)
                throw new ArgumentNullException(argumentName);
        }
    }
}