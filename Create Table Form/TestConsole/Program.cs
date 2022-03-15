
using PimLogic;

Controler controler = new Controler();
Console.WriteLine("Welcome");

while (true)
{
    Console.WriteLine("Enter Table Name: ");
    string name = Console.ReadLine();
    if (name != null)
    {
        Table table  = controler.GetTableByName(name);
        foreach(Row row in table.Rows)
        {
            Console.WriteLine(row);
        }
    }
    
}
