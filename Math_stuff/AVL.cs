using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class AVL//<T>
    {
        private int heigh = 1;
        private int data;
        private AVL mum = null;
        private AVL right = null;
        private AVL left = null;
        private AVL_Tree tree = null;
        public AVL(int data1)
        { 
            this.data = data1;
        }
        
        public AVL(int data, AVL right, AVL left)
        {
            this.heigh++;
            this.data = data;
            this.right = right;
            this.left = left;           
        }

        public void Set_data(int data)
        {
            this.data = data;
        }

        public void Set_right(AVL right)
        {
            this.right = right;
        }

        public void Set_left(AVL left)
        {
            this.left = left;
        }

        public void Set_mum(AVL mum)
        {
            this.mum = mum;
        }

        public int Get_heigh()
        {
            return heigh;
        }

        public int Get_data()
        {
            return data;
        }

        public AVL Get_right()
        {
            return right;
        }

        public AVL Get_left()
        {
            return left;
        }

        public AVL Get_mum()
        {
            return mum;
        }        

        public void Insert(int value)//logn
        {
            if (data < value) {
                if (this.right != null)
                    this.right.Insert(value);
                else
                {
                    this.right = new AVL(value);
                    this.right.Set_mum(this);
                    this.right.SetTree(tree);
                    this.right.Cal_heigh();
                }
            }
            else {
                if (this.left != null)
                    this.left.Insert(value);
                else
                { 
                    this.left = new AVL(value);
                    this.left.Set_mum(this);
                    this.left.SetTree(tree);
                    this.left.Cal_heigh();
                }
            }

        }

        public void Remove(int value)//logn
        {

        }

        // Add one to every suitable root, call order if it pass on avl rules
        private void Cal_heigh()//logn
        {
            AVL mum = this.Get_mum();
            if (mum != null)
            {
                int left_h;
                if (mum.Get_left() == null)
                    left_h = 0;
                else
                    left_h = mum.Get_left().Get_heigh();

                int right_h;
                if (mum.Get_right() == null)
                    right_h = 0;
                else
                    right_h = mum.Get_right().Get_heigh();

                int diff = right_h - left_h;

                Console.WriteLine("Cal_heigh {0}, {1}, {2}", mum.Get_left(), mum, mum.Get_right());
                Console.WriteLine("{0}, {1}, {2}", left_h, mum.Get_heigh(), right_h);
                //Console.Read();

                AVL X = this.Get_mum();

                if (diff >= 2)
                {
                    this.heigh--;//for setup to order
                    AVL mum_of_mum = mum.Get_mum();
                    X = mum.Order(mum.Get_right());
                    if (mum_of_mum != null)//set the mum of mum pointers
                    {
                        if (mum_of_mum.right == mum)
                            mum_of_mum.right = X;
                        else
                            mum_of_mum.left = X;

                    }
                }
                   
                else
                {
                    if (diff <= -2)
                    {
                       this.heigh--;//for setup to order
                        AVL mum_of_mum = mum.Get_mum();
                        X = mum.Order(mum.Get_left());
                        if (mum_of_mum != null)//set the mum of mum pointers
                        {
                            if (mum_of_mum.right == mum)
                                mum_of_mum.right = X;
                            else
                                mum_of_mum.left = X;

                        }
                    }
                    else
                    {
                        if (diff > 0)
                            mum.heigh = right_h + 1;
                        else
                            mum.heigh = left_h + 1;
                    }
                }
                Console.WriteLine("{0}, {1}, {2}", left_h, mum.Get_heigh(), right_h);
                //Console.Read();
                X.Cal_heigh();
            }
        }

        // Change the 
        private AVL Order(AVL Y)//o(1)
        {
            AVL Z = this;            
            //Find x
            int Y_left_h;
            if (Y.Get_left() == null)
                Y_left_h = 0;
            else
                Y_left_h = Y.Get_left().Get_heigh();
            int Y_right_h;
            if (Y.Get_right() == null)
                Y_right_h = 0;
            else
                Y_right_h = Y.Get_right().Get_heigh();
            AVL X;
            if (Y_right_h > Y_left_h)
                X = Y.Get_right();
            else
                X = Y.Get_left();

            this.tree.Print_tree();
            Console.WriteLine("Order "+Y.Get_heigh() + " " + X.Get_heigh()+ " " + Z.Get_heigh());            
            //Console.Read();

            AVL output;

            if(Z.left == Y)
                if (Y_right_h > Y_left_h)//x== y.right
                {
                    Console.WriteLine("Y X Z");
                    Console.WriteLine(Y + " " + X + " " + Z);
                    Y.Set_right(X.left);
                    if (X.left != null)
                        X.left.Set_mum(Y);
                    Z.Set_left(X.right);
                    if (X.right != null)
                        X.right.Set_mum(Z);
                    X.Set_left(Y);
                    X.Set_right(Z);

                    X.Set_mum(Z.mum);
                    Z.Set_mum(X);
                    Y.Set_mum(X);                    
                    output = X;
                }
                else
                {
                    Console.WriteLine("X Y Z");
                    Console.WriteLine(X + " " + Y + " " + Z);
                    Z.Set_left(Y.right);
                    if (Y.right != null)
                        Y.right.Set_mum(Z);

                    Y.Set_mum(Z.Get_mum());
                    Y.Set_right(Z);
                    Z.Set_mum(Y);
                    output = Y;
                }                
            else
            {
                if (Y_right_h > Y_left_h)//x== y.right
                {
                    Console.WriteLine("Z Y X");
                    Console.WriteLine(Z + " " + Y + " " + X);
                    Z.Set_right(Y.left);
                    if (Y.left != null)
                        Y.left.Set_mum(Z);

                    Y.Set_mum(Z.Get_mum());
                    Y.Set_left(Z);
                    Z.Set_mum(Y);
                    output = Y;
                }
                else
                {
                    Console.WriteLine("Z X Y");
                    Console.WriteLine(Z + " " + X + " " + Y);
                    Y.Set_left(X.right);
                    if (X.right != null)
                        X.right.Set_mum(Y);
                    Z.Set_right(X.left);
                    if (X.left != null)
                        X.left.Set_mum(Z);
                    X.Set_left(Z);
                    X.Set_right(Y);
                    
                    X.Set_mum(Z.mum);
                    Z.Set_mum(X);
                    Y.Set_mum(X);
                    output = X;                    
                }
            }           
            if (output.mum == null)
                tree.Update_root(output);
            this.tree.Print_tree();
            return output;
        }

        public void SetTree(AVL_Tree tree)
        {
            this.tree = tree;
        }

        override
        public string ToString()
        {
            return data.ToString();
        }

        public void Tree_print()
        {
            Preorder();
            Console.WriteLine("/preorder");
            Inorder();
            Console.WriteLine("/inorder");
        }

        public void Preorder()
        {
            Console.Write(this + " ");
            if (left != null)
                left.Preorder();            
            if (right != null)
                right.Preorder();

        }
        public void Inorder()
        {
            if (left != null)
                left.Inorder();
            Console.Write(this + " ");
            if (right != null)
                right.Inorder();
        }
        public void Postorder()
        {
            if (left != null)
                left.Postorder();          
            if (right != null)
                right.Postorder();
            Console.Write(this + " ");
        }
    }
}
