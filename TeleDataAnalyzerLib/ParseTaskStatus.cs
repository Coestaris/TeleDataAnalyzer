using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeleDataAnalyzerLib
{
    public enum ParseTaskStatus
    {
        Running,
        Failed,
        Ok,
        Waiting,
        Aborted
    }
}
