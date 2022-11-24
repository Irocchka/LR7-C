using System;
namespace library
{
    public enum eClassficationAnimal
    {
        Herbivores,
        Carnivores,
        Ownivores
    }

    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [MyComment("i love animals")]

    public class Animal
    {
        public string Country { get; set; }//свойства
        public bool HideFromOtherAnimals { get; set; }
        public string Name { get; set; }
        public string WhatAnimal { get; set; }

        public Animal(string c, bool h, string n, string w)
        {
            Country = c;
            HideFromOtherAnimals = h;
            Name = n;
            WhatAnimal = w;
        }
        public void Deconstruct()
        {

        }
        public eClassficationAnimal GetClassificationAnimal()
        {
            return eClassficationAnimal.Ownivores;
        }
        public virtual void GetFavouriteFood()
        {
            Console.WriteLine("ням ням,моя еда:");
        }
        public virtual void SayHello()
        {
            Console.WriteLine("угадай,что я говорю:");
        }
    }

    [MyComment("Я-Коровка из Простоквашино")]
    public class Cow : Animal
    {
        public Cow(string c, bool h, string n) : base(c, h, n, "Cow") { }
        public override void GetFavouriteFood()
        {
            Console.WriteLine(eFavoriteFood.Plants);
        }
        public override void SayHello()
        {
            Console.WriteLine("мууууууууууу");
        }
    }

    [MyComment("Я милый львенок,король зверей")]
    public class Lion : Animal
    {
        public Lion(string c, bool h, string n) : base(c, h, n, "Lion") { }
        public override void GetFavouriteFood()
        {
            Console.WriteLine(eFavoriteFood.Meat);
        }
        public override void SayHello()
        {
            Console.WriteLine("рар");
        }
    }

    [MyComment("Меня зовут Пухля,хрю-хрю")]
    public class Pig : Animal
    {
        public Pig(string c, bool h, string n) : base(c, h, n, "Pig") { }
        public override void GetFavouriteFood()
        {
            Console.WriteLine(eFavoriteFood.Everything);
        }
        public override void SayHello()
        {
            Console.WriteLine("хрю-хрю-хрю");
        }
    }
}
