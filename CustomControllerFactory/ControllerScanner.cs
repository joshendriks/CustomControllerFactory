using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace CustomControllerFactory
{
    /// <summary>
    /// see http://csharpindepth.com/Articles/General/Singleton.aspx
    /// </summary>
    public sealed class ControllerScanner
    {
        private IEnumerable<string> _controllers;

        public IEnumerable<string> Controllers
        {
            get
            {
                return _controllers;
            }
        }

        private ControllerScanner()
        {
            _controllers = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .Select(t => t.Name.Remove(t.Name.IndexOf("Controller")))
                .ToArray();
        }

        public static ControllerScanner Instance { get { return Nested.instance; } }

        private class Nested
        {
            // Explicit static constructor to tell C# compiler
            // not to mark type as beforefieldinit
            static Nested()
            {
            }

            internal static readonly ControllerScanner instance = new ControllerScanner();
        }
    }
}