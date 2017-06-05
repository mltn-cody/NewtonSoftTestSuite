using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// S
// O
// L
// I
// D

namespace NewtonSoftTestSuite
{
    class Program
    {
        static void Main(string[] args)
        {
            var str =
               "{\"OldLimits\":{\"OccurrenceLimit\":{\"type\":\"Combobox\",\"readonly\":false,\"hasDependencies\":false,\"displayRule\":null,\"label\":\"Occurrence Limit :\",\"value\":\"300000.00\",\"listItems\":[{\"value\":\"300000.00\",\"display\":\"$300,000\",\"displayRule\":null},{\"value\":\"500000.00\",\"display\":\"$500,000\",\"displayRule\":null},{\"value\":\"1000000.00\",\"display\":\"$1,000,000\",\"displayRule\":null},{\"value\":\"2000000.00\",\"display\":\"$2,000,000\",\"displayRule\":null}],\"listCode\":\"Default_OccurrenceLimit\",\"groups\":[],\"coveragedetailId\":100001,\"index\":1},\"AggregateLimit\":{\"type\":\"Combobox\",\"readonly\":false,\"hasDependencies\":false,\"displayRule\":null,\"label\":\"Aggregate Limit :\",\"value\":\"600000.00\",\"listItems\":[{\"value\":\"600000.00\",\"display\":\"$600,000\",\"displayRule\":null},{\"value\":\"1000000.00\",\"display\":\"$1,000,000\",\"displayRule\":null},{\"value\":\"2000000.00\",\"display\":\"$2,000,000\",\"displayRule\":null},{\"value\":\"4000000.00\",\"display\":\"$4,000,000\",\"displayRule\":null}],\"listCode\":\"Default_AggregateLimit\",\"groups\":[],\"coveragedetailId\":101001,\"index\":2}},\"NewLimits\":{\"OccurrenceLimit\":{\"type\":\"Combobox\",\"readonly\":false,\"hasDependencies\":false,\"displayRule\":null,\"label\":\"Occurrence Limit :\",\"value\":\"2000000.00\",\"listItems\":[{\"value\":\"300000.00\",\"display\":\"$300,000\",\"displayRule\":null},{\"value\":\"500000.00\",\"display\":\"$500,000\",\"displayRule\":null},{\"value\":\"1000000.00\",\"display\":\"$1,000,000\",\"displayRule\":null},{\"value\":\"2000000.00\",\"display\":\"$2,000,000\",\"displayRule\":null}],\"listCode\":\"Default_OccurrenceLimit\",\"groups\":[],\"coveragedetailId\":100001,\"index\":1},\"AggregateLimit\":{\"type\":\"Combobox\",\"readonly\":false,\"hasDependencies\":false,\"displayRule\":null,\"label\":\"Aggregate Limit :\",\"value\":\"4000000.00\",\"listItems\":[{\"value\":\"600000.00\",\"display\":\"$600,000\",\"displayRule\":null},{\"value\":\"1000000.00\",\"display\":\"$1,000,000\",\"displayRule\":null},{\"value\":\"2000000.00\",\"display\":\"$2,000,000\",\"displayRule\":null},{\"value\":\"4000000.00\",\"display\":\"$4,000,000\",\"displayRule\":null}],\"listCode\":\"Default_AggregateLimit\",\"groups\":[],\"coveragedetailId\":101001,\"index\":2}},\"Comments\":\"test\"}";

            //var json = JObject.Parse(str);
            //Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();
            //foreach (var p in json.Properties()) {
            //    if (!(p.Value is JObject)) {
            //        output.Add(p.Name, p.Value);
            //        continue;
            //    };
            //    output.Add(p.Name, GetPropertyValueAndType(p).ToList());
            //};

            Console.Write(ResolveType(str));
            Console.Read();

        }


        private static Object ResolveType(object value)
        {
            var json = JObject.Parse(value.ToString());
            Dictionary<string, dynamic> output = new Dictionary<string, dynamic>();

            foreach (var p in json.Properties())
            {
                if (!(p.Value is JObject))
                {
                    output.Add(p.Name, p.Value);
                    continue;
                };
                output.Add(p.Name, GetPropertyValueAndType(p).ToList());
            };

            //foreach (var kvp in output) {
            //    if (kvp.Value.Type == "ComboBox")
            //    {
            //        return PrettyStringComboBxResolver(kvp);
            //    }
            //    else if (kvp.Value.Type == "Date")
            //    {
            //        return PrettyStringDateResolver(kvp);
            //    }
            //    else if (kvp.Value.Type == "Radio")
            //    {
            //        return PrettyStringRadioBtnResolver(kvp);
            //    }
            //    else {
            //        return kvp;
            //    }
            //}

            return JObject.FromObject(output).ToString();
        }

        private static object PrettyStringRadioBtnResolver(KeyValuePair<string, dynamic> kvp)
        {
            throw new NotImplementedException();
        }

        private static object PrettyStringDateResolver(KeyValuePair<string, dynamic> kvp)
        {
            throw new NotImplementedException();
        }

        private static string ResovlveRadioButtons(KeyValuePair<string, dynamic> kvp)
        {
            return string.Empty;
        }

        private static string PrettyStringComboBxResolver(KeyValuePair<string, dynamic> kvp)
        {
            var builder = new StringBuilder();
            return string.Empty;
        }

        private static IEnumerable<dynamic> GetPropertyValueAndType(JProperty property)
        {
            if (((JObject)property.Value).Value<string>("type") != null) yield return new { Name =  property.Name, Type = ((JObject)property.Value).Value<string>("type"), Value = ((JObject)property.Value).Value<string>("value") };

            var prop = property;
            JObject t;

            if (prop.Value is JObject)
            {
                t = prop.Value as JObject;
                foreach (var innerProperty in t.Properties()) {
                    if(innerProperty.Value is JObject)
                        foreach (var deepcopy in GetPropertyValueAndType(innerProperty)) {
                            yield return deepcopy;
                        }
                }
            }
        }
    }
}

