using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceLayer.DTO_s
{
    public struct CatagoryDTO
    {
        public int Id;
        public string Name;
        public List<TableDTO> Tables;
    }
}
