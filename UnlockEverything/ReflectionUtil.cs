using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace UnlockEverything
{
    public static class ReflectionUtil
    {
        private const BindingFlags _allBindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;


        //Invokes a (static?) private method with name "methodName" and params "methodParams", returns an object of the specified type
        public static T InvokeMethod<T>(this object obj, string methodName, params object[] methodParams) => (T)InvokeMethod(obj, methodName, methodParams);

        //Invokes a (static?) private method with name "methodName" and params "methodParams"
        public static object InvokeMethod(this object obj, string methodName, params object[] methodParams)
        {
            MethodInfo method = obj.GetType().GetMethod(methodName, _allBindingFlags);
            if (method == null)
                throw new InvalidOperationException($"{methodName} is not a member of {obj.GetType().Name}");
            return method.Invoke(obj, methodParams);
        }
    }
}
