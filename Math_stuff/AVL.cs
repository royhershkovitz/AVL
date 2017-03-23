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

        public void set_data(int data)
        {
            this.data = data;
        }

        public void set_right(AVL right)
        {
            this.right = right;
        }

        public void set_left(AVL left)
        {
            this.left = left;
        }

        public void set_mum(AVL mum)
        {
            this.mum = mum;
        }

        public int get_heigh()
        {
            return heigh;
        }

        public int get_data()
        {
            return data;
        }

        public AVL get_right()
        {
            return right;
        }

        public AVL get_left()
        {
            return left;
        }

        public AVL get_mum()
        {
            return mum;
        }

        public void cal_heigh()//logn
        {
            AVL mum = this.get_mum();           
            if (mum != null)
            {
                int left_h;
                if (mum.get_left() == null)
                    left_h = 0;
                else
                    left_h = mum.get_left().get_heigh();
                int right_h;
                if (mum.get_right() == null)
                    right_h = 0;
                else
                    right_h = mum.get_right().get_heigh();
                int diff = right_h - left_h;
                Console.WriteLine("cal_heigh " + get_mum());
                Console.WriteLine(left_h + " " + right_h);
                Console.Read();
                if (diff == 2)
                    mum.order(mum.get_right());
                else
                {
                    if (diff == -2)
                       mum.order(mum.get_left());
                    else
                    {
                        if (diff > 0)
                            mum.heigh = right_h + 1;
                        else
                            mum.heigh = left_h + 1;
                    }
                }
                mum.cal_heigh();
            }
        }

        public void insert(int value)//logn
        {
            if (data < value) {
                if (this.right != null)
                    this.right.insert(value);
                else
                {
                    this.right = new AVL(value);
                    this.right.set_mum(this);
                    this.heigh++;
                    this.cal_heigh();
                }
            }
            else {
                if (this.left != null)
                    this.left.insert(value);
                else
                { 
                    this.left = new AVL(value);
                    this.left.set_mum(this);
                    this.heigh++;
                    this.cal_heigh();
                }
            }

        }

        public void remove(int value)//logn
        {

        }

        public void order(AVL Y)//o(1)
        {
            AVL Z = this;
            int left_h;
            if (Y.get_left() == null)
                left_h = 0;
            else
                left_h = Y.get_left().get_heigh();
            int right_h;
            if (Y.get_right() == null)
                right_h = 0;
            else
                right_h = Y.get_right().get_heigh();
            AVL X;
            if (right_h > left_h)
                X = Y.get_right();
            else
                X = Y.get_left();
            this.tree_print();
            Console.WriteLine(Y.get_heigh() + " " + X.get_heigh()+ " " + Z.get_heigh());
            Console.WriteLine(Y + " " + X + " " + Z);
            Console.Read();
            Y.set_right(X.left);
            if (X.left != null)
                X.left.set_mum(Y);
            Z.set_left(X.right);
            if (X.right != null)
                X.right.set_mum(Z);
            X.set_left(Y);
            X.set_right(Z);
            X.set_mum(Z.mum);
            Z.set_mum(X);
            Y.set_mum(X);
            this.tree_print();
        }

        override
        public string ToString()
        {
            return data.ToString();
        }

        public void tree_print()
        {
            preorder();
            Console.WriteLine("/preorder");
            Inorder();
            Console.WriteLine("/inorder");
        }

        public void preorder()
        {
            Console.Write(this + " ");
            if (left != null)
                left.preorder();            
            if (right != null)
                right.preorder();

        }
        public void Inorder()
        {
            if (left != null)
                left.Inorder();
            Console.Write(this + " ");
            if (right != null)
                right.Inorder();

        }
    }
}
