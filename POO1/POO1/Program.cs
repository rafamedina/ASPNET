using System;
using System.Security.Cryptography.X509Certificates;


class A
{
    private int _x;
    public A(int x)
    {
        this._x = x;
    }

    public virtual void Soy()
    {
        Console.WriteLine($"Soy A y x = {_x}");
    }
}

class B: A
{
    public B(int x): base(x) {}
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



