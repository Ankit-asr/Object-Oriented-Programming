using ObjectOrientedProgramming.InventoryManagement;
using System;

namespace ObjectOrientedProgramming
{
    class Program
    {
        const String INVENTORY_JSON = @"F:\JSON\ObjectOrientedProgramming\InventoryManagement\Inventory.json";

        static void Main(string[] args)
        {
            const int ADD_RECORD = 1, EDIT_RECORD = 2, DELETE_RECORD = 3, SHOW_ALL_RECORDS = 4;
            int userChoice;
            InventoryMain inventoryMain = new InventoryMain();
            while (true)
            {
                Console.WriteLine("Press 1 to Add New Item");
                Console.WriteLine("Press 2 to Edit Item");
                Console.WriteLine("Press 3 to Delete Item");
                Console.WriteLine("Press 4 to Dispaly All Items");
                Console.WriteLine("Enter your choice");
                userChoice = Convert.ToInt16(Console.ReadLine());
                switch (userChoice)
                {
                    case ADD_RECORD:
                        inventoryMain.AddItem(INVENTORY_JSON);
                        break;
                    case EDIT_RECORD:
                        inventoryMain.EditItem(INVENTORY_JSON);
                        break;
                    case DELETE_RECORD:
                        inventoryMain.DeleteItem(INVENTORY_JSON);
                        break;
                    case SHOW_ALL_RECORDS:
                        inventoryMain.DisplayItem(INVENTORY_JSON);
                        break;
                    default:
                        Console.WriteLine("Enter right choice");
                        break;
                }
                Console.WriteLine("Enter 1 to Continue 2 to Exit");
                int control = Convert.ToInt32(Console.ReadLine());
                if (control == 2)
                    break;
            }
        }
    }
}