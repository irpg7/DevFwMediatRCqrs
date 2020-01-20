using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace Core.Aspects.PostSharp.Caching
{
    [Serializable]
    public class CacheAspect: MethodInterceptionAspect
    {
        Type _cacheType;
        int _cacheTime;
        ICacheManager _cacheManager;

        public CacheAspect(Type cacheType, int cacheTime)
        {
            _cacheType = cacheType;
            _cacheTime = cacheTime;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if(typeof(ICacheManager).IsAssignableFrom(_cacheType) == false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format($"{args.Method.ReflectedType.FullName}");
            var arguments = args.Arguments.ToList();
            var key = string.Format($"{methodName}({string.Join(",",arguments.Select(x=> x != null ? x.ToString() : "<Null>"))})");

            if(_cacheManager.IsAdded(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            base.OnInvoke(args);
            _cacheManager.Add(key, args.ReturnValue, _cacheTime);
        }
    }
}
