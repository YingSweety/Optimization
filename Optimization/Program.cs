using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    class Program
    {
        static List<IExcuteCommand> ExcuteCommands = new List<IExcuteCommand>();


        /// <summary>
        /// Optimization:静态资源优化
        /// command: -css 、-js 、-p
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            foreach (IExcuteCommand command in ExcuteCommands)
            {
                if (command.Excute(args))
                {
                    break;
                }
            }
        }

        static Program()
        {
            var excuteCommadType = typeof(IExcuteCommand);
            var findTypes = System.Reflection.Assembly.GetAssembly(excuteCommadType).GetTypes();

            foreach (var type in findTypes)
            {
                var t = type.FindInterfaces((filter, filterCriteria) =>
                {
                    if (filterCriteria.ToString() == filter.AssemblyQualifiedName)
                    {
                        return true;
                    }
                    return false;
                }, excuteCommadType.AssemblyQualifiedName);

                if (t != null && t.Any())
                {
                    ExcuteCommands.Add(Activator.CreateInstance(type) as IExcuteCommand);
                }
            }
        }

    }
}
