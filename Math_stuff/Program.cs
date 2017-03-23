using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class Program
    {
        static void Main(string[] args)
        {
            AVL Tree = new AVL(44);// need to be turned into a tree
            Console.WriteLine(17);
            Tree.insert(17);
            Console.WriteLine(30);
            Tree.insert(30);
            Console.WriteLine(62);
            Tree.insert(62);
            Console.WriteLine(50);
            Tree.insert(50);
            Console.WriteLine(78);
            Tree.insert(78);
            Console.WriteLine(88);
            Tree.insert(88);
            Console.WriteLine(48);
            Tree.insert(48);
            Console.WriteLine(54);
            Tree.insert(54);
            Tree.tree_print();
            Console.WriteLine(18);
            Tree.insert(18);
            Console.WriteLine(31);
            Tree.insert(31);
            Tree.tree_print();
            Console.Read();
        }
    }
}
