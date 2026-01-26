using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Computer com = new Computer();
            //Внесение значений
            com.invNumPub = 123345;
            com.CPUhzPub = 1.5f;
            com.HDDstoragePub = 400;
            com.storageCostPub = 100;
            //Вызов методов
            com.Show();
            Console.WriteLine($"{com.HDDstoragePub}Гб стоит {com.storageValue()}");
        }
    }

    class Computer
    {
        //Переменные
        private int invNum;
        private float CPUhz;
        private float HDDstorage;
        private float storageCost;
        

        //Доступ к полю
        public int invNumPub
        {
            get { return invNum; }
            set { invNum = value; }
        }
            
        public float CPUhzPub
        {
            get { return CPUhz; }
            set { CPUhz = value; }
        }

        public float HDDstoragePub
        {
            get { return HDDstorage; }
            set { HDDstorage = value; }
        }

        public float storageCostPub
        {
            get { return storageCost; }
            set { storageCost = value; }
        }

        //Кострукторы
        public Computer()
        {
            invNumPub = 0;
            CPUhzPub = 0;
            HDDstoragePub = 0;
            storageCostPub = 0;
        }

        public Computer(int a, float b, float c, float d)
        {
            invNum = a;
            CPUhz = b;
            HDDstorage = c;
            storageCost = d;
        }

        //Методы
        public void Show()
        {
            Console.WriteLine($"Инвентарный номер: {invNumPub}\n" +
                              $"Частота процессора: {CPUhzPub}\n" +
                              $"Объем жестко диска: {HDDstoragePub}");
            return;
        }

        public float storageValue()
        {
            float value = HDDstorage * storageCost;
            return value;
        }
    }
}
