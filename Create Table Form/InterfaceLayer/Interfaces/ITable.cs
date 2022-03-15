

namespace InterfaceLayer.Interfaces
{
    public interface ITable
    {
        public DTO_s.TableDTO GetTabbleByName(string name);
        public int EditTable(DTO_s.TableDTO tableDTO);
    }
}