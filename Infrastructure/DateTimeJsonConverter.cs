using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Nop.Plugin.Misc.PersianCalendar
{
    /// <summary>
    /// nopforest convertor
    /// </summary>
    public class DateTimeJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime) || objectType == typeof(DateTime?);
        }

        // this converter is only used for serialization, not to deserialize
        public override bool CanRead => false;

        // implement this if you need to read the string representation to create an AccountId
        public override object ReadJson(JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        
        public override void WriteJson(JsonWriter writer,
            object value,
            JsonSerializer serializer)
        {
            if (!(value is DateTime dateTime))
                throw new JsonSerializationException("Expected DateTime object value.");

            //TODO DateTime json writer
            if (dateTime > DateTime.MinValue)
                //fix invalid date error in DataTable
                //writer.WriteValue(dateTime.ToString(CultureInfo.CurrentCulture));
                writer.WriteValue(dateTime.ToString("yyyy/MM/dd HH:mm:ss", CultureInfo.CurrentCulture));
            else
                //fix /Admin/Product/ProductList net::ERR_CONNECTION_RESET 200 (OK)
                writer.WriteValue(dateTime);
        }
    }
}