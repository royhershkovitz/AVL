using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class AVL_Tree//<T>->COMPERABLE PROBLEM CHECK
    {
        private AVL root = null;
        public AVL_Tree() {     }

        public AVL_Tree(int data)//AVL_Tree(T data)
        {
            root = new AVL(data);
            root.SetTree(this);
        }

        public AVL_Tree(AVL left, int data, AVL right)//AVL_Tree(AVL left, T data, AVL right)
        {
            root = new AVL(data, right, left);
            root.SetTree(this);
        }
        
        public void Insert(int value)//Insert(T value)
        {
            if (root == null)
            {
                root = new AVL(value);
                root.SetTree(this);
            }
            else
                root.Insert(value);
        }

        public void Update_root(AVL root)
        {
            this.root = root;
        }


        public void Remove(int value)//Remove(T value)
        {
            root.Remove(value);
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        override
        public String ToString()
        {
            return root.ToString();
        }

        public void Print_tree()
        {
            root.Tree_print();
        }

        public void Height_print()
        {
            root.Height_print();
            Console.WriteLine("/*Inorder-height*/");
        }
    }
}
