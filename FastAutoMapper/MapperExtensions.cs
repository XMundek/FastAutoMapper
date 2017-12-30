using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moon.FastAutoMapper
{
    public static class MapperExtensions
    {
        public static TDestination Map<TSource, TDestination>(this TSource obj)
        {
            return new Mapper().Map<TSource, TDestination>(obj);
        }
    }

}
