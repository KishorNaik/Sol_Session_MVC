using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sol_Session
{
    public static class SessionComplex
    {
        public static void SetData<TModel>(this ISession session, string key, TModel model) where TModel : class
        {
            session.SetString(key, JsonConvert.SerializeObject(model));
        }

        public static TModel GetData<TModel>(this ISession session, string key) where TModel : class
        {
            return JsonConvert.DeserializeObject<TModel>(session.GetString(key));
        }
    }
}