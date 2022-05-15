using System;
using System.Collections;
using System.IO;
namespace Lab4ex2
{
    class Program
    {
        public static ArrayList ReadFromFile(string path)
        {
            ArrayList list = new ArrayList();
            string line;
            StreamReader reader = File.OpenText(path);

            while ((line = reader.ReadLine()) != null)
            {
                string[] s = line.Split(new string[]
                {
                    "Інвентарний номер: ", ", Назва товару: ", ", Вага(кг): ", ", Ціна(грн): ", ", Кількість: "
                }, 5, StringSplitOptions.RemoveEmptyEntries);
                list.Add(new Storage (int.Parse(s[0]), s[1], int.Parse(s[2]), int.Parse(s[3]), int.Parse(s[4])));
            }
            reader.Close();
            return list;
        }

        //метод для редагування запису

        public static Storage Edit(Storage storage)
        {
            Console.WriteLine("\nЯке поле ви хочете редагувати?\n\n" +
                                               "Інвентарний номер - 1\n" +
                                               "Назва товару - 2\n" +
                                               "Вага(кг)- 3\n" +
                                               "Ціна(грн) - 4\n" +
                                               "Кількість - 5\n" +
                                               "Вийти - 6");
            Console.Write("\nВаш вибiр: ");
            int localNum = int.Parse(Console.ReadLine());
            Console.Write("\n");
            Console.Write("Введiть нове значення: ");
            switch (localNum)
            {
                case 1:
                    int inventorynum = int.Parse(Console.ReadLine()); 
                    if (inventorynum < 0 )
                    {
                        Console.Write("\nІнвентарний номер не може бути менше 0\n"); break;
                    }
                    else
                    {
                        storage.Inventorynum = inventorynum; break;
                    }
                case 2:
                                       
                        storage.Nameprod = Console.ReadLine(); break;
                    
                case 3:
                    int weightchange = int.Parse(Console.ReadLine());
                    if (weightchange < 0 || weightchange > 500)
                    {
                        Console.Write("\nВага товару не має перевищувати 500кг\n"); break;
                    }
                    else
                    {
                        storage.Weight = weightchange; break;
                    }
                case 4:
                    int pricechange = int.Parse(Console.ReadLine());
                    if (pricechange < 0 || pricechange > 1000000)
                    {
                        Console.Write("\nЦіна на товар не має бути більшою чим семи значне число\n"); break;
                    }
                    else
                    {
                        storage.Price = pricechange; break;
                    }
                case 5:
                    int amountchange = int.Parse(Console.ReadLine());
                    if (amountchange < 0 || amountchange > 100)
                    {
                        Console.Write("\nМаксимальна кількість одного товару на складі 100шт\n"); break;
                    }
                    else
                    {
                        storage.Amount = amountchange; break;
                    }
                case 6: break;
            }
            return storage;
        }
        public static void Write(string path, ArrayList storages)
        {
            StreamWriter streamWriter;
            streamWriter = File.CreateText(path);
            foreach (Storage n in storages)
            {
                streamWriter.WriteLine(n);
            }
            streamWriter.Close();
        }

