using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.ViewModels
{
    /// <summary>
    /// ajax呼叫回傳使用
    /// </summary>
    public class ReData
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
