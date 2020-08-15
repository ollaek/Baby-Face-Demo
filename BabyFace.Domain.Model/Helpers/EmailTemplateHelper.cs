﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BabyFace.Domain.Model.Helpers
{
    public static class EmailTemplateHelper
    {
        public static string CustomBindingPropertiesIntoString(string body, object model, Type modeltype)
        {
            // can't name property starting with numbers, 
            // but they are possible
            Regex findProperties = new Regex(@"{{([a-zA-Z]+[0-9]*)}}");

            // order by desc, since I want to replace all substrings correctly
            // after I replace one part length of string is changed 
            // and all characters at Right are moved forward or back
            var res = findProperties.Matches(body)
                .Cast<Match>()
                .OrderByDescending(i => i.Index);

            foreach (Match item in res)
            {
                // get full substring with pattern "{Name}"
                var allGroup = item.Groups[0];

                //get first group this is only field name there
                var foundPropGrRoup = item.Groups[1];
                var propName = foundPropGrRoup.Value;

                object value = string.Empty;


                // use reflection to get property
                // Note: if you need to use fields use GetField
                var prop = modeltype.GetProperty(propName);

                if (prop != null)
                {
                    value = prop.GetValue(model, null);
                }


                body = body.Remove(allGroup.Index, allGroup.Length)
                    .Insert(allGroup.Index, value.ToString());

            }

            return body;
        }

    }
}
