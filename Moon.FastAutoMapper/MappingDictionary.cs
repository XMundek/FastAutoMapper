using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Moon.FastAutoMapper
{
    //dictionary used to store mapping information between source and destination type 
    internal abstract class MappingDictionary<T> : Dictionary<long, T> where T : class
    {
        public MappingDictionary() : base(256){}

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected abstract T CreateMapping(Type sourceType, Type destinationType);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public T GetMapping(Type sourceType, Type destType)
        {
            var key = Mapper.GetMappingKey(sourceType, destType);
            if (this.TryGetValue(key, out T value))
            {
                return value;
            }
            var mappingInfo = CreateMapping(sourceType, destType);
            if (mappingInfo == null) return null;
            lock (this)
            {
                this[key] = mappingInfo;
                return mappingInfo;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetMapping(long key, T value)
        {
            lock (this)
            {
                this[key] = value;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void DeleteMapping(long key)
        {
            lock (this)
            {
                if (this.ContainsKey(key))
                    this.Remove(key);
            }
        }
    }
}
