using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter {
    class AllLineCounter :ILineCounter{

        #region ILineCounter Members

        public int Lines {
            get;
            set;
        }

        public void OnCodeLine(string line) {
            this.Lines++;
        }

        public void Reset() {
            Lines = 0;
        }
        #endregion
    }
}
