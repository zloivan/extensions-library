// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using System;
using IKhom.ExtensionsLibrary.Runtime.helpers;
using JetBrains.Annotations;
using Newtonsoft.Json;
using UnityEngine;

namespace IKhom.ExtensionsLibrary.Runtime
{
    public static class JsonExtensions
    {
        private static readonly ILogger Logger = new ExtensionsLogger();

        /// <summary>
        /// Deserializes the provided JSON string into an object of type T. If the deserialization fails using <see cref="JsonUtility"/>, it falls back to using <see cref="JsonConvert"/> from Newtonsoft.Json.
        /// </summary>
        /// <typeparam name="T">The type of the object to be deserialized from JSON.</typeparam>
        /// <param name="json">The JSON string to be deserialized.</param>
        /// <param name="resultValidator">An optional function that takes an instance of T and returns a boolean value indicating whether the instance is valid. If provided, the function is called after the initial deserialization attempt, and the process will fail if the instance is deemed invalid.</param>
        /// <returns>An instance of T deserialized from the provided JSON string.</returns>
        /// <exception cref="Exception">Thrown when the deserialized object is null or when the deserialized data is invalid.</exception>
        /// <exception cref="JsonReaderException">Thrown when the deserialized object is null or when the deserialized data is invalid after falling back to Newtonsoft.Json.</exception>
        public static T FromJson<T>([NotNull] this string json, Func<T, bool> resultValidator = null)
        {
            Validator.ValidateNotNullOrEmpty(json, nameof(json));

            T data;
            try
            {
                data = JsonUtility.FromJson<T>(json);

                if (data is null)
                {
                    throw new Exception("Deserialized object is null");
                }

                if (resultValidator != null && !resultValidator(data))
                {
                    throw new Exception("Deserialized data is invalid");
                }
            }
            catch (Exception ex)
            {
                Logger.LogWarning("JsonExtensions",
                    $"JsonUtility deserialization failed: {ex.Message}. Falling back to Newtonsoft.Json.");
                try
                {
                    data = JsonConvert.DeserializeObject<T>(json);

                    if (data is null)
                    {
                        throw new JsonReaderException("Deserialized object is null");
                    }

                    if (resultValidator != null && !resultValidator(data))
                    {
                        throw new JsonReaderException("Deserialized data is invalid");
                    }
                }
                catch (Exception newtonEx)
                {
                    Logger.LogError("JsonExtensions",
                        $"Newtonsoft.Json deserialization also failed: {newtonEx.Message}");

                    return default;
                }
            }

            return data;
        }

        /// <summary>
        /// Serializes the provided object of type T into a JSON string. If the serialization fails using <see cref="JsonUtility"/>, it falls back to using <see cref="JsonConvert"/> from Newtonsoft.Json.
        /// </summary>
        /// <typeparam name="T">The type of the object to be serialized into JSON.</typeparam>
        /// <param name="obj">The object to be serialized.</param>
        /// <param name="indented">A boolean value indicating whether the JSON string should be indented for better readability. Default is false.</param>
        /// <returns>A JSON string representation of the provided object.</returns>
        /// <exception cref="Exception">Thrown when the serialization process fails and falls back to Newtonsoft.Json.</exception>
        public static string ToJson<T>([NotNull] this T obj, bool indented = false)
        {
            Validator.ValidateNotNull(obj, nameof(obj));

            try
            {
                var json = JsonUtility.ToJson(obj, indented);

                if (json != "{}")
                    return json;

                Logger.LogWarning("JsonExtensions",
                    "JsonUtility serialization returned empty json. Falling back to Newtonsoft.Json.");

                json = JsonConvert.SerializeObject(obj, indented ? Formatting.Indented : Formatting.None);

                if (json == "{}")
                {
                    Logger.LogError("JsonExtensions", "Newtonsoft.Json serialization also returned empty json...");
                }

                return json;
            }
            catch (Exception ex)
            {
                Logger.LogError("JsonExtensions", $"Serialization failed: {ex.Message}");
                throw;
            }
        }
    }
}