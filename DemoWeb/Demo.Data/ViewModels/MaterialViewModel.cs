using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.ViewModels
{
    public class MaterialViewModel
    {
        public List<MaterialInfo> ListData { get; set; }
    }

    public class MaterialInfo : Material
    {
        public string CreaterName { get; set; }
        public string LastEditorName { get; set; }
    }
}
