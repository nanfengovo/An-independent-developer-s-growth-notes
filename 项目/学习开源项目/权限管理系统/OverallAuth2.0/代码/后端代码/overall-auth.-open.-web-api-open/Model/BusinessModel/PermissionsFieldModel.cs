using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusinessModel
{
   public class PermissionsFieldModel
    {
        public string CurrentUser { get; set; }

        public string CurrentRole { get; set; }

        public string CurrentDepartment { get; set; }
    }
}
