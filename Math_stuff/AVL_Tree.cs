using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class AVL_Tree<T> where T : IComparable<T>
    {
        private AVL<T> root = null;
        //BUILDING FUNCTIONS
        public AVL_Tree() {     }

        public AVL_Tree(T data)
        {
            root = new AVL<T>(data);
            root.SetTree(this);
        }

        public AVL_Tree(AVL<T> left, T data, AVL<T> right)
        {
            root = new AVL<T>(data, right, left);
            root.SetTree(this);
        }

        // THE ROOT MAY CHANGED DURING THE INSERTING OR REMOVING
        public void Update_root(AVL<T> root)
        {
            this.root = root;
        }

        // INSERTs VALUE TO THE TREE
        public void Insert(T value)
        {
            if (root == null)
            {
                root = new AVL<T>(value);
                root.SetTree(this);
            }
            else
                root.Insert(value);
        }        

        // REMOVEs VALUE FROM THE TREE
        public void Remove(T value)
        {
            root.Remove(value);
        }

        //Returns true if the tree is empty
        public bool IsEmpty()
        {
            return root == null;
        }

        //print the tree structure
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
