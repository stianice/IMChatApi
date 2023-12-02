using System.Text.Json;

namespace ChatApi.Common.Components.Json
{
    public static class JsonHelper
    {
        private static JsonSerializerOptions? _serializerOptions;


        private static JsonSerializerOptions SerializerOptions
        {
            get
            {
                if (_serializerOptions == null) throw new NullReferenceException(nameof(SerializerOptions));

                return _serializerOptions;
            }

        }
        public static void Configure(JsonSerializerOptions options)
        {
            if (_serializerOptions != null)
            {
                throw new Exception($"{nameof(SerializerOptions)}不可修改！");
            }

            _serializerOptions = options ?? throw new ArgumentNullException(nameof(options));
        }

        public static string Serialize<TValue>(TValue value)
        {
            return JsonSerializer.Serialize(value, _serializerOptions);
        }

        public static byte[] SerializeToUtf8Bytes<TValue>(TValue value)
        {
            return JsonSerializer.SerializeToUtf8Bytes(value, _serializerOptions);
        }

        public static TValue? Deserialize<TValue>(string json, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Deserialize<TValue>(json, options ?? SerializerOptions);
        }

        public static object? Deserialize(string json, Type returnType, JsonSerializerOptions? options = null)
        {
            return JsonSerializer.Deserialize(json, returnType, options ?? SerializerOptions);
        }

        public static TValue? Deserialize<TValue>(ReadOnlySpan<byte> utf8Json)
        {
            if (utf8Json == null)
            {
                return default(TValue);
            }
            return JsonSerializer.Deserialize<TValue>(utf8Json, SerializerOptions);
        }


    }
}
