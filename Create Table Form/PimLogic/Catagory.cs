using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PimLogic
{
    public class Catagory
    {
        public string Name { get; set; }
        public List<Table> Tables { get; set; }

        public Catagory(string name)
        {
            Name = name;
            Tables = new List<Table>();
        }

        public int AddTable(Table table)
        {
            foreach(Table table1 in Tables)
            {
                if(table1.Name == table.Name)
                {
                    return 0;
                }
            }
            Tables.Add(table);
            return 1;
        }
    }
}
