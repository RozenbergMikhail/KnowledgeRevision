using System.Collections.Generic;

namespace X.Dotnet
{
    public static class ListFactory
    {
        public static IList<T> CreateList<T>(params T[] values)
        {
            return values;
        }
    }
}
