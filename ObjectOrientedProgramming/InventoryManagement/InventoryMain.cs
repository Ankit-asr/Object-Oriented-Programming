using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgramming.InventoryManagement
{
    public class InventoryMain
    {
        string checkInventoryName;
        const int ADD_RICE = 1, ADD_PULSES = 2, ADD_WHEAT = 3;
 
        public void DisplayItem(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    InventoryFactory jsonObectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                    Console.WriteLine("Name\tWeight\tPricePerKg");
                    List<Rice> rice = jsonObectArray.RiceList;
                    foreach (var item in rice)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                    List<Pulses> pulses = jsonObectArray.PulsesList;
                    foreach (var item in pulses)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                    List<Wheat> wheat = jsonObectArray.WheatList;
                    foreach (var item in wheat)
                    {
                        Console.WriteLine(item.Name + "\t" + item.Weight + "\t" + item.PricePerKg);
                    }
                }
                else
                {
                    Console.WriteLine("Item not found");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
        public void EditItem(string filepath)
        {
            bool checkRecord = false;
            if (File.Exists(filepath))
            {
                string jsonData = File.ReadAllText(filepath);
                InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);

                Console.WriteLine("Press 1 to Edit  Rice List");
                Console.WriteLine("Press 2 to Edit  Pulses List");
                Console.WriteLine("Press 3 to Edit  Wheat List");
                Console.WriteLine("Enter your choice");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case ADD_RICE:
                        List<Rice> riceList = jsonObjectArray.RiceList;
                        Console.WriteLine("Enter the Item to Edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Rice ricename in riceList)
                        {
                            if (ricename.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Item");
                                ricename.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                ricename.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter PricePerKg");
                                ricename.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord)
                            Console.WriteLine("Item Updated");
                        else
                            Console.WriteLine("Item not found ");
                        break;
                    case ADD_PULSES:
                        List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                        Console.WriteLine("Enter Item to Edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Pulses pulsesName in pulsesList)
                        {
                            if (pulsesName.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Item");
                                pulsesName.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                pulsesName.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Price Per Kg");
                                pulsesName.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord)
                            Console.WriteLine("Item Updated");
                        else
                            Console.WriteLine("Item not found");
                        break;
                    case ADD_WHEAT:
                        List<Wheat> wheatList = jsonObjectArray.WheatList;
                        Console.WriteLine("Enter Item to Edit");
                        checkInventoryName = Console.ReadLine();
                        foreach (Wheat wheatName in wheatList)
                        {
                            if (wheatName.Name.Equals(checkInventoryName))
                            {
                                Console.WriteLine("Enter Item");
                                wheatName.Name = Console.ReadLine();
                                Console.WriteLine("Enter Weight");
                                wheatName.Weight = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter Price Per Kg");
                                wheatName.PricePerKg = Convert.ToInt32(Console.ReadLine());
                                checkRecord = true;
                            }
                        }
                        if (checkRecord == true)
                        {
                            string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                            File.WriteAllText(filepath, writeDataToFile);
                            Console.WriteLine("Item Updated");
                        }
                        else
                            Console.WriteLine("Item not found");
                        break;
                    default:
                        Console.WriteLine("Enter a right choice");
                        break;
                }
            }
        }
       
        public void DeleteItem(string filepath)
        {
            bool checkRecord = true;
            if (File.Exists(filepath))
            {
                string jsonData = File.ReadAllText(filepath);
                InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                Console.WriteLine("Enter Item to Delete");
                checkInventoryName = Console.ReadLine();
                List<Rice> riceList = jsonObjectArray.RiceList;
                foreach (Rice ricename in riceList)
                {
                    if (ricename.Name.Equals(checkInventoryName))
                    {
                        riceList.Remove(ricename);
                        checkRecord = false;
                        break;
                    }
                }
                if (checkRecord)
                {
                    List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                    foreach (Pulses pulsesName in pulsesList)
                    {
                        if (pulsesName.Name.Equals(checkInventoryName))
                        {
                            pulsesList.Remove(pulsesName);
                            checkRecord = false;
                            break;
                        }
                    }
                }
                if (checkRecord)
                {
                    List<Wheat> wheatList = jsonObjectArray.WheatList;
                    foreach (Wheat wheatName in wheatList)
                    {
                        if (wheatName.Name.Equals(checkInventoryName))
                        {
                            wheatList.Remove(wheatName);
                            checkRecord = false;
                            break;
                        }
                    }
                }
                if (checkRecord == false)
                {
                    string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                    File.WriteAllText(filepath, writeDataToFile);
                    Console.WriteLine("Item Deleted");
                }
                else
                    Console.WriteLine("Item not found");
            }
            else
            {
                Console.WriteLine("Item not found");
            }
        }
      
        public void AddItem(string filepath)
        {
            try
            {
                if (File.Exists(filepath))
                {
                    string jsonData = File.ReadAllText(filepath);
                    InventoryFactory jsonObjectArray = JsonConvert.DeserializeObject<InventoryFactory>(jsonData);
                    Console.WriteLine("Press 1 to Add Rice List");
                    Console.WriteLine("Press 2 to Add Pulses List");
                    Console.WriteLine("Press 3 to Add Wheat List");
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case ADD_RICE:
                            List<Rice> riceList = jsonObjectArray.RiceList;
                            Rice rice = new Rice();
                            Console.WriteLine("Enter Item");
                            rice.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            rice.Weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Price Per Kg");
                            rice.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            riceList.Add(rice);
                            Console.WriteLine("Item added");
                            break;
                        case ADD_PULSES:
                            List<Pulses> pulsesList = jsonObjectArray.PulsesList;
                            Pulses pulses = new Pulses();
                            Console.WriteLine("Enter Item");
                            pulses.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            pulses.Weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter Price Per Kg");
                            pulses.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            pulsesList.Add(pulses);
                            Console.WriteLine("Item added");
                            break;
                        case ADD_WHEAT:
                            List<Wheat> wheatList = jsonObjectArray.WheatList;
                            Wheat wheat = new Wheat();
                            Console.WriteLine("Enter Item");
                            wheat.Name = Console.ReadLine();
                            Console.WriteLine("Enter Weight");
                            wheat.Weight = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter PricePerKg");
                            wheat.PricePerKg = Convert.ToInt32(Console.ReadLine());
                            wheatList.Add(wheat);
                            Console.WriteLine("Item added");
                            break;
                        default:
                            Console.WriteLine("Enter a right choice");
                            break;
                    }
                    string writeDataToFile = JsonConvert.SerializeObject(jsonObjectArray);
                    File.WriteAllText(filepath, writeDataToFile);
                }
                else
                    Console.WriteLine("Item does not exist");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}