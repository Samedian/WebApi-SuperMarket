using System;
using System.Data.SqlClient;

namespace Exceptions
{
    public class DataNotFound : Exception
    {
        public DataNotFound(string  message) :base(message)
        {

        }
    }
}
