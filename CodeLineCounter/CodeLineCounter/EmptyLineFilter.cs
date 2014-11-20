using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter {
    class EmptyLineFilter:ILineFilter {
        #region ILineFilter Members

        public bool MatchCondition(string line) {
            if (line == null || line.Length == 0) {
                return true;
            }
            else {
                return false;
            }
        }

        #endregion
    }
}
