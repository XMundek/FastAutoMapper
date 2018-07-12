using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Moon.FastAutoMapper
{
    public static class MapperExtensions
    {
        public static TDestination Map<TSource, TDestination>(this TSource obj)
        {
            return Mapper.Map<TSource, TDestination>(obj);
        }
        public static TDestination Map<TDestination>(this object obj)
        {
            return Mapper.Map<TDestination>(obj);
        }
    }

}
