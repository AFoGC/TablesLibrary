using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter;
using TablesLibrary.Interpreter.Attributes;
using TablesLibraryTests.ACommonTest.Cells.CellDataClasses;

namespace TablesLibraryTests.ACommonTest.Cells
{
	[TableCell("Film")]
	public class Film : Cell
	{
		private String name = "";
		private Genre genre = null;
		private int realiseYear = 0;
		private bool watched = false;
		private sbyte mark = -1;
		private DateTime dateOfWatch = new DateTime();

		private String comment = "";
		private List<Source> sources = new List<Source>();

		private int countOfviews = 0;
		private int franshiseId = 0;
		private sbyte franshiseListIndex = -1;


		public Film() : base() { }
		public Film(int id) : base(id) { }

		protected override void updateThisBody(Cell cell)
		{
			Film film = (Film)cell;

			this.name = film.name;
			this.genre = film.genre;
			this.realiseYear = film.realiseYear;
			this.watched = film.watched;
			this.mark = film.mark;
			this.dateOfWatch = film.dateOfWatch;
			this.comment = film.comment;
			this.sources = film.sources;
			this.countOfviews = film.countOfviews;
			this.franshiseId = film.franshiseId;
			this.franshiseListIndex = film.franshiseListIndex;
		}

		protected override void saveBody(StreamWriter streamWriter)
		{
			streamWriter.Write(FormatParam(nameof(name), name, "", 2));
			streamWriter.Write(FormatParam(nameof(genre), genre.ID, 0, 2));
			streamWriter.Write(FormatParam(nameof(realiseYear), realiseYear, 0, 2));
			streamWriter.Write(FormatParam(nameof(watched), watched, false, 2));
			streamWriter.Write(FormatParam(nameof(mark), mark, -1, 2));
			streamWriter.Write(FormatParam(nameof(dateOfWatch), dateOfWatch, new DateTime(), 2));
			streamWriter.Write(FormatParam(nameof(comment), comment, "", 2));

			foreach (Source source in sources)
			{
				streamWriter.Write(formatParam(nameof(source.sourceUrl), source, 2));
			}

			streamWriter.Write(FormatParam(nameof(countOfviews), countOfviews, 0, 2));
			streamWriter.Write(FormatParam(nameof(franshiseId), franshiseId, 0, 2));
			streamWriter.Write(FormatParam(nameof(franshiseListIndex), franshiseListIndex, -1, 2));
		}

		protected override void loadBody(Comand comand)
		{
			switch (comand.Paramert)
			{
				case "name":
					this.name = comand.Value;
					break;
				case "genre":
					//this.genre = MainInfo.Tables.GenresTable.GetElementByIndex(Convert.ToInt32(comand.Value));
					//this.genre = MainInfo.TableCollection.GetTable<Genre>().GetElementByIndex(Convert.ToInt32(comand.Value));
					this.genre = MainInfo.Tables.GenresTable.GetElementByIndex(Convert.ToInt32(comand.Value));
					break;
				case "realiseYear":
					this.realiseYear = Convert.ToInt32(comand.Value);
					break;
				case "watched":
					this.watched = Convert.ToBoolean(comand.Value);
					break;
				case "mark":
					this.mark = Convert.ToSByte(comand.Value);
					break;
				case "dateOfWatch":
					this.dateOfWatch = readDate(comand.Value);
					break;
				case "comment":
					this.comment = comand.Value;
					break;
				case "sourceUrl":
					this.sources.Add(Source.ToSource(comand.Value));
					break;
				case "countOfviews":
					this.countOfviews = Convert.ToInt32(comand.Value);
					break;
				case "franshiseId":
					this.franshiseId = Convert.ToInt32(comand.Value);
					break;
				case "franshiseListIndex":
					this.franshiseListIndex = Convert.ToSByte(comand.Value);
					break;

				default:
					break;
			}
		}

		private String formatParam(String variableName, Source item, int countOfTabulations)
		{
			if (item.sourceUrl != "")
			{
				String export = "";
				for (int i = 0; i < countOfTabulations; i++)
				{
					export = export + "\t";
				}
				return export + "<" + variableName + ": " + item.ToString() + ">\n";
			}
			return "";
		}

		public String Name
		{
			get { return name; }
			set { name = value; }
		}

		public Genre Genre
		{
			get
			{
				if (genre != null)
				{
					return genre;
				}
				else
				{
					return new Genre(0);
				}
			}
			set { genre = value; }
		}

		public int RealiseYear
		{
			get { return realiseYear; }
			set { realiseYear = value; }
		}

		public bool Watched
		{
			get { return watched; }
			set { watched = value; }
		}

		public sbyte Mark
		{
			get { return mark; }
			set { mark = value; }
		}

		public DateTime DateOfWatch
		{
			get { return dateOfWatch; }
			set { dateOfWatch = value; }
		}

		public String Comment
		{
			get { return comment; }
			set { comment = value; }
		}

		public List<Source> Sources
		{
			get { return sources; }
			set { sources = value; }
		}

		public int CountOfViews
		{
			get { return countOfviews; }
			set { countOfviews = value; }
		}

		public int FranshiseId
		{
			get { return franshiseId; }
			set { franshiseId = value; }
		}

		public sbyte FranshiseListIndex
		{
			get { return franshiseListIndex; }
			set { franshiseListIndex = value; }
		}
	}
}
