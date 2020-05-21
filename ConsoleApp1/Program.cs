using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp20200212
{
    #region test1
    class A
    {
        public A()
        {
            PrintFileds();
        }
        public virtual void PrintFileds() { }
    }

    class B : A
    {
        int x = 1;
        int y;
        public B()
        {
            y = -1;
        }
        public override void PrintFileds()
        {
            //base.PrintFileds();
            Console.WriteLine("x={0},y={1}", x, y);
        }
    }
    #endregion
    #region test2
    class BaseAction
    {
        public virtual void  Say() { }
    }
    class Son: BaseAction
    {
        public override void Say()
        {
            Console.WriteLine("Son:我渴了。。。。");
            new Mum();
            new Dad();
        }
    }
    class Mum: BaseAction
    {
        public Mum()
        {
            Say();
        }
        public override void Say()
        {
            Console.WriteLine("Mum 水来了。。。。");
        }
    }
    class Dad:BaseAction
    {
        public Dad()
        {
            Say();
        }
        public override void Say()
        {
            Console.WriteLine("Dad 站起来看看。。。。");
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            //tset1
            Console.WriteLine("----------------5、start----------------");
            new B();
            Console.WriteLine("----------------5、end------------------");
            //test2
            Console.WriteLine("----------------6、start----------------");
            int i = 5;
            int j = 5;
            string s1 = "Hello";
            string s2 = "Hello";
            Console.WriteLine("object.Equals(i, j)");
            if (object.Equals(i, j))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
            Console.WriteLine("object.Equals(s1, js2)");
            if (object.Equals(s1, s2))
            {
                Console.WriteLine("Equals");
            }
            else
            {
                Console.WriteLine("Not Equals");
            }
            Console.WriteLine("----------------6、end------------------");
            Console.WriteLine("----------------11、start---------------");
            Console.WriteLine("违反了第三范式，将学员信息和学院名称放在同一张表中是不科学的，因为学员所属学院，" +
                "可将学员信息和学院信息单独存放，然后外键关联进行建表。。");
            Console.WriteLine("----------------11、end-----------------");
            Console.WriteLine("----------------12、start---------------");
            Son son = new Son();
            son.Say();
            Console.WriteLine("----------------12、end-----------------");
            Console.ReadKey();
        }
    }
}
