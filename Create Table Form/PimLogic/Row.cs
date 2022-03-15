namespace PimLogic
{
    public class Row
    {
        public string Name { get; set; }
        public string Type { get; set; }

        public Row(string name, string type)
        {
            Name = name;
            Type = type;
        }
        public Row(InterfaceLayer.DTO_s.RowDTO rowDTO)
        {
            Name = rowDTO.Name;
            Type = rowDTO.Type;
        }

        public override string ToString()
        {
            return Name + ("                ".Substring(Name.Length)) + Type;
        }
    }

}