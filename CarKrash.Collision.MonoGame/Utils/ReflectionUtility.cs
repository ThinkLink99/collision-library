using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Collision
{
    public static partial class Util
    {
        public static List<object> GetMembersOfType (object qBase, Type qType)
        {
            // get the Type of our base object "qBase"
            Type t = qBase.GetType();

            List <object> temp = new List<object> ();
            //if (qBase is Microsoft.Xna.Framework.Game) { return temp; }

            // Get array of PropertyInfo for all properties (public, private, protected) on this instance of qBase
            var props = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetIndexParameters().Length == 0 && p.GetValue(qBase) != null);
            foreach (var property in props)
            {
                // Check if this property is equal to the queried type "qType"
                if (qType.IsAssignableFrom(property.GetValue(qBase).GetType()))
                {
                    // if it is, add it to temp to be returned by 
                    // the function if it doesn't already exist in temp
                    if (!temp.Contains(property.GetValue(qBase)))
                        temp.Add(property.GetValue(qBase));
                }
            }

            // fields are same process as properties, so see above comments.
            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(p => p.GetValue(qBase) != null);
            foreach (var field in fields)
            {
                if (qType.IsAssignableFrom(field.GetValue(qBase).GetType()))
                {
                    if (!temp.Contains(field.GetValue(qBase)))
                        temp.Add(field.GetValue(qBase));
                }
            }
            return temp;
        }
        public static List<object> GetListsOfType (object qBase, Type qType)
        {
            Type t = qBase.GetType();
            List<object> temp = new List<object>();
            //if (qBase is Microsoft.Xna.Framework.Game) { return temp; }

            var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetIndexParameters().Length == 0 && p.GetValue(qBase) != null &&  p.GetValue(qBase) is System.Collections.IList);
            foreach (var property in properties)
            {
                var args = property.GetValue(qBase).GetType().GetGenericArguments();
                if (args != null && args.Length > 0 && qType.IsAssignableFrom(args[0]))
                {
                    var tempVar = property.GetValue(qBase);
                    if (property.GetValue(qBase) as IList<object> == null)
                    {
                        temp.Add(property.GetValue(qBase));
                    }
                    else
                    {
                        temp.AddRange(property.GetValue(qBase) as IList<object>);

                    }
                }
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetValue(qBase) != null && p.GetValue(qBase) is System.Collections.IList);
            foreach (var field in properties)
            {
                var args = field.GetValue(qBase).GetType().GetGenericArguments();
                if (args != null && args.Length > 0 && qType.IsAssignableFrom(args[0]))
                {
                    var tempVar = field.GetValue(qBase);
                    if (field.GetValue(qBase) as IList<object> == null)
                    {
                        temp.Add(field.GetValue(qBase));
                    }
                    else
                    {
                        temp.AddRange(field.GetValue(qBase) as IList<object>);

                    }
                }
            }
            return temp;
        }
        public static List<object> GetMembersInterfacedFromType (object qBase, Type qType)
        {
            Type t = qBase.GetType();
            List<object> temp = new List<object>();
            //if (qBase is Microsoft.Xna.Framework.Game) { return temp; }

            var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetIndexParameters().Length == 0 && p.GetValue(qBase) != null);
            foreach (var property in properties)
            {
                if (property.GetValue(qBase) != null)
                {
                    var interfaces = property.GetValue(qBase).GetType().GetInterfaces();
                    if (interfaces.Contains(qType))
                    {
                        // if we we one that matches, add it temp, if it doesn't already exist.
                        if (!temp.Contains(property.GetValue(qBase)))
                            temp.Add(property.GetValue(qBase));
                    }
                }
            }

            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetValue(qBase) != null);
            foreach (var field in fields)
            {
                if (field.GetValue(qBase) != null)
                {
                    var interfaces = field.GetValue(qBase).GetType().GetInterfaces();
                    if (interfaces.Contains(qType))
                    {
                        // if we we one that matches, add it temp, if it doesn't already exist.
                        if (!temp.Contains(field.GetValue(qBase)))
                            temp.Add(field.GetValue(qBase));
                    }
                }
            }

            return temp;
        }
        public static List<object> GetMembersOfTypeFromMember (object qBase, Type qType)
        {
            Type t = qBase.GetType();

            List<object> temp = new List<object>();
            //if (qBase is Microsoft.Xna.Framework.Game) { return temp; }

            var properties = t.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                         .Where(p => p.GetValue(qBase) != null);
            var fields = t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                          .Where(p => p.GetValue(qBase) != null);
            foreach (var property in properties)
            {
                temp.AddRange(GetMembersOfType(qBase, qType));
                temp.AddRange(GetMembersOfType(property.GetValue(qBase), qType));
                temp.AddRange(GetListsOfType(property.GetValue(qBase), qType));
                temp.AddRange(GetMembersInterfacedFromType(property.GetValue(qBase), qType));

                if (temp.Count > 0) temp.AddRange(GetMembersOfTypeFromMember(property.GetValue(qBase), qType));
            }
            foreach (var field in fields)
            {
                temp.AddRange(GetMembersOfType(qBase, qType));
                temp.AddRange(GetMembersOfType(field.GetValue(qBase), qType));
                temp.AddRange(GetListsOfType(field.GetValue(qBase), qType));
                temp.AddRange(GetMembersInterfacedFromType(field.GetValue(qBase), qType));

                if (temp.Count > 0) temp.AddRange(GetMembersOfTypeFromMember(field.GetValue(qBase), qType));
            }

            return temp;
        }


        public static float Distance (int x1, int x2, int y1, int y2)
        {
            return MathF.Sqrt(MathF.Pow((x1 - x2), 2) + MathF.Pow((y1 - y2), 2));
        }
        public static bool PointIsInCircle (int xP, int xC, int yP, int yC, float r)
        {
            return r > Distance(xC, xP, yC, yP);
        }
    }
}
