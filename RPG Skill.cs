using System;
using System.Collections.Generic;
using System.Collections;

namespace RPG_skill
{
    class Program
    {
        static Queue skilltreequeue = new Queue();

        static void Main(string[] args)
        {
            int skillpont = 0;

            int counter = 0;

            bool addingskill = true;

            while (addingskill)
            {
                string skillname = "";

                Console.Write("Intput skill name : ");

                skillname = Console.ReadLine();

                if (skillname == "?")
                {
                    addingskill = false;
                    break;
                }



                Node skill = new Node(skillname);

                counter += 1;

                skilltreequeue.Push(skill);
                
               

                Console.Write("Add dependency for {0}? (Y/N) ", skillname);

                char yesno = char.Parse(Console.ReadLine());

                while(yesno != 'N')
                {
                    if (yesno == 'Y')
                    {
                        Console.Write("Input skill name : ");

                        string nextskillname = Console.ReadLine();

                        Node nextskill = new Node(nextskillname);

                        nextskill = skill.Left;
                        skill = nextskill;

                        
                        Console.Write("Add dependency for {0}? (Y/N) :", nextskillname);

                        yesno = Char.Parse(Console.ReadLine());

                        if(yesno == 'N')
                        {
                             break;
                        }
                        else
                        {
                             continue;
                        }
                        


                    }
                    

                }

                    



               

            }

            Console.ReadLine();
            
        }

       

       

        static void BuildTreeFromQueue()
        {

        }
    }

    class Queue
    {
        private Node root;

       

        public void Push(Node node)
        {
            if (root == null)
            {
                root = node;
            }
            else
            {
                Node ptr = root;
                while(ptr.Left != null)
                {
                    ptr = ptr.Left;
                }
                ptr.Left = node;
            }
                

        }   

        public Node Pop()
        {
            Node node = root;
            if(root != null)
            {
                root = root.Left;
                node.Left = null;
            }
            return node;
        }
    }

    class Node
    {
        public string skillname;

        public Node Left;

        public Node(string name)
        {
            this.skillname = name;
        }

        public override string ToString()
        {
            return skillname;
        }
    }
}
