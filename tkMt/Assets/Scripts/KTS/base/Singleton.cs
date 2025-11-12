



namespace KTS
{
    /// <summary>
    /// 单例模式
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> where T : class, new()
    {
        private static T _instance;
        private static readonly object _lock = new object();

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        _instance = new();
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 重置单例实例（用于单元测试或热更场景切换）
        /// </summary>
        public static void Reset()
        {
            _instance = null;
        }
    }

}


/* 
 * 问题：
 * 1. 使用System.Activator.CreateInstance(typeof(T), true) 通过反射的方式创建单例，和直接new有什么区别？
 * 2. lock锁，在第一次if之前是不是就应该加了，或者应该在lock里，new之前再判断一次是否为空
 * 3. 懒汉模式 使用System.Lazy
 * 4. 自动注册 https://zhuanlan.zhihu.com/p/40751037
 */