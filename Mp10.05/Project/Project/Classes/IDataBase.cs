using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Classes
{
    public interface IDataBase
    {
        void add(Information information);
        void addAll(ICollection<Information> collection);
    }
}
