using System;
using System.Collections.Generic;
using System.Text;

namespace AviPreperation.OopsConcept
{
    //A class is a user-defined blueprint or prototype from which objects are created
    public class Pets
    {
        //static void Main()
        //{
        //    //Instantiating the class
        //    Dog puppy = new Dog("Jimmy", 10, "Brown");
        //    Console.WriteLine(puppy.ReturnToString());

        //    Cat Tom = new Cat("Tom", 2, "White");
        //    Console.WriteLine(Tom.ReturnToString());

        //    var breed = new Cat.CatBreed(1, "Bengal Cat");
        //    Console.WriteLine(breed.returnBread());

        //}

        public class Dog
        {

            public int age;
            public string color;
            public string name;
            //Constructor of the class, whcih initializes the fields of the class
            public Dog(string name, int age, string color)
            {
                this.age = age;
                this.name = name;
                this.color = color;
            }

            public string getName()
            {
                return this.name;
            }

            public int getAge()
            {
                return this.age;
            }

            public string getColor()
            {
                return this.color;
            }

            public string ReturnToString()
            {
                return ("Hi my name is " + this.getName() + ", " + this.getAge() + ", " + this.getColor());
            }
        }

        public class Cat
        {
            public int age;
            public string color;
            public string name;
            //Constructor of the class, whcih initializes the fields of the class
            public Cat(string name, int age, string color)
            {
                this.age = age;
                this.name = name;
                this.color = color;
            }

            public string getName()
            {
                return this.name;
            }

            public int getAge()
            {
                return this.age;
            }

            public string getColor()
            {
                return this.color;
            }

            public string ReturnToString()
            {
                return ("Hi my name is " + this.getName() + ", " + this.getAge() + ", " + this.getColor());
            }

            public class CatBreed
            {
                internal int number;
                internal string breedName;

                public CatBreed(int num, string breed)
                {
                    this.number = num;
                    this.breedName = breed;
                }

                public string returnBread()
                {
                    return ("Num :"+this.number+"; Breed : "+this.breedName);
                }
            }
        }
    }
}
