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
	[TableCell("Genre")]
	public class Serie : Cell
    {
		private int filmId = 0;
		private DateTime startWatchDate = new DateTime();
		private int countOfWatchedSeries = 0;
		private int totalSeries = 0;

		public Serie() : base() { }
		public Serie(int id) : base(id) { }

		protected override void updateThisBody(Cell cell)
		{
			Serie serie = (Serie)cell;

			this.filmId = serie.filmId;
			this.startWatchDate = serie.startWatchDate;
			this.countOfWatchedSeries = serie.countOfWatchedSeries;
			this.totalSeries = serie.totalSeries;
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
					this.filmId = Convert.ToInt32(comand.Value);
					break;
				case "startWatchDate":
					this.startWatchDate = readDate(comand.Value);
					break;
				case "countOfWatchedSeries":
					this.countOfWatchedSeries = Convert.ToInt32(comand.Value);
					break;
				case "totalSeries":
					this.totalSeries = Convert.ToInt32(comand.Value);
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
