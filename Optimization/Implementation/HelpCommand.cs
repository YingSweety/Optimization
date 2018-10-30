using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization.Implementation
{

    /// <summary>
    /// help 
    /// </summary>
    public class HelpCommand : IExcuteCommand
    {

        public bool Excute(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                ShowHelp();
                return false;
            }

            string c1 = args[0];

            if (OptCommand.Help.Any(com => string.Compare(com, c1, true) == 0))
            {
                ShowHelp();
            }

            return true;
        }


        void ShowHelp()
        {
            Console.WriteLine();
            Console.WriteLine("op \t 压缩静态资源");
            Console.WriteLine("-p \t 待处理文件的路径");
            Console.WriteLine("-js \t 压缩js文件");
            Console.WriteLine("-css \t 压缩css文件");
            Console.WriteLine();
            Console.WriteLine("Examples:");
            Console.WriteLine();
            Console.WriteLine("Optimization.exe op -p c://test");
            Console.WriteLine();
            Console.WriteLine("Optimization.exe op -p c://test -js");
            Console.WriteLine();
            Console.WriteLine("Optimization.exe op -p c://test -css");
            Console.WriteLine();
            Console.WriteLine("Optimization.exe op c://test/abc.js");
            Console.WriteLine();
            Console.WriteLine("Optimization.exe op c://test/abc.css");
        }


    }

}
