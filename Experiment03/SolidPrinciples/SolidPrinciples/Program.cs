using System;

namespace SolidPrinciples
{
    class Program
    {
        //Bad Example of Single Responsibility Principle
        class Student
        {
            public void SaveStudent() { }
            public void PrintReport() { }
        }

        //Good Example of Single Responsibility Principle
        class Student1
        {
            public string Name;
        }

        class StudentRepository
        {
            public void SaveStudent(Student student) { }
        }

        class StudentReport
        {
            public void PrintReport(Student student) { }
        }

        //Bad Example of Open/Closed Principle
        class Discount
        {
            public double GetDiscount(string type)
            {
                if (type == "Student") return 0.2;
                if (type == "Senior") return 0.3;
                return 0;
            }
        }


        //Good Example using inheritance of open/closed principles
        abstract class Discount1
        {
            public abstract double GetDiscount();
        }

        class StudentDiscount : Discount1
        {
            public override double GetDiscount() => 0.2;
        }

        class SeniorDiscount : Discount1
        {
            public override double GetDiscount() => 0.3;
        }

        //Bad Example of Liskov Substitution Principle
        class Bird
        {
            public virtual void Fly() { }
        }

        class Ostrich : Bird
        {
            public override void Fly()
            {
                throw new Exception("Can't fly");
            }
        }

        //Good Example of Liskov Substitution Principle
        abstract class Bird1 { }

        class FlyingBird : Bird1
        {
            public void Fly() { }
        }

        class Ostrich1 : Bird1 { }

        //Bad Example of Interface Segregation Principle
        interface IWorker
        {
            void Work();
            void Eat();
        }

        interface IWork
        {
            void Work();
        }

        interface IEat
        {
            void Eat();
        }

        //Good Example of Interface Segregation Principle
        class Human : IWork, IEat
        {
            public void Work() { }
            public void Eat() { }
        }

        class Robot : IWork
        {
            public void Work() { }
        }

        //Bad Example of Dependency Inversion Principle

        class Keyboard { }

        class Computer
        {
            private Keyboard keyboard = new Keyboard();
        }

        //Good Example of Dependency Inversion Principle

        interface IKeyboard1 { }

        class Keyboard1 : IKeyboard1 { }

        class Computer1
        {
            private IKeyboard1 keyboard1;

            public Computer1(IKeyboard1 keyboard1)
            {
                this.keyboard1 = keyboard1;
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
