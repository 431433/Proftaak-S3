
using PimLogic;

Controler controler = new Controler();
Console.WriteLine("Welcome");
bool on = true;
while (on)
{
    Console.WriteLine("Choose action \n [1] Create Table\n [2] Read Table\n [0] Close");
    string selection = Console.ReadLine();
    try
    {
        int option = Convert.ToInt32(selection);
        switch (option)
        {
            case 0:
                on = false;
                break;
            case 1:
                Console.WriteLine("Enter Table name:");
                string tablename = Console.ReadLine();
                Table table = new Table(tablename);
                while (true)
                {
                    Console.WriteLine("enter prop name");
                    string propname = Console.ReadLine();
                    Console.WriteLine("enter prop type");
                    string proptype = Console.ReadLine();
                    if(proptype != null && propname != null)
                    {
                        table.AddRow(new Row(propname, proptype));
                    }
                    Console.WriteLine("\n Enter another row [y/n]");
                    string answer = Console.ReadLine();
                    while (answer != "y" && answer != "n")
                    {
                        answer = Console.ReadLine();
                    }
                    if (answer == "n")
                    {
                        CreateTable(table);
                        break;
                    }
                }
                break;
            case 2:
                Console.WriteLine("Enter Table name:");
                string name = Console.ReadLine();
                if(name!= null) ReadTable(name);
                break;
        }
    }
    catch
    {
        Console.WriteLine("Enter a number");
    }
    
    
}

void ReadTable(string name)
{
    if (name != null)
    {
        Console.WriteLine("");
        Table table = controler.GetTableByName(name);
        foreach (Row row in table.Rows)
        {
            Console.WriteLine(row);
        }
        Console.WriteLine("");
    }
}

void CreateTable(Table table)
{
    controler.createTable(table);
}
