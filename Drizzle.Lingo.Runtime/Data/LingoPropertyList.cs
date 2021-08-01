﻿using System.Collections.Generic;
using System.Dynamic;
using Serilog;

namespace Drizzle.Lingo.Runtime
{
    public class LingoPropertyList : DynamicObject
    {
        public Dictionary<dynamic, dynamic?> Dict { get; }

        public int length => Dict.Count;

        public LingoPropertyList(Dictionary<dynamic, dynamic?> dict)
        {
            Dict = dict;
        }

        public LingoPropertyList()
        {
            Dict = new Dictionary<dynamic, dynamic?>();
        }

        public LingoPropertyList(int capacity)
        {
            Dict = new Dictionary<dynamic, dynamic?>(capacity);
        }

        public dynamic this[dynamic index]
        {
            get => Dict[index];
            set => Dict[index] = value;
        }

        public void addprop(dynamic? key, dynamic? value)
        {
            if (Dict.ContainsKey(key))
                Log.Warning("addprop duplicate key: {Key}", key);

            Dict[key] = value;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return Dict.TryGetValue(binder.Name, out result) ||
                   Dict.TryGetValue(new LingoSymbol(binder.Name), out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object? value)
        {
            Dict[binder.Name] = value;
            return true;
        }
    }
}