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
            var res = type.GetCustomAttributes().OfType<ApiDescriptionAttribute>().FirstOrDefault();

            if (res == null)
            {
                return null;
            }

            return res.Description;
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

            if (method == null)
            {
                return res.ToArray();
            }

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

            if(method == null)
            {
                return null;
            }

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var parameter = method.GetParameters().FirstOrDefault(p => p.Name == paramName);

                if(parameter == null)
                {
                    return null;
                }

                var res = parameter.GetCustomAttributes().OfType<ApiDescriptionAttribute>();

                if (res.Any())
                {
                    return res.First().Description;
                }
            }

            return null;
        }

        public ApiParamDescription GetApiMethodParamFullDescription(string methodName, string paramName)
        {
            var type = typeof(T);
            var res = new ApiParamDescription
            {
                ParamDescription = new CommonDescription(paramName),
                MaxValue = null,
                MinValue = null,
                Required = false
            };
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if(method == null)
            {
                return res;
            }

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                var parameter = method
                    .GetParameters()
                    .FirstOrDefault(p => p.Name == paramName);

                if (parameter == null)
                {
                    return res;
                }
                
                if (parameter.GetCustomAttributes().OfType<ApiDescriptionAttribute>().Any())
                {
                    res.ParamDescription.Description = parameter
                        .GetCustomAttributes()
                        .OfType<ApiDescriptionAttribute>()
                        .First()
                        .Description;
                }

                if (parameter.GetCustomAttributes().OfType<ApiRequiredAttribute>().Any())
                {
                    res.Required = parameter
                        .GetCustomAttributes()
                        .OfType<ApiRequiredAttribute>()
                        .First()
                        .Required;
                }
               
                if (parameter.GetCustomAttributes().OfType<ApiIntValidationAttribute>().Any())
                {
                    res.MinValue = parameter
                        .GetCustomAttributes()
                        .OfType<ApiIntValidationAttribute>()
                        .First()
                        .MinValue;
                    res.MaxValue = parameter
                        .GetCustomAttributes()
                        .OfType<ApiIntValidationAttribute>()
                        .First()
                        .MaxValue;
                }
            }

            return res;
        }

        public ApiMethodDescription GetApiMethodFullDescription(string methodName)
        {
            var type = typeof(T);
            var res = new ApiMethodDescription
            {
                MethodDescription = new CommonDescription(),
                ParamDescriptions = new ApiParamDescription[0],
                ReturnDescription = new ApiParamDescription()
            };
            var method = type.GetMethods().FirstOrDefault(m => m.Name == methodName);

            if (method == null)
            {
                return null;
            }

            if (method.GetCustomAttributes().OfType<ApiMethodAttribute>().Any())
            {
                
            }

            return null;
        }
    }
}