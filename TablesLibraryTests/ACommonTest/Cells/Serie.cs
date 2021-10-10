using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Attributes;

namespace TablesLibraryTests.ACommonTest.Cells
{
    [TableCell("Serie", true)]
    public class Serie : Cell
    {
        [Field("filmId")]
        private int filmId = 0;
        [Field("startWatchDate")]
        private DateTime startWatchDate = new DateTime();
        [Field("countOfWatchedSeries")]
        private int countOfWatchedSeries = 0;
        [Field("totalSeries")]
        private int totalSeries = 0;

        public Serie() : base() { }
        public Serie(int id) : base(id) { }

        protected override void updateThisBody(Cell cell)
        {
            Serie serie = (Serie)cell;

            filmId = serie.filmId;
            startWatchDate = serie.startWatchDate;
            countOfWatchedSeries = serie.countOfWatchedSeries;
            totalSeries = serie.totalSeries;
        }

        protected override void saveBody(StreamWriter streamWriter)
        {
            streamWriter.Write(FormatParam(nameof(filmId), filmId, 0, 2));
            streamWriter.Write(FormatParam(nameof(startWatchDate), startWatchDate, new DateTime(), 2));
            streamWriter.Write(FormatParam(nameof(countOfWatchedSeries), countOfWatchedSeries, 0, 2));
            streamWriter.Write(FormatParam(nameof(totalSeries), totalSeries, 0, 2));
        }

        protected override void loadBody(Comand comand)
        {
            switch (comand.Paramert)
            {
                case "filmId":
                    filmId = Convert.ToInt32(comand.Value);
                    break;
                case "startWatchDate":
                    startWatchDate = readDate(comand.Value);
                    break;
                case "countOfWatchedSeries":
                    countOfWatchedSeries = Convert.ToInt32(comand.Value);
                    break;
                case "totalSeries":
                    totalSeries = Convert.ToInt32(comand.Value);
                    break;

                default:
                    break;
            }
        }

        public int FilmId
        {
            get { return filmId; }
            set { filmId = value; }
        }

        public DateTime StartWatchDate
        {
            get { return startWatchDate; }
            set { startWatchDate = value; }
        }

        public int CountOfWatchedSeries
        {
            get { return countOfWatchedSeries; }
            set { countOfWatchedSeries = value; }
        }

        public int TotalSeries
        {
            get { return totalSeries; }
            set { totalSeries = value; }
        }
    }
}
