using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter {
    class SingleLineCommentFilter:ILineFilter {
        #region ILineFilter Members

        public bool MatchCondition(string line) {
            return line.StartsWith("//");
        }
        #endregion
    }
}
