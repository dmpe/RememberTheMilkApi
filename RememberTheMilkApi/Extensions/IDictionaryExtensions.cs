﻿using System.Collections.Generic;

namespace RememberTheMilkApi.Extensions
{
    public static class DictionaryExtensions
    {
        public static void CreateNewOrUpdateExisting<TKey, TValue>(this IDictionary<TKey, TValue> map, TKey key, TValue value) => map[key] = value;
    }
}