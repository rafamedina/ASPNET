using System;
using System.Security.Cryptography.X509Certificates;


class A
{
    public virtual void Soy()
    {
        Console.WriteLine("Soy A");
    }
}

class B: A
{
    public override void  Soy()
    {
        Console.WriteLine("Soy B");
    }
}


public class Programa 
{
    public static void Main(string[] args)
    {

        Console.WriteLine("Hello, World!");
        A a = new A();
        a.Soy();
        B b = new B();
        b.Soy();
        A a2 = new B();
        a2.Soy();


    }

}



