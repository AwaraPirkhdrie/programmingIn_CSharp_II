using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Animal_Park
{
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)   
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            int result_compare = 0;

            if ((((ListViewItem)x).SubItems.Count > 1) &(((ListViewItem)y).SubItems.Count > 1))
            {
                String sx = ((ListViewItem)x).SubItems[col].Text;
                String sy = ((ListViewItem)y).SubItems[col].Text;
                if ((sx != null) & (sy != null))
                {
                    result_compare = String.Compare(sx, sy);
                }
            }

            return result_compare;
        }
    }
}
