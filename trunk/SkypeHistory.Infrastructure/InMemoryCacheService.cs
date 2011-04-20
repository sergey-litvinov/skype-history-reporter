using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SkypeHistory.Interfaces;

namespace SkypeHistory.Infrastructure
{
    public class InMemoryCacheService : ICacheService
    {
        private readonly Dictionary<string, object > cache = new Dictionary<string,object>();

        public T Get<T>(string key, Func<T> handler)
        {
            if (cache.ContainsKey(key))
                return (T) cache[key];
            var result = handler();
            cache.Add(key, result);
            return result;
        }

        public void Clear()
        {
            cache.Clear();
        }
    }
}