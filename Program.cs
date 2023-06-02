using DoFactory.GangOfFour.Builder.RealWorld;
using System;
using System.Collections.Generic;
namespace DoFactory.GangOfFour.Builder.Structural
{
    /// <summary>
    /// MainApp startup class for Structural
    /// Builder Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        //public static void Main()
        //{
        //    // Create director and builders
        //    Director director = new Director();
        //    Builder b1 = new ConcreteBuilder1();
        //    Builder b2 = new ConcreteBuilder2();
        //    // Construct two products
        //    director.Construct(b1, "Young");
        //    Product p1 = b1.GetResult();
        //    p1.Show();
        //    director.Construct(b2, "Young");
        //    Product p2 = b2.GetResult();
        //    p2.Show();
        //    // Wait for user
        //    Console.ReadKey();
        //}

        public static void Main()
        {
            VehicleBuilder builder;

            // Create shop with vehicle builders

            Shop shop = new Shop();

            // Construct and display vehicles

            builder = new ScooterBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new CarBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            builder = new MotorCycleBuilder();
            shop.Construct(builder);
            builder.Vehicle.Show();

            // Wait for user

            Console.ReadKey();
        }

    }
    /// <summary>
    /// The 'Director' class
    /// </summary>
    class Director
    {
        // Builder uses a complex series of steps
        public void Construct(Builder builder,string name)
        {
            builder.BuildPartA();
            builder.BuildPartB();
            builder.PrintString(name);
        }
    }
    /// <summary>
    /// The 'Builder' abstract class
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();
        public abstract void PrintString(string ret);
    }
    /// <summary>
    /// The 'ConcreteBuilder1' class
    /// </summary>
    class ConcreteBuilder1 : Builder
    {
        private Product _product = new Product();
        public override void BuildPartA()
        {
            _product.Add("PartA");
        }
        public override void BuildPartB()
        {
            _product.Add("PartB");
        }
        public override Product GetResult()
        {
            return _product;
        }

        public override void PrintString(string ret) 
        {
            _product.AddName(ret.ToUpper());
        }
    }
    /// <summary>
    /// The 'ConcreteBuilder2' class
    /// </summary>
    class ConcreteBuilder2 : Builder
    {
        private Product _product = new Product();
        public override void BuildPartA()
        {
            _product.Add("PartX");
        }
        public override void BuildPartB()
        {
            _product.Add("PartY");
        }
        public override Product GetResult()
        {
            return _product;
        }

        public override void PrintString(string ret)
        {
            _product.AddName(ret.ToLower());
        }

    }
    /// <summary>
    /// The 'Product' class
    /// </summary>
    class Product
    {
        private List<string> _parts = new List<string>();
        string _name;
        public void Add(string part)
        {
            _parts.Add(part);
        }
        public void AddName(string part)
        {
            _name = part;
        }
        public void Show()
        {
            Console.WriteLine("\nProduct Parts -------");
            Console.WriteLine(_name);
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}