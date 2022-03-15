using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterfaceLayer.DTO_s;
using InterfaceLayer.Interfaces;

namespace PimLogic
{
    public class Table
    {
        public string Name { get; set; }
        public List<Row> Rows { get; set; }
        private ITable Itable;

        public Table(string name)
        {
            Name = name;
            Rows = new List<Row>();
            Itable = new DataLayer.TableDAL();
        }
        public Table(TableDTO tableDTO)
        {
            Name= tableDTO.Name;
            Rows = new List<Row>();
            Itable = new DataLayer.TableDAL();
            foreach (RowDTO row in tableDTO.Rows)
            {
                Rows.Add(new Row(row));
            }
        }
        public int AddToCatagory(int productid, string name)
        {
            return Itable.AddToCatagory(productid, name);
        }

        public TableDTO CreateDTO()
        {
            TableDTO tableDTO = new TableDTO();
            tableDTO.Name = Name;
            tableDTO.Rows = new List<RowDTO>();
            foreach(Row row in Rows)
            {
                tableDTO.Rows.Add(new RowDTO() { Name = row.Name , Type = row.Type});
            }
            return tableDTO;
        }

        public int AddRow(Row row)
        {
            foreach(Row row1 in Rows)
            {
                if(row1.Name == row.Name)
                {
                    return 0;
                }
            }
            Rows.Add(row);
            return 1;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
