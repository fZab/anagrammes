using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagrammes
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] content = File.ReadAllLines(@"words.txt");


            Anagramme a = new Anagramme();
            TreeNode t = new TreeNode(a);

            foreach(string word in content)
            {
                char[] sorted = word.ToCharArray();
                Array.Sort(sorted);

                addChildren(word, sorted, t);
            }

            int i = 0;
            Action<Anagramme> print =
                (Anagramme anag) =>
                {
                    if (anag.refNb > 1)
                    {
                        Console.WriteLine(String.Join(", ", anag.words));
                        i++;
                    }
                };

            t.Traverse(print);
            Console.WriteLine("{0} anagrammes trouvés", i);
            Console.ReadLine();
        }


        static void addChildren(string word, char[] sorted, TreeNode parentNode)
        {
            if(sorted.Length ==0)
            {
                return;
            }

            TreeNode node = parentNode[sorted[0]];
            if (sorted.Length == 1)
            {
                
                if (node == null)
                {
                    Anagramme a = new Anagramme();
                    a.letter = sorted[0];
                    a.addWord(word);
                    
                    parentNode.AddChild(a);
                }
                else
                {
                    node.Value.addWord(word);
                }
            }
            else
            {
                if (node == null)
                {
                    Anagramme a = new Anagramme();
                    a.letter = sorted[0];
                    node = parentNode.AddChild(a);
                }
                addChildren(word, SubArray(sorted, 1, sorted.Length - 1), node);
            }
        }

        public static char[] SubArray(char[] data, int index, int length)
        {
            char[] result = new char[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        
    }
}
