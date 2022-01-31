using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TL_Objects
{
    [TableCell("Film")]
    public class StaticScriptSaveCell : Cell
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
            streamWriter.Write(FormatParam(nameName, name, nameDefVal, 2));
            streamWriter.Write(FormatParam(realiseYearName, realiseYear, realiseYearDefVal, 2));
            streamWriter.Write(FormatParam(watchedName, watched, watchedDefVal, 2));
            streamWriter.Write(FormatParam(watchDateName, watchDate, watchDateDefVal, 2));
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

        static StaticScriptSaveCell()
        {
            nameName = "Name";
            realiseYearName = "RealiseYear";
            watchedName = "Watched";
            watchDateName = "WatchDate";

            nameDefVal = "";
            realiseYearDefVal = 0;
            watchedDefVal = false;
            watchDateDefVal = new DateTime();
        }

        private static readonly string nameName;
        private static readonly string realiseYearName;
        private static readonly string watchedName;
        private static readonly string watchDateName;

        private static readonly string nameDefVal;
        private static readonly int realiseYearDefVal;
        private static readonly bool watchedDefVal;
        private static readonly DateTime watchDateDefVal;
    }
}
