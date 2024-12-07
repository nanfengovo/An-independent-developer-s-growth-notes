using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class MenuDao
    {
        public int MenuKey { get; set; }

        public string Id { get; set; }

        public string Icon { get; set; }

        public int PMenuKey { get; set; }
        public string Component { get; set; }

        public string Path { get; set; }

        public string Title { get; set; }

        public bool RequireAuth { get; set; }

        public string Name { get; set; }

        public string Redirect { get; set; }

        public bool IsOpen { get; set; }

        public List<MenuDao> children { get; set; }
    }
}
