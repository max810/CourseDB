using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public class Model
    {
        public MuseumContext DbContext { get; set; }
        public User_profile CurrentUser { get; set; }
    }
}
