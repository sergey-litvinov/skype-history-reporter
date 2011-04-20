using System;
using System.Linq.Expressions;

namespace SkypeHistory.Interfaces
{
    public interface ICacheService
    {
        T Get<T>(string key,Func<T> handler);
        void Clear();
    }
}