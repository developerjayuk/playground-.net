using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();

            //p.Assignment1();
            //p.Assignment2();
            //p.Assignment3();
            //p.Assignment4();
            //p.Assignment5();
            //p.Assignment6();
            p.Assignment7();


            Console.ReadLine();
        }

        public void Assignment7()
        {
            // create a specified output using for loops, continue and labels
            for (var i = 1; i <= 8; i++)
            {
                for (var j = 1; j <= 10; j++)
                {
                    if (i == 8) goto myLabel;
                    
                    if ((i > 3 || j == 5 || j == 6)) continue;
                    
                    myLabel:
                    Console.Write(j + " ");
                }

                for (var j = 10; j > 0; j--)
                {
                    if (i == 6 && j < 3) continue;
                    if ((i > 3 && i != 8)) Console.Write(j + " ");
                }
                Console.WriteLine();
            }
        }

        public void Assignment6()
        {
            // get largest number
            const int numberOfInputs = 3;
            var inputs = new List<int>();

            for (var i = 1; i <= numberOfInputs; i++)
            {
                Console.WriteLine($"Please enter integer number {i} of {numberOfInputs}");
                inputs.Add(Convert.ToInt32(Console.ReadLine()));
            }

            var max = inputs[0];

            for (var i = 1; i < numberOfInputs; i++)
            {
               if (inputs[i] > max) max = inputs[i];
            }

            Console.WriteLine($"The largest number you input was {max}");
        }

        public void Assignment5()
        {
            // assignment 5 - height categories
            Console.WriteLine("Please enter your height in inches");
            if (!int.TryParse(Console.ReadLine(), out var heightInInches)) return;
            var cms = heightInInches * 2.54;
            var output = "";

            if (cms < 150)
                output = "Dwarf";
            else if (cms >= 150 && cms < 165)
                output = "Average height";
            else if (cms >= 165 && cms < 195)
                output = "Tall";                
            else if (cms > 195)
                output = "Abnormal height";

            Console.WriteLine($"Your height category is determined to be {output}");
        }

        public void Assignment4()
        {
            //assignment 4 - Time passed by seconds
            Console.WriteLine("Please enter the number of seconds passed");
            if (int.TryParse(Console.ReadLine(), out var number))
            {
                var timeLeft = number;
                int days = 0, hours = 0, minutes = 0, seconds = 0;

                const int min = 60;
                const int hour = min * 60;
                const int day = hour * 24;

                if (timeLeft > day)
                {
                    days = Convert.ToInt32(timeLeft / day);
                    timeLeft -= (day * days);
                }

                if (timeLeft > hour)
                {
                    hours = Convert.ToInt32(timeLeft / hour);
                    timeLeft -= (hour * hours);
                }

                if (timeLeft > min)
                {
                    minutes = Convert.ToInt32(timeLeft / min);
                    timeLeft -= (min * minutes);
                }

                seconds = timeLeft;

                Console.WriteLine($"{number} seconds is the equivalent of {days} days, {hours} hours, {minutes} minutes, {seconds} seconds");
            }
        }
        public void Assignment3()
        {
            // assignment 3 - get the nearest thousand 
            Console.WriteLine("Please enter special number");

            if (int.TryParse(Console.ReadLine(), out var number))
            {
                var result = number % 1000 >= 500 ? number + 1000 - number % 1000 : number - number % 1000;

                Console.WriteLine($"The nearest thousand to {number} is {result} ");
            }
            else
            {
                Console.WriteLine("Invalid number entered!");
            }
        }

        public void Assignment2()
        {
            // assignment 2 - area of circle
            Console.WriteLine("Please enter your height in feet and inches in the format 'Feet' space 'inches' example '5 11' for 5 foot 11 inches");
            var heightInput = Console.ReadLine();
            var feet = Convert.ToDouble(heightInput.Split(' ')[0]);
            var inches = Convert.ToDouble(heightInput.Split(' ')[1]);

            var heightInCms = (feet * 30.48) + (inches * 2.54);

            Console.WriteLine($"Your height in cms is {heightInCms} cms");
        }

        public void Assignment1()
        {
            //assignment 1 - area of circle
            var pi = 3.14159;

            Console.WriteLine("Please enter the radius of the circle in cms?");
            var radius = Convert.ToDouble(Console.ReadLine());
            var area = pi * (radius * radius);

            Console.WriteLine($"The area of the circle is {area} cms");
        }
    }

}
