using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Optimization.Implementation
{
    /// <summary>
    /// 压缩文件命令
    /// </summary>
    public class MinifyFileCommand : IExcuteCommand
    {
        public bool Excute(string[] args)
        {
            if (args == null || args.Length != 2)
            {
                return false;
            }

            string file = args[1];

            if (!File.Exists(file))
            {
                Console.WriteLine("文件:{0}不存在", file);
                return false;
            }

            if (Regex.IsMatch(file, ".*.js", RegexOptions.IgnoreCase))
            {
                Minify.MinifyJsContent js = new Minify.MinifyJsContent(file);
                js.Process();
            }
            else if (Regex.IsMatch(file, ".*.css", RegexOptions.IgnoreCase))
            {
                Minify.MinifyCssContent css = new Minify.MinifyCssContent(file);
                css.Process();
            }

            return true;
        }

    }
}
