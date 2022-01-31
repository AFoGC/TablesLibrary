using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TablesLibrary.Interpreter.TableCell;

namespace TL_Objects
{
    [TableCell("Film", true)]
    public class Film : Cell
    {
        [Field("Name")]
        private String name;

        private Genre genre;

        [Field("GenreId")]
        private Int32 genreId;

        [Field("RealiseYear")]
        private Int32 realiseYear;
        [Field("Wathced")]
        private Boolean wathced;
        [Field("WatchDate")]
        private DateTime watchDate;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public Genre Genre
        {
            get { return genre; }
            set { genre = value; genreId = genre.ID; }
        }

        public Int32 GenreId
        {
            get { return genreId; }
        }

        public Int32 RealiseYear
        {
            get { return realiseYear; }
            set { realiseYear = value; }
        }

        public Boolean Watched
        {
            get { return wathced; }
            set { wathced = value; }
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
