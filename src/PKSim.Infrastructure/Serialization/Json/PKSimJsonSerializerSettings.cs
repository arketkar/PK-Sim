﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PKSim.Infrastructure.Serialization.Json
{
   public class PKSimJsonSerializerSettings : JsonSerializerSettings
   {
      public PKSimJsonSerializerSettings()
      {
         TypeNameHandling = TypeNameHandling.Auto;
         NullValueHandling = NullValueHandling.Ignore;
         ContractResolver = new WritablePropertiesOnlyResolver();
         Converters.Add(new StringEnumConverter());
         Converters.Add(new NullabeDoubleJsonConverter());
         Converters.Add(new ColorConverter());
      }
   }
}