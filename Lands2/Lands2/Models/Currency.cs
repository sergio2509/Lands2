﻿namespace Lands2.Models
{
   using Newtonsoft.Json;

   class Currency
   {

      [JsonProperty(PropertyName = "code")]
      public string Code
      {
         get; set;
      }

      [JsonProperty(PropertyName = "name")]
      public string Name
      {
         get; set;
      }

      [JsonProperty(PropertyName = "symbol")]
      public string Symbol
      {
         get; set;
      }
   }

}
