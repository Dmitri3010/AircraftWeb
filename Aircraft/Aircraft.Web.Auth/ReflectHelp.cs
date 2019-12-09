#region

using System.Reflection;

#endregion

namespace Aircraft.Web.Auth
{
    internal static class ReflectHelp
    {
        public const BindingFlags AccessibleBindingFlags =
            BindingFlags.Public |
            BindingFlags.Static |
            BindingFlags.Instance |
            BindingFlags.NonPublic |
            BindingFlags.IgnoreCase;
    }
}