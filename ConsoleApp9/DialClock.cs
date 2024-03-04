using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    public class DialClock
    {
        private int hours;
        private int minutes;

        public int Hours
        {
            get { return hours; }

            set { hours = value % 12; }
        }

        public int Minutes
        {
            get { return minutes; }
            set
            {
                minutes = value % 60;
                Hours += value / 60;
            }

        }
        private static int count = 0;
        public static int Count
        {
            get { return DialClock.count; }
        }

        public int length;

        // конструкторы
        public DialClock()
        {
            hours = 0;
            minutes = 0;
            count++;
        }
        // конструктор для явных
        public DialClock(int hours, int minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            count++;
        }
        // конструктор копирования
        public DialClock(DialClock Clocker)
        {
            hours = Clocker.Hours;
            minutes = Clocker.Minutes;
            count++;
        }

        public double CalculateAngle()
        {
            double hourAngle = (hours % 12 + minutes / 60.0) * 30;
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Round(angle, 4);
        }

        public static double CalculateAngleStatic(int hours, int minutes)
        {
            if (minutes >= 60)
            {
                hours += minutes / 60;
            }
            minutes = minutes % 60;
            hours = hours % 12;

            double hourAngle = (hours % 12 + minutes / 60.0) * 30;
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Round(angle, 4);
        }
        // статический(общий) в любое место
        // не статический для объектов свои
        public void PrintInfo()
        {
            Console.WriteLine($"Часы: {hours}, Минуты: {minutes}");
        }

        public static int GetObjectCount()
        {
            return count;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj is DialClock clock)
            {
                return this.Hours == clock.Hours && this.Minutes == clock.Minutes;
            }
            else
            {
                return false;
            }
        }

        public static DialClock operator --(DialClock var)
        {
            if (var.Hours == 0 && var.Minutes == 0)
            {
                var = new DialClock();
            }
            else
            {
                if (var.Minutes == 0)
                {
                    var.Hours = var.Hours - 1;
                    var.Minutes = 59;
                }
                else
                {
                    var.Minutes--;
                }
            }
            return var;
        }

        public static DialClock operator ++(DialClock var)
        {
            var.Minutes++;
            return var;
        }

        public static bool IsTwoHalf(int hours, int minutes)
        {
            // перевод часов и минуты в углы
            double hourAngle = (hours % 12) * 30 + minutes * 0.5; 
            double minuteAngle = minutes * 6; 

            // разница между углами
            double angleDifference = Math.Abs(hourAngle - minuteAngle);

            // угол делится на 2,5 без остатка, то возвращаем true, иначе false
            return angleDifference % 2.5 == 0;
        }

        public int Counter()
        {
            int count = 0;
            count += Hours * 60;
            count += Hours * 6;
            count += Minutes / 10;
            count += Minutes;
            return count;
        }

        public static int operator +(DialClock dc, int minutes)
        {
            return dc.Minutes + minutes;
        }

        public static int operator -(DialClock dc, int minutes)
        {
            return dc.Minutes - minutes;
        }
        public static int operator +(int minutes, DialClock dc)
        {
            return dc.Minutes + minutes;
        }

        public static int operator -(int minutes, DialClock dc)
        {
            return dc.Minutes - minutes;
        }

        // формат времени
        public override string ToString()
        {
            return $"{Hours:D2}:{Minutes:D2}";
        }

    }

}
