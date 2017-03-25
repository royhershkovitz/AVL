using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math_stuff
{
    class AVL//<T>// will work just if T is comperable
    {
        //The Avl Height        
        protected int Height { get; set; } // The Height property   
        //The tree information        
        public int Data { get; } // The Data property   
        //Mother pointer        
        private AVL Mum { get; set; } // The Mum property   
        //The tree right son       
        private AVL Right { get; set; }  // Right Data property   
        //The tree left son       
        private AVL Left { get; set; } // The Left property   
        //To call the tre for root updates
        private AVL_Tree tree = null; // The tree field
        private AVL_Tree Tree { get; set; } // The Tree property   

        //#Building function
        public AVL(int data)
        {
            Height = 1;
            Data = data;
            Right = null;
            Left = null;
        }
        //#Building function2
        public AVL(int data, AVL right, AVL left)
        {
            Height = 1;
            Data = data;
            Right = right;
            Left = left;           
        }

        public void Insert(int value)//logn
        {
            if (value > Data) {
                if (Right != null)
                    Right.Insert(value);
                else
                {
                    Right = new AVL(value);
                    Right.Mum = this;
                    Right.SetTree(tree);
                    Console.WriteLine("found_place");tree.Print_tree();tree.Height_print();
                    Right.Cal_heigh();
                }
            }
            else {
                if (Left != null)
                    Left.Insert(value);
                else
                { 
                    Left = new AVL(value);
                    Left.Mum = this;
                    Left.SetTree(tree);
                    Console.WriteLine("found_place");tree.Print_tree();tree.Height_print();
                    Left.Cal_heigh();
                }
            }

        }

        public void Remove(int value)//logn
        {

        }

        // Add one to every suitable root, call order if it pass on avl rules
        private void Cal_heigh()//logn
        {
           if (Mum != null)
            {
                int left_h;
                if (Mum.Left == null)
                    left_h = 0;
                else
                    left_h = Mum.Left.Height;

                int right_h;
                if (Mum.Right == null)
                    right_h = 0;
                else
                    right_h = Mum.Right.Height;

                int diff = right_h - left_h;

                //Console.WriteLine("Cal_heigh {0}, {1}, {2}", Mum.Left, Mum, Mum.Right);
                //Console.WriteLine("{0}, {1}, {2}", left_h, Mum.Height, right_h);
                //Console.Read();

                AVL X = Mum;
               
                if (diff == 2)
                {
                    X = Mum.Order(Mum.Left);
                    Mum.Height -= 1;//for setup to order
                    AVL mum_of_mum = Mum.Mum;   
                    if (mum_of_mum != null)//set the mum of mum pointers
                    {
                        if (mum_of_mum.Right == Mum)
                        {
                            X = Mum.Order(Mum.Right);
                            mum_of_mum.Right = X;
                        }
                        else
                        {
                            X = Mum.Order(Mum.Right);
                            mum_of_mum.Left = X;
                        }                           
                    }
                    else
                        X = Mum.Order(Mum.Right);
                }
                else
                {
                    if (diff == -2)
                    {
                        Mum.Height -= 1;//for setup to order
                        AVL mum_of_mum = Mum.Mum;                        
                        if (mum_of_mum != null)//set the mum of mum pointers
                        {
                            if (mum_of_mum.Right == Mum)
                            {
                                X = Mum.Order(Mum.Left);
                                mum_of_mum.Right = X;
                            }
                            else
                            {
                                X = Mum.Order(Mum.Left);
                                mum_of_mum.Left = X;
                            }
                        }
                        else
                            X = Mum.Order(Mum.Left);
                    }
                    else
                    {
                        if (diff > 0)
                            Mum.Height = right_h + 1;
                        else
                            Mum.Height = left_h + 1;
                    }

                }


                //Console.WriteLine("{0}, {1}, {2}", left_h, Height, right_h);
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
            if (Y.Left == null)
                Y_left_h = 0;
            else
                Y_left_h = Y.Left.Height;

            int Y_right_h;
            if (Y.Right == null)
                Y_right_h = 0;
            else
                Y_right_h = Y.Right.Height;

            AVL X;
            if (Y_right_h > Y_left_h)
                X = Y.Right;
            else
                X = Y.Left;

            //tree.Print_tree(); Console.WriteLine("Order "+Y.Height + " " + X.Height + " " + Z.Height); //Console.Read();

            AVL output;

            if(Z.Left == Y)
                if (Y_right_h > Y_left_h)//x==y.right
                {
                    Console.WriteLine("\tY X Z (LR)"); Console.WriteLine(Y + " " + X + " " + Z);

                    Y.Right = X.Left;
                    if (X.Left != null)
                        X.Left.Mum = Y;
                    Z.Left = X.Right;
                    if (X.Right != null)
                        X.Right.Mum = Z;

                    X.Left = Y;
                    X.Right = Z;

                    X.Mum  = Z.Mum;
                    Z.Mum = X;
                    Y.Mum = X;

                    X.Height += 1;
                    Y.Height -= 1;

                    output = X;
                }
                else
                {
                    Console.WriteLine("\tX Y Z (LL)"); Console.WriteLine(X + " " + Y + " " + Z);

                    Z.Left = Y.Right;
                    if (Y.Right != null)
                        Y.Right.Mum = Z;

                    Y.Mum = Z.Mum;
                    Y.Right = Z;
                    Z.Mum = Y;
                    output = Y;
                    if (Y_right_h == Y_left_h)//when no prefernce for x the height is differenct
                    {
                        Z.Height += 1;
                        Y.Height += 1;
                    }
                }                
            else
            {
                if (Y_right_h >= Y_left_h)//x== y.right// I found out that the cases which Y_right_h == Y_left_h solved better with the RR case
                {
                    Console.WriteLine("\tZ Y X (RR)"); Console.WriteLine(Z + " " + Y + " " + X);
                    Z.Right = Y.Left;
                    if (Y.Left != null)
                        Y.Left.Mum = Z;

                    Y.Mum = Z.Mum;
                    Y.Left = Z;
                    Z.Mum = Y;
                    output = Y;
                    if (Y_right_h == Y_left_h)//when no prefernce for x the height is differenct
                    {
                        Z.Height += 1;
                        Y.Height += 1;
                    }
                }
                else
                {
                    Console.WriteLine("\tZ X Y (RL)"); Console.WriteLine(Z + " " + X + " " + Y);
                    Y.Left = X.Right;
                    if (X.Right != null)
                        X.Right.Mum = Y;
                    Z.Right = X.Left;
                    if (X.Left != null)
                        X.Left.Mum = Z;

                    X.Left = Z;
                    X.Right = Y;
                    
                    X.Mum = Z.Mum;
                    Z.Mum = X;
                    Y.Mum = X;

                    X.Height += 1;
                    Y.Height -= 1;

                    output = X;                    
                }
            }           
            if (output.Mum == null)
                tree.Update_root(output);
            //tree.Print_tree();
            return output;
        }

        // print the class AVL_Tree field data
        public void SetTree(AVL_Tree tree)
        {
            this.tree = tree;
        }

        // print the tree data
        override
        public string ToString()
        {
            return Data.ToString();
        }
        
        //print every inorder sturture with its height value
        public void Height_print()
        {
            if (Left != null)
                Left.Height_print();
            Console.Write(this + "_" + Height + " ,");
            if (Right != null)
                Right.Height_print();
        }


        // print the tree structure
        public void Tree_print()
        {
            Preorder();
            Console.WriteLine("/preorder");
            Inorder();
            Console.WriteLine("/inorder");
        }
        // print the 'Preorder' tree structure
        public void Preorder()
        {
            Console.Write(this + " ");
            if (Left != null)
                Left.Preorder();            
            if (Right != null)
                Right.Preorder();

        }
        // print the 'Inorder' tree structure
        public void Inorder()
        {
            if (Left != null)
                Left.Inorder();
            Console.Write(this + " ");
            if (Right != null)
                Right.Inorder();
        }
        // print the 'Postorder' tree structure
        public void Postorder()
        {
            if (Left != null)
                Left.Postorder();          
            if (Right != null)
                Right.Postorder();
            Console.Write(this + " ");
        }
    }
}
