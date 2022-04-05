using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Documentation
{
    public class Specifier<T> : ISpecifier
    {
        public string GetApiDescription()
        {
            var type = typeof(T);
            return type.GetCustomAttributes().OfType<ApiDescriptionAttribute>().First().Description;
        }

        public string[] GetApiMethodNames()
        {
            var type = typeof(T);
            var res = new List<string>();

            foreach(var item in type.GetMethods())
            {
                if (item.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
                {
                    res.Add(item.Name);
                }
            }

            return res.ToArray();
        }

        public string GetApiMethodDescription(string methodName)
        {
            var type = typeof(T);
            
            foreach(var item in type.GetMethods())
            {
                if (item.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
                {
                    if(item.Name == methodName)
                    {
                        return item.GetCustomAttributes().OfType<ApiDescriptionAttribute>().First().Description;
                    }
                }
            }

            return null;
        }

        public string[] GetApiMethodParamNames(string methodName)
        {
            var type = typeof(T);
            var res = new List<string>();
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                foreach(var item in method.GetParameters())
                {
                    res.Add(item.Name);
                }
            }

            return res.ToArray();
        }

        public string GetApiMethodParamDescription(string methodName, string paramName)
        {
            var type = typeof(T);
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var parameter = method.GetParameters().FirstOrDefault(p => p.Name == paramName);
                return parameter.CustomAttributes.OfType<ApiDescriptionAttribute>().FirstOrDefault().Description;
            }

            return null;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            var type = typeof(T);
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var parameter = method.GetParameters().FirstOrDefault(p => p.Name == paramName);
                return parameter.GetCustomAttributes().OfType<ApiParamDescription>().First();
            }

            return null;
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            var type = typeof(T);
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                return method.GetCustomAttributes().OfType<ApiMethodDescription>().First();
            }

            return null;
        }
    }
}