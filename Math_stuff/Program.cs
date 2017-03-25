using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class Program
    {
        static void Main()
        {           
            AVL_Tree Tree = new AVL_Tree(1);// need to be turned into a tree    
            Console.WriteLine(2);
            Tree.Insert(2);
            Console.WriteLine(1);
            Tree.Insert(1);
            Console.WriteLine(2);
            Tree.Insert(2);
            Console.WriteLine(1);
            Tree.Insert(1);
            Console.WriteLine(2);
            Tree.Insert(2);
            Console.WriteLine(1);
            Tree.Insert(1);
            Console.WriteLine(2);
            Tree.Insert(2);
            Tree.Print_tree();
            Tree.Height_print();
            Console.WriteLine(0);
            Tree.Insert(0);
            Console.WriteLine(3);
            Tree.Insert(3);//test0
            /*Console.WriteLine(2);
            Tree.Insert(2);
            Console.WriteLine(3);
            Tree.Insert(3);
            Console.WriteLine(4);
            Tree.Insert(4);
            Console.WriteLine(5);
            Tree.Insert(5);
            Console.WriteLine(6);
            Tree.Insert(6);
            Console.WriteLine(7);
            Tree.Insert(7);
            Console.WriteLine(8);
            Tree.Insert(8);
            Console.WriteLine(9);
            Tree.Insert(9);
            Console.WriteLine(10);
            Tree.Insert(10);
            Console.WriteLine(11);
            Tree.Insert(11);
            Console.WriteLine(12);
            Tree.Insert(12);//test1
            Console.WriteLine(17);
            Tree.Insert(17);
            Console.WriteLine(30);
            Tree.Insert(30);
            Console.WriteLine(62);
            Tree.Insert(62);
            Console.WriteLine(50);
            Tree.Insert(50);
            Console.WriteLine(78);
            Tree.Insert(78);
            Console.WriteLine(88);
            Tree.Insert(88);
            Console.WriteLine(48);
            Tree.Insert(48);
            Console.WriteLine(54);
            Tree.Insert(54);            
            Console.WriteLine(18);
            Tree.Insert(18);
            Console.WriteLine(31);
            Tree.Insert(31);
            Console.WriteLine(70);
            Tree.Insert(70);
            Console.WriteLine(80);
            Tree.Insert(80);
            Console.WriteLine(89);
            Tree.Insert(89);
            Console.WriteLine(90);
            Tree.Insert(90);
            Console.WriteLine(91);
            Tree.Insert(91);
            Console.WriteLine(92);
            Tree.Insert(92);
            Console.WriteLine(93);
            Tree.Insert(93);
            Console.WriteLine(94);
            Tree.Insert(94);
            Console.WriteLine(95);
            Tree.Insert(95);*/
            Tree.Print_tree();
            Tree.Height_print();
            Console.WriteLine("/*************END_TEST*************/");
            Console.Read();
        }
    }
}
