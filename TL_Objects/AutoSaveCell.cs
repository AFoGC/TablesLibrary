using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TL_Objects
{
    [TableCell("Film", true)]
    public class AutoSaveCell : Cell
    {
        [Field("Name")]
        private String name;

        [Field("RealiseYear")]
        private Int32 realiseYear;
        [Field("Watched")]
        private Boolean watched;
        [Field("WatchDate")]
        private DateTime watchDate;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Int32 RealiseYear
        {
            get { return realiseYear; }
            set { realiseYear = value; }
        }

        public Boolean Watched
        {
            get { return watched; }
            set { watched = value; }
        }

        public DateTime WatchDate
        {
            get { return watchDate; }
            set { watchDate = value; }
        }

        protected override void updateThisBody(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
