using ASPproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ASPproject.Services
{
    public interface IFillList
    {
        IEnumerable<Words> GetAllWords();
    }
}