        static void Main(string[] args)
        {

            Console.OutputEncoding = System.Text.Encoding.Default;

            string path = @"D:\\123\database.txt";
        

            ArrayList storages = new ArrayList(new Storage[] { });
            while (true)
            {
                
                Console.WriteLine("\n\tМеню\n\n" +
                                  "Додати запис - 1\n" +
                                  "Редагувати запис - 2\n" +
                                  "Видалити запис - 3\n" +
                                  "Вивести усi записи - 4\n" +
                                  "Пошук за Назвою товара - 5\n" +
                                  "Вийти - 6");
                try
                {
                    bool breakFlag = false;
                    int a;
                    Console.Write("\nВаш вибiр: ");
                    int choice = int.Parse(Console.ReadLine());
                    Console.Write("\n");
                    switch (choice)
                    {
                        //Додавання запису

                        case 1:
                            Console.Write("Інвентарний номер: ");
                            int inventorynum = int.Parse(Console.ReadLine());
                            Console.Write("Назва товару: ");
                            string nameprod = Console.ReadLine();
                            Console.Write("Вага(кг): ");
                            int weight = int.Parse(Console.ReadLine());
                            if (weight < 0 || weight > 500)
                            {
                                Console.Write("\nВага товару не має перевищувати 500кг\n"); break;
                            }
                            Console.Write("Ціна(грн): ");
                            int price = int.Parse(Console.ReadLine());
                            if (price < 0 || price > 1000000)
                            {
                                Console.Write("\nЦіна на товар не має бути більшою чим семи значне число\n"); break;
                            }
                            Console.Write("Кількість: ");
                            int amount = int.Parse(Console.ReadLine());
                            if (amount < 0 || amount > 100)
                            {
                                Console.Write("\nМаксимальна кількість одного товару на складі 100шт\n"); break;
                            }
                            storages = ReadFromFile(path);
                            Storage storage = new Storage(inventorynum, nameprod, weight, price, amount);
                            storages.Add(storage);
                            Write(path, storages);
                            break;

                        //Вибір запису для редагування 

                        case 2:
                           storages = ReadFromFile(path);
                            Console.WriteLine("Який запис хочете редагувати?\n");
                            a = 1;
                            storages.Sort();
                            for (int i = 0; i < storages.Count; i++)
                            {
                                a++;
                                Storage n = (Storage)storages[i];
                                Console.WriteLine($"{i + 1} - Інвентарний номер: {n.Inventorynum}," +
                                    $" Назва товару: {n.Nameprod}," +
                                    $" Вага(кг): {n.Weight}," +
                                    $" Ціна(грн): {n.Price}," +
                                    $" Кількість: {n.Amount}");
                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int editChoice = int.Parse(Console.ReadLine());
                            if (editChoice == a)
                                break;
                            storages[editChoice - 1] = Edit((Storage)storages[editChoice - 1]);
                            Write(path, storages);
                            break;

                        //Видалення запису

                        case 3:
                            Console.WriteLine("Виберiть запис який хочете видалити\n");
                            a = 1;
                            storages = ReadFromFile(path);
                            storages.Sort();
                            for (int i = 0; i < storages.Count; i++)
                            {
                                a++;
                                Storage n = (Storage)storages[i];
                                Console.WriteLine($"{i + 1} - Інвентарний номер: {n.Inventorynum}," +
                                    $" Назва товару: {n.Nameprod}," +
                                    $" Вага(кг): {n.Weight}," +
                                    $" Ціна(грн): {n.Price}," +
                                    $" Кількість: {n.Amount}");

                            }
                            Console.WriteLine($"{a} - Вийти");
                            Console.Write("\nВаш вибiр: ");
                            int deleteChoice = int.Parse(Console.ReadLine());
                            Console.Write("\n");
                            if (deleteChoice == a)
                                break;
                            storages.Remove(storages[deleteChoice - 1]);
                            Write(path, storages);
                            break;

                        //Виведення усіх записів

                        case 4:
                            storages = ReadFromFile(path);
                            storages.Sort();
                            foreach (Storage n in storages)
                            {
                                Console.WriteLine($"Інвентарний номер: {n.Inventorynum}," +
                                    $" Назва товару: {n.Nameprod}," +
                                    $" Вага(кг): {n.Weight}," +
                                    $" Ціна(грн): {n.Price}," +
                                    $" Кількість: {n.Amount}");
                            }
                            Console.WriteLine("\n");
                            break;

                        //Знаходження за назвою товару

                        case 5:
                            int count = 0;
                            storages = ReadFromFile(path);
                            Console.Write("Введіть назву продукта: ");
                            int nameprodnum = int.Parse(Console.ReadLine());
                                Console.Write("\n");
                                
                            foreach (Storage n in storages)
                            {
                                if (n.Nameprod.Equals(nameprodnum))
                                {
                                    Console.WriteLine(n);
                                    count++;
                                    
                                }
                               
                            }
                            if (count == 0)
                            {
                                    Console.Write("Данних про такий товар не існує \n");
                                  
                                }
                            
                            break;
                        case 6:
                            breakFlag = true;
                            break;
                        default:
                            continue;
                    }
                    if (breakFlag)
                        break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nВводити можна тiльки числа!\n");
                }
            }
        }
    }
}