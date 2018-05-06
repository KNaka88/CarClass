using System;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Simple Exception Example");
            Console.WriteLine("Creating a car and stepping on it");
            Car myCar = new Car("Zippy", 20);
            myCar.CrankTunes(true);

            try
            {
                for (int i = 0; i < 10; i++)
                    myCar.Accelerate(10);
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR");
                Console.WriteLine($"Method: {e.TargetSite}");
                Console.WriteLine($"Message: {e.Message}");
                Console.WriteLine($"Source: {e.Source}");
            }

            Console.WriteLine("Out of exception logic");
            Console.ReadLine();
        }
    }

    class Radio
    {
        public void TurnOn(bool on)
        {
            Console.WriteLine(on ? "Jamming..." : "Quiet time...");
        }
    }

    class Car
    {
        public const int MaxSpeed = 100;
        public int CurrentSpeed { get; set; } = 0;
        public string PetName { get; set; } = "";
        private bool carIsDead;
        private Radio theMusicBox = new Radio();

        public Car(){}
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }

        public void CrankTunes(bool state)
        {
            theMusicBox.TurnOn(state);
        }

        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine($"{PetName} is out of order...");
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;

                    throw new Exception($"{PetName} has overheated!");
                }
                else
                    Console.WriteLine($"=> CurrentSpeed = {CurrentSpeed}");
            }
        }
    }
}
