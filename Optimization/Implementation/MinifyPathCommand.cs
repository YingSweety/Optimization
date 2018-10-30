using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Optimization.Implementation
{
    /// <summary>
    /// 压缩文件目录命令
    /// </summary>
    public class MinifyPathCommand : IExcuteCommand
    {

        public bool Excute(string[] args)
        {
            if (args == null || args.Length < 3)
            {
                return false;
            }

            string path = args[2];

            if (!OptCommand.Path.Any(cmd => string.Compare(cmd, args[1]) == 0))
            {
                return false;
            }

            if (!Directory.Exists(path))
            {
                Console.WriteLine("目录{0},不存在", path);
                return false;
            }

            List<string> jsfiles = new List<string>();
            List<string> cssfiles = new List<string>();
            if (args.Length < 4)
            {
                //js && css
                foreach (var file in Directory.GetFiles(path, "*.js", SearchOption.AllDirectories))
                {
                    if (!file.EndsWith(".min.js", StringComparison.CurrentCultureIgnoreCase))
                    {
                        jsfiles.Add(file);
                    }
                }

                foreach (var file in Directory.GetFiles(path, "*.css", SearchOption.AllDirectories))
                {
                    if (!file.EndsWith(".min.css", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cssfiles.Add(file);
                    }
                }
            }
            else if (OptCommand.Js.Any(com => string.Compare(com, args[3]) == 0))
            {
                //js
                foreach (var file in Directory.GetFiles(path, "*.js", SearchOption.AllDirectories))
                {
                    if (!file.EndsWith(".min.js", StringComparison.CurrentCultureIgnoreCase))
                    {
                        jsfiles.Add(file);
                    }
                }
            }
            else if (OptCommand.Css.Any(com => string.Compare(com, args[3]) == 0))
            {
                //css
                foreach (var file in Directory.GetFiles(path, "*.css", SearchOption.AllDirectories))
                {
                    if (!file.EndsWith(".min.css", StringComparison.CurrentCultureIgnoreCase))
                    {
                        cssfiles.Add(file);
                    }
                }
            }


            foreach (var file in jsfiles)
            {
                Minify.MinifyJsContent js = new Minify.MinifyJsContent(file);
                js.Process();
            }

            foreach (var file in cssfiles)
            {
                Minify.MinifyCssContent css = new Minify.MinifyCssContent(file);
                css.Process();
            }
            return true;
        }

    }

}
