using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Optimization.Minify
{
    public class MinifyCssContent
    {
        internal static readonly CssMinify Instance = new CssMinify();

        private readonly string _file_name;
        public MinifyCssContent(string file)
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
            CssSettings settings = new CssSettings();
            settings.CommentMode = CssComment.None;

            string content = File.ReadAllText(_file_name);

            string str = minifier.MinifyStyleSheet(content, settings);
            if (minifier.ErrorList.Count > 0)
            {
                this.GenerateErrorResponse(content, minifier.ErrorList);
            }

            string new_file_name = _file_name.Substring(0, _file_name.LastIndexOf('.')) + ".min.css";

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
