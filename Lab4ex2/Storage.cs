using System;

namespace Lab4ex2
{
    public class Storage : IComparable
    {

        private int inventorynum;
        private string nameprod;
        private int weight;
        private int price;
        private int amount;

        public override string ToString()
        {
            return $"Інвентарний номер: {inventorynum}," +
                $" Назва товару: {nameprod}," +
                $" Вага(кг): {weight}," +
                $" Ціна(грн): {price}," +
                $" Кількість: {amount}";

        }

        public int CompareTo(object? obj)
        {
            Storage other = (Storage)obj;
            return Inventorynum.CompareTo(other.Inventorynum);
        }


         public Storage()
        {
        }

        public Storage(int inventorynum, string nameprod,  int weight, int price, int amount)
        {
            Inventorynum = inventorynum;
            Nameprod = nameprod;
            Weight = weight;
            Price = price;
            Amount = amount;
        }

        public int Inventorynum
        {
            get => inventorynum;
            set => inventorynum = value;
        }

        public string Nameprod
    {
            get => nameprod;
            set => nameprod = value;
        }

        public int Weight
        {
            get => weight;
            set => weight = value;
        }

        public int Price
    {
            get => price;
            set => price = value;
        }

        public int Amount
    {
            get => amount;
            set => amount = value;
        }
    }
}
