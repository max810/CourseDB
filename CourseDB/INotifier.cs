using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseDB
{
    public interface INotifier
    {
        event MessageSentEventHandler MessageSent;
        string Title { get; set; }
    }
}
