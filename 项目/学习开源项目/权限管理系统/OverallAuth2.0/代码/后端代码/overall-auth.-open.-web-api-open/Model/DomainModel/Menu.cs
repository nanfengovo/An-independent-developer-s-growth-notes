using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Model
{
    public class Menu
    {
        public int Id { get; set; }

        public string MenuUrl { get; set; }

        public string MenuIcon { get; set; }

        public string MenuTitle { get; set; }

        public int Pid { get; set; }

        public bool IsOpen { get; set; }

        public DateTime CreateTime { get; set; }

        public string CreateUser { get; set; }

        public string Component { get; set; }

        public string Path { get; set; }

        public bool RequireAuth { get; set; }

        public string Name { get; set; }

        public string Redirect { get; set; }
    }
}
