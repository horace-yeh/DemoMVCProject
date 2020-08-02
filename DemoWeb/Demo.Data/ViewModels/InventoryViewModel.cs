using Demo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Data.ViewModels
{
    public class InventoryViewModel
    {
        public List<InventoryInfo> ListData { get; set; }
    }

    public class InventoryInfo : Inventory
    {
        public string CreaterName { get; set; }
        public string LastEditorName { get; set; }
        public string MaterialName { get; set; }
        public string MaterialNo { get; set; }
    }
}
