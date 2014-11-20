using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter {
    interface ILineCounter {
        int Lines { get; set; }
        void OnCodeLine(string line);
        void Reset();
    }
    interface ILineFilter {
        bool MatchCondition(string line);
    }
}
