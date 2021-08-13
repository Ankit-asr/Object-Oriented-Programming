using ObjectOrientedProgramming.InventoryManagement;
using System;

namespace ObjectOrientedProgramming
{
    class Program
    {
        const string INVENTORY_JSON = @"F:\JSON\ObjectOrientedProgramming\InventoryManagement\Inventory.json";
        static void Main(string[] args)
        {
            InventoryMain inventoryMain = new InventoryMain();
            inventoryMain.DisplayData(INVENTORY_JSON);
        }
    }
}