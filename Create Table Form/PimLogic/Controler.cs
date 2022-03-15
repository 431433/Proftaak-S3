using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.Interfaces;
using InterfaceLayer.DTO_s;
using DataLayer;
namespace PimLogic
{
    public class Controler
    {
        ITable ITable { get; set; }
        public Controler()
        {
            ITable = new TableDAL();
        }

        public Table GetTableByName(string name)
        {
            return new Table(ITable.GetTabbleByName(name));
        }
        public int createTable(Table table)
        {
            TableDTO tableDTO = table.CreateDTO();

            return ITable.CreateTable(tableDTO);
        } 

        public int EditTable(Table table)
        {
            return 0;
        }
    }
}
