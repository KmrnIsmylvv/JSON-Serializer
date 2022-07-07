using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BLL.Services
{
    public static class JsonConverter
    {
        public static string Serialize(object obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine();
            sb.Append("{");
            Type Type = obj.GetType();
            IList<PropertyInfo> propsss = new List<PropertyInfo>(Type.GetProperties());
            foreach (PropertyInfo item in propsss)
            {
                object propValue = item.GetValue(obj, null);
                sb.AppendLine();
                sb.Append(@"[" + item.Name + "=" + propValue + "]");
            }
            sb.AppendLine();
            sb.Append("}");
            return sb.ToString();
        }

        public static T Deserialize<T>(string serializeData, T target) where T : new()
        {
            List<string> deserializedObjects = Extract(serializeData);

            foreach (var obj in deserializedObjects)
            {
                List<HelperData> properties = ExtractValuesFromData(obj);
                foreach (HelperData item in properties)
                {

                    PropertyInfo propInfo = target.GetType().GetProperty(item.PropertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                    propInfo?.SetValue(target,
                    Convert.ChangeType(item.Value, propInfo.PropertyType), null);
                }
            }
            return target;
        }

        private static List<string> Extract(string text, string startString = "{", string endString = "}")
        {
            if (text.Contains("\n"))
                text = text.Replace("\n", string.Empty);

            if (text.Contains("\t"))
                text = text.Replace("\t", string.Empty);

            List<string> contest = new List<string>();
            bool exit = false;
            while (!exit)
            {
                int indexStart = text.IndexOf(startString, StringComparison.Ordinal);
                int indexEnd = text.LastIndexOf(endString);
                if (indexStart != -1 && indexEnd != -1)
                {
                    contest.Add(text.Substring(indexStart + startString.Length,
                        indexEnd - indexStart - startString.Length));
                    text = text.Substring(indexEnd + endString.Length);
                }
                else
                {
                    exit = true;
                }
            }
            return contest;
        }

        private static List<HelperData> ExtractValuesFromData(string text)
        {
            List<HelperData> listMyData = new List<HelperData>();
            text = String.Concat(text.Where(c => !Char.IsWhiteSpace(c)));
            int index = text.IndexOf(":{");
            if (index != -1)
            {

                int nearest = 0;

                for (int i = 0; i < text.Length; i++)
                {
                    if (text[i] == ',')
                    {
                        int CommaIndex = index - i;
                        if (CommaIndex > 0)
                            nearest = i;
                        else
                            break;
                    }
                }

                string text1 = text.Substring(0, nearest);
                string text2 = text.Remove(0, nearest + 1);
                string[] arr = new string[2];
                arr[0] = text1;
                arr[1] = text2;
                string[] firstdata = arr[0].Split(",");

                List<string> secondsata = Extract(arr[1], "{", "}");
                string[] seconddataa = secondsata[0].Split(',');

                foreach (var item in firstdata)
                {

                    string pName = item.Substring(0, item.IndexOf(":", StringComparison.Ordinal));
                    string pValue = item.Substring(item.IndexOf(":", StringComparison.Ordinal) + 1);
                    listMyData.Add(new HelperData { PropertyName = pName, Value = pValue });
                }

                foreach (string item in seconddataa)
                {
                    if (item.Contains(":"))
                    {
                        string pName = item.Substring(0, item.IndexOf(":", StringComparison.Ordinal)).ToLower();
                        string pValue = item.Substring(item.IndexOf(":", StringComparison.Ordinal) + 1).ToLower();
                        listMyData.Add(new HelperData { PropertyName = pName, Value = pValue });
                    }
                }
            }

            return listMyData;
        }
    }
}
