using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieClassLibrary.Exceptions
{
    public class MovieErrorStore:Exception
    {
        public MovieErrorStore(string message):base(message) { }
    }
}
