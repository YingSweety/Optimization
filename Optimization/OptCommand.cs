using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    /// <summary>
    /// 优化命令
    /// </summary>
    public class OptCommand
    {
        public static readonly string[] Help = new string[] { "help", "*?", "-h" };

        public static readonly string[] Optimization = new string[] { "op" };

        public static readonly string[] Path = new string[] { "-p", "-path" };

        public static readonly string[] Js = new string[] { "-js" };

        public static readonly string[] Css = new string[] { "-css" };
    }
}
