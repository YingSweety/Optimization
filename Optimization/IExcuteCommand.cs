using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optimization
{
    /// <summary>
    /// 执行命令
    /// </summary>
    public interface IExcuteCommand
    {

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="args"></param>
        bool Excute(string[] args);
    }
}
