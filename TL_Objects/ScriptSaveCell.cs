using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TL_Objects
{
    [Serializable]
    [TableCell("Film")]
    public class ScriptSaveCell : Cell
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

        protected override void saveBody(StreamWriter streamWriter, Cell defaultCell)
        {
            streamWriter.Write(FormatParam("Name", name, "", 2));
            streamWriter.Write(FormatParam("RealiseYear", realiseYear, 0, 2));
            streamWriter.Write(FormatParam("Watched", watched, false, 2));
            streamWriter.Write(FormatParam("WatchDate", watchDate, new DateTime(), 2));
        }

        protected override void loadBody(Comand comand)
        {
            switch (comand.Paramert)
            {
                case "Name":
                    name = comand.Value;
                    break;
                case "RealiseYear":
                    realiseYear = Convert.ToInt32(comand.Value);
                    break;
                case "Watched":
                    watched = Convert.ToBoolean(comand.Value);
                    break;
                case "WatchDate":
                    watchDate = Convert.ToDateTime(comand.Value);
                    break;

                default:
                    break;
            }
        }

        protected override void updateThisBody(Cell cell)
        {
            throw new NotImplementedException();
        }
    }
}
