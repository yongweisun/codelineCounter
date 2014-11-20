using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLineCounter {
    class CombineCounter {
        public CombineCounter() {

            counters.Add(all);
            counters.Add(empty);
            counters.Add(braceCounter);
            counters.Add(usingCounter);
            counters.Add(singleLineCommentCounter);
        }
        #region ILineCounter Members
        List<ILineCounter> counters = new List<ILineCounter>();

        AllLineCounter all = new AllLineCounter();
        FilterCounter empty = new FilterCounter() { Filter = new EmptyLineFilter() };
        FilterCounter braceCounter = new FilterCounter() { Filter = new BracesFilter() };
        FilterCounter usingCounter = new FilterCounter { Filter = new UsingImportFilter() };
        FilterCounter singleLineCommentCounter = new FilterCounter { Filter = new SingleLineCommentFilter() };
        public void OnCodeLine(string line) {
            foreach (var counter in counters) {
                counter.OnCodeLine(line);
            }

        }
        public int AllLines {
            get {
                return all.Lines;
            }
        }
        public int EmptyLines {
            get {
                return empty.Lines;
            }
        }
        public int BraceLines {
            get {
                return braceCounter.Lines;
            }
        }
        public int UsingLines {
            get {
                return usingCounter.Lines;
            }
        }
        public int SingleLineComentLines {
            get {
                return singleLineCommentCounter.Lines;
            }
        }
        public int NormalLines {
            get {
                return all.Lines - empty.Lines - braceCounter.Lines - usingCounter.Lines - singleLineCommentCounter.Lines;
            }
        }
        //public void Reset() {
        //    this.Lines = 0;
        //}

        #endregion

        #region ILineCounter Members



        #endregion
    }
}
