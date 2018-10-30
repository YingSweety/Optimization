using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;
using System.IO;
using Microsoft.Ajax.Utilities;

namespace Optimization.Minify
{
    /// <summary>
    /// 压缩js文本
    /// </summary>
    public class MinifyJsContent
    {
        internal static readonly JsMinify Instance = new JsMinify();

        private readonly string _file_name;
        public MinifyJsContent(string file)
        {
            _file_name = file;
        }

        public virtual void Process()
        {
            if (!File.Exists(_file_name))
            {
                Console.WriteLine("文件:{0}不存在", _file_name);
            }

            Minifier minifier = new Minifier();
            CodeSettings settings = new CodeSettings();
            settings.EvalTreatment = EvalTreatment.MakeAllSafe;
            settings.PreserveImportantComments = false;

            string content = File.ReadAllText(_file_name);
            string str = minifier.MinifyJavaScript(content, settings);
            if (minifier.ErrorList != null && minifier.ErrorList.Count > 0)
            {
                str = GenerateErrorResponse(content, minifier.ErrorList);
            }

            string new_file_name = _file_name.Substring(0, _file_name.LastIndexOf('.')) + ".min.js";

            File.WriteAllText(new_file_name, str);

            Console.WriteLine("成功将文件:{0}进行压缩,输出文件为:{1}", _file_name, new_file_name);
        }

        protected virtual string GenerateErrorResponse(string content, IEnumerable<object> errors)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("/* ");
            foreach (object obj2 in errors)
            {
                builder.AppendLine(obj2.ToString());
            }
            builder.AppendLine(" */");
            builder.Append(content);
            return builder.ToString();
        }


    }


}
