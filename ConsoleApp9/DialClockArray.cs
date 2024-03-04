using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class DialClockArray
    {
        static Random rnd = new Random();
        public DialClock[] dialClocks;

        // получени размера
        public int Length { get => dialClocks.Length; }

        // конструктор с параметром(рандом)
        public DialClockArray(int length)
        {
            dialClocks = new DialClock[length];
            for (int i = 0; i < length; i++) 
            {
                dialClocks[i] = new DialClock(rnd.Next(12),rnd.Next(60));
            }
        }

        // конструктор копирования
        public DialClockArray(DialClockArray other)
        {
            dialClocks = new DialClock[other.Length];
            for (int i = 0; i < other.Length; i++)
            {
                // копирование объекта
                dialClocks[i] = new DialClock(other[i]);
            }
        }

        // индексатор
        public DialClock this[int index]
        {
            get
            {
                if (index >= 0 && index < dialClocks.Length)
                    return dialClocks[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < dialClocks.Length)
                    dialClocks[index] = value;
                else 
                    Console.WriteLine("Выход за границу массива");
            }
        }
        
        // вывод массива
        public void Show()
        {
            for (int i = 0; i<this.Length; i++)
            {
                Console.WriteLine(dialClocks[i]);
            }
        }
    }
}
