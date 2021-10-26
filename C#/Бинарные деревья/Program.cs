using System;
using MyTrees;
using static System.Console;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using static System.Math;


namespace Tree11
{
    class Program
    {
        static TreeNode<T> MkTNode<T>(
                    T data,
                    TreeNode<T> left = null,
                    TreeNode<T> right = null) => new TreeNode<T>(data, left, right);
        static void InfixPrintTree<T>(TreeNode<T> root)
        {
            if (root == null) return;
            InfixPrintTree<T>(root.left);
            Console.Write(root.data + " ");
            InfixPrintTree<T>(root.right);

        }
        static void PrefixPrintTree<T>(TreeNode<T> root)
        {
            if (root == null)
                return;
            Write($"{root.data} ");
            PrefixPrintTree(root.left);
            PrefixPrintTree(root.right);
        
        }
        static void PrefixPrintlnTree<T>(TreeNode<T> root)
        {
            if (root == null)
            {
                WriteLine("empty");
                return;
            }
            PrefixPrintTree(root);
            WriteLine();
        }
        //Дано бинарное дерево целых чисел. Уменьшить значения чётных вершин в два раза (используйте битовый сдвиг вправо).
        static void DoubleReduceEven(TreeNode<int> root)
        {
            if (root == null) 
                return;
            if (root.data % 2 == 0)
                root.data >>= 1;
            DoubleReduceEven(root.left);
            DoubleReduceEven(root.right);
        }
        // инфиксная печать
        static void InfixPrintlnTree<T>(TreeNode<T> root)
        {
            if (root == null) Console.WriteLine("<empty tree>");
            else
            {
                InfixPrintTree<T>(root);
                Console.WriteLine();
            }
        }
        //Дано бинарное дерево. Дополнить его до полного значениями default(T), не увеличивая количество уровней.
        static void MakeFullTree<T>(ref TreeNode<T> root)
        {
          
            hmfl(ref root, 1, TreeDepth(root));
        }
        // вспомогательная функция для дополнения дерева
        static void hmfl<T>(ref TreeNode<T> root, int currentlvl, int all)
        {
            if (root == null) return;
            if (currentlvl < all)
            {
                if (root.left == null)
                    root = MkTNode(root.data, MkTNode(default(T)), root.right);
                if (root.right == null)
                    root = MkTNode(root.data, root.left, MkTNode(default(T)));
            }
            hmfl(ref root.left, currentlvl + 1, all);
            hmfl(ref root.right, currentlvl + 1, all);
        }

        // количесво уровне в дереве
        static int TreeDepth<T>(TreeNode<T> root)
        {
            if (root == null)
                return 0;
            return Math.Max(TreeDepth(root.left), TreeDepth(root.right)) + 1;
        }
        // Дано бинарное дерево. Вычислить количество листьев в нем.
        static int CountLeaves<T>(TreeNode<T> root)
        {
            if (root == null) 
                return 0;
            if (root.left == null && root.right == null)
                return 1;
            return  CountLeaves(root.right) + CountLeaves(root.left);
        }
        // пример дерева
        static TreeNode<int> CreateSampleIntTree2()
        {
            return MkTNode(7,
               MkTNode(-6, MkTNode(0), MkTNode(11)),
               MkTNode(32, null, MkTNode(-5))
               );
        }
        // пример дерева
        static TreeNode<int> CreateSampleIntTree1()
        {
            return MkTNode(1, MkTNode(2),
                        MkTNode(3, MkTNode(4), MkTNode(5))
            );
        }
        // пример дерева
        static TreeNode<int> CreateSampleIntTree3()
        {
            return MkTNode(-1001,
                MkTNode(999, MkTNode(0, MkTNode(-57))
                )
            );
        }
        static TreeNode<int> CreateSampleIntTree4()
        {
            return MkTNode(1, MkTNode(0), MkTNode(4, MkTNode(3), MkTNode(5)));
        
        }
        static TreeNode<int> CreateSampleIntTree5()
        {
            return (MkTNode(7, MkTNode(4), MkTNode(8, MkTNode(1))));
        }
        // Дано бинарное дерево. Найти в нём заданный элемент.
        static TreeNode<T> TreeFind<T>(TreeNode<T> root, T element)
        {
            if (root == null || root.data.Equals(element))
                return root;
            return TreeFind(root.left, element) ?? TreeFind(root.right, element);

        }
        /*Дано бинарное дерево. Сохранить в линейном двусвязном списке все элементы, расположенные на заданном уровне.*/
        static LinkedList<T> SaveToLL<T>(TreeNode<T> root, int lvl)
        {
            Debug.Assert(lvl >= 1);
            LinkedList<T> res = new LinkedList<T>();
            var maxlvl = TreeDepth(root);
            if (lvl > maxlvl)
                return res;
            hstoll(root, lvl, ref res, 1);
            return res;
        
        }
        // вспомогательная функция для формирования списка
        static void hstoll<T>(TreeNode<T> root, int lvl,ref LinkedList<T> list,int curlvl)
        {
            if (root == null)
                return;
            if (lvl == curlvl)
                list.AddLast(root.data);
            else
            {
                hstoll(root.left, lvl, ref list, curlvl + 1);
                hstoll(root.right, lvl, ref list, curlvl + 1);
            }
            
        
        }
        // Дано бинарное дерево. Вычислить количества чётных и нечётных элементов за один обход (сделать их выходными параметрами)
        static void CountOddEven(TreeNode<int> root, out int odd, out int even)
        {
            (even, odd) = (0, 0);
            if (root == null)
                return;
            hcoe(root,ref odd,ref even);
        
        }
        // вспомогательная функция для подсчета количества четных и нечетных
        static void hcoe(TreeNode<int> root, ref int odd, ref int even)
        {
            if (root == null)
                return;
            if (root.data % 2 == 0)
            {
                even += 1;
                hcoe(root.left, ref odd, ref even);
                hcoe(root.right, ref odd, ref even);

            }
            else
            {
                odd += 1;
                hcoe(root.left, ref odd, ref even);
                hcoe(root.right, ref odd, ref even);
            }
        }
        static TreeNode<int> CreateTree(params int[] elems)
        {
            TreeNode<int> res = null;
            foreach (var x in elems)
                Add(ref res, x);
            return res;
        }
        /////////////////////////////////////// task 7
        ///дополнительные задания лабораторной #4
        ///
        //Дано бинарное дерево (ссылка на его корень TreeNode<T> root). Найти ширину уровня с заданным номером (номер не может быть отрицательным). Если дерево не содержит такого уровня, вернуть 0.
        static int LvlWidth<T>(TreeNode<T> r, int lvl)
        {
            if (r == null)
                return 0;
            if (lvl == 0)
                return 1;
            if (TreeDepth(r) - 1 < lvl)
                return 0;
            var res = 0;
            hclw(r, ref res, lvl);
            return res;
        }
        // помогает найти ширину уровня
        static void hclw<T>(TreeNode<T> r, ref int res,int lvl)
        {
            if (r == null)
                return;
            if (lvl == 0 && r != null)
                res += 1;
            hclw(r.left, ref res, lvl - 1);
            hclw(r.right, ref res, lvl - 1);
        }
        // Дано бинарное дерево. Найти его ширину.
        static int MaxWidth<T>(TreeNode<T> r)
        {
            var mlvl = TreeDepth(r) - 1;
            return hcmw(r, mlvl);
        }
        // помогает найти макс. ширину 
        static int hcmw<T>(TreeNode<T> r, int mlvl)
        {
            if (mlvl >= 0)
                return Max(LvlWidth(r, mlvl), hcmw(r, mlvl - 1));
            else return 0;
        }
        /// Часть В


        //Дан текстовый файл, содержащий целые числа, разделённые пробелами и символами перехода на новую строку. 
        //Добавить все числа в бинарное дерево поиска. Вывести содержимое дерева при префиксном обходе.
        static TreeNode<int> SaveFromFile(string path)
        {
                TreeNode<int> res = null;
                var k = File.ReadAllText(path).Split(new char[] { ' ','\r','\n' }, StringSplitOptions.RemoveEmptyEntries);
                hsff(ref res, k,0);
                return res;
        }
            // вспомогательная функция для сохранения чисел с файла
            static void hsff(ref TreeNode<int> res,string [] k,int pos)
            {
                if (k.Length == pos )
                    return;
                 
                   Add(ref res, int.Parse(k[pos]));
                 
                hsff(ref res,k, pos+1);
            }

            ///Добавляет числа в заданное БДП целых чисел
            static void Add(ref TreeNode<int> root, int x)
            {
                if (root == null) { root = MkTNode(x); return; }
                else if (x < root.data) Add(ref root.left, x);
                else if (x > root.data) Add(ref root.right, x);
            }
        // Дано бинарное дерево поиска целых чисел. Сохранить в линейном двусвязном списке все элементы, удовлетворяющие заданному предикату, отсортированные по убыванию.
        static LinkedList<int> SaveToLL(TreeNode<int> r, Predicate<int> p)
        {
            LinkedList<int> res=new LinkedList<int>();
            hstll(ref res, p, r);
            return res;
        }
        // вспомогательная функция для добавления в список
        static void hstll(ref LinkedList<int> list, Predicate<int> p, TreeNode<int> root)
        {
            if (root == null)
                return;
            hstll(ref list, p, root.right);
            if (p(root.data)&&root!=null)
                list.AddLast(root.data);
            hstll(ref list, p, root.left);
        }
        //  Дан отсортированный массив, создайте на его основе идеально сбалансированное бинарное дерево поиска.
        static TreeNode<int> TreeCreate(params int[] a)
        {
            TreeNode<int> res=null;
            if (a.Length == 1)
            {
                Add(ref res, a[0]);
                return res;
            }
            else if (a.Length == 2)
            {
                Add(ref res, a[0]);
                Add(ref res, a[1]);
                return res;
            }
            Add(ref res, a[(a.Length - 1) / 2]);
            htr(a, ref res,((a.Length-1)/2)-1,((a.Length-1)/2)+1);
            return res;
        }
        // помогает создать бдп на основе массива
        static void htr(int[] a, ref TreeNode<int> res,int ileft,int iright)
        {
            if (ileft >= 0 && iright <= a.Length - 1)
            {
                Add(ref res, a[ileft]);
                Add(ref res, a[iright]);
                htr(a, ref res, ileft - 1, iright + 1);
            }
            if (ileft >= 0 && iright > a.Length - 1)
            {
                Add(ref res, a[ileft]);
                htr(a, ref res, ileft - 1, iright + 1);
            }
            if (ileft < 0 && iright <= a.Length - 1)
            {
                Add(ref res, a[iright]);
                htr(a, ref res, ileft - 1, iright + 1);
            }
            else return;
        }
        /*Распечатать произвольное бинарное дерево в иерархическом виде заваленным влево по сравнению с тем, как обычно рисуют дерево.
         * Корень будет распечатан без отступа от левого края консоли; в первой строке будет распечатан «самый левый» элемент дерева с отступом от левого края консоли, 
         * соответствующим расстоянию этого элемента от корня.*/
        static void PrintlnTree<T>(TreeNode<T> root, string levelIndent = "    ")
        {
            PrintlnTreeNested(root, 0, levelIndent);
        }
        // вспомогательная функция для печати
        static void PrintlnTreeNested<T>(TreeNode<T> root, int level, string indent)
        {
            if (root == null) return;
            PrintlnTreeNested(root.left, level + 1, indent);
            WriteLine(hms(indent,level) + root.data.ToString());
            PrintlnTreeNested(root.right, level + 1, indent);
        }
        // формирует отсуп для печати
        static string hms(string indent, int lvl)
        {
            if (lvl == 0) return "";
            if (lvl-1 <= 0) return indent;
            else return indent + hms(indent, lvl - 1);
        }
        // создает дерево вхождения слова в строку и номера этих строк
        static TreeNode<Crefs> MakeSTree(string path)
        {
            TreeNode<Crefs> res = null;
            var mas = File.ReadAllLines(path);
            MakeCrefs(ref res, mas);
            return res;
        }
        // из массива строк получает слова и создает объект класса Crefs
        static void MakeCrefs(ref TreeNode<Crefs> r, string[] mas)
        {
            for (var i = 0; i < mas.Length; i++)
            {
                var smas = mas[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                foreach (var x in smas)
                {
                    var cref = new Crefs(new List<int> { i }, x);
                    AddWord(ref r, cref, i);
                }
            }
        }
        // добавляет объекс класса Crefs в дерево
        static void AddWord(ref TreeNode<Crefs> r, Crefs x,int index)
        {
            if (r == null) r = MkTNode(x);
            if (x.Word.CompareTo(r.data.Word) == 0&&!r.data.Refs.Contains(index))
                r.data.Refs.Add(index);
            if (x.Word.CompareTo(r.data.Word) < 0)
                AddWord(ref r.left, x,index);
            else if (x.Word.CompareTo(r.data.Word) > 0)
                AddWord(ref r.right, x,index);
        }
        // удаляет элемент из БТП
        static void DeleteNode( ref TreeNode<int> r, int value)
        {
            if (r == null) 
                return;
            if (!Contains(r, value))
                return;
            hdn(ref r, value,ref r);
        }
        // вспомогательная функция для удаления из бдп
        static void hdn(ref TreeNode<int> rparent, int value,ref  TreeNode<int> r)
        {
            if (r == null)
                return;
            var t = r.data;
            if (r.data.Equals(value))
            {
                // удаляемый - лист cлева
                if (r.right == null && r.left == null && rparent.left ==r )
                {
                    rparent = MkTNode(rparent.data, null, rparent.right);
                    return;
                }
                // удаляемый - лист cправа
                if (r.right == null && r.left == null && rparent.right== r)
                {
                    rparent = MkTNode(rparent.data, rparent.left, null);
                    return;
                }
                // удаляемый лист слева от родителя с 1 потомком
                if (rparent.left == r)
                {
                    if (r.right != null && r.left == null)
                    {
                        rparent = MkTNode(rparent.data, r.right, rparent.right);
                        return;
                    }
                    if (r.right == null && r.left != null)
                    {
                        rparent = MkTNode(rparent.data, r.left, rparent.right);
                        return;
                    }
                }
                // удаляемый лист справа от родителя с 1 потомком
                if (rparent.right == r)
                {
                    if (r.right != null && r.left == null)
                    {
                        rparent = MkTNode(rparent.data, rparent.left,r.right);
                        return;
                    }
                    if (r.right == null && r.left != null)
                    {
                        rparent = MkTNode(rparent.data, rparent.left,r.left);
                        return;
                    }
                }
                if (r.right != null && r.left != null)
                {
                    var lmax = int.MinValue;
                    LocalMax(r.left, ref lmax);
                    r.data = lmax;
                    DeleteFirstOrSecond(ref r, lmax,ref  r.left);
                }
            }
            hdn(ref r, value,ref r.right);
            hdn(ref r, value,ref r.left);
        }

        // функция отдельно лишь для 2 и 1 случая, помогающая в 3 случае
        static void DeleteFirstOrSecond(ref TreeNode<int> rparent, int value,ref TreeNode<int> r)
        {
            // лист
            if (IsLeaf(r))
            {
                rparent = MkTNode(rparent.data, null, rparent.right);
                return;
            }
            // удаляемый  слева от родителя с 1 потомком
                if (r.right != null && r.left == null)
                {
                    rparent = MkTNode(rparent.data, r.right, rparent.right);
                    return;
                }
                if (r.right == null && r.left != null)
                {
                    rparent = MkTNode(rparent.data, r.left, rparent.right);
                    return;
                }
            }
        // локальный максимум БДП
        static void LocalMax(TreeNode<int> r,ref int number)
        {
            if (r == null)
                return;
            if (r.data > number)
                number = r.data;
            LocalMax(r.right, ref number);
            LocalMax(r.left, ref number);
        }
        // является ли узел листом
        static bool IsLeaf<T>(TreeNode<T> root)
        {
            return (root.right == null) && (root.left == null);
        }
        ///Определяет, содержится ли в бинарном дереве заданное число.
        static bool Contains(TreeNode<int> root, int x)
        {

            if (root == null) return false;
            if (root.data.Equals(x))
                return true;
            return Contains(root.left, x) || Contains(root.right, x);
        }



        static void Main(string[] args)
        {
            WriteLine("Task 1");
            var tree = MkTNode(6, MkTNode(3), MkTNode(4));
            InfixPrintlnTree(tree);
            DoubleReduceEven(tree);
            InfixPrintlnTree(tree);
            TreeNode<int> empty = null;
            InfixPrintlnTree(empty);
            DoubleReduceEven(empty);
            InfixPrintlnTree(empty);
            var tree1 = MkTNode(5, MkTNode(3), MkTNode(-1));
            InfixPrintlnTree(tree1);
            DoubleReduceEven(tree1);
            InfixPrintlnTree(tree1);
            WriteLine("Task 2");
            var tree2 = MkTNode(5, MkTNode(2), null);
            InfixPrintlnTree(tree2);
            MakeFullTree(ref tree2);
            InfixPrintlnTree(tree2);
            WriteLine("Task 3");
            Debug.Assert(CountLeaves(empty)==0);
            Debug.Assert(CountLeaves(MkTNode(5, MkTNode(4), MkTNode(3))) ==2);
            Debug.Assert(CountLeaves(CreateSampleIntTree1())==3);
            Debug.Assert(CountLeaves(CreateSampleIntTree2())==3);
            Debug.Assert(CountLeaves(CreateSampleIntTree3())==1);
            WriteLine("Тесты пройдены");
            WriteLine("Task 4");
            InfixPrintlnTree(CreateSampleIntTree1());
            WriteLine($"{TreeFind(CreateSampleIntTree1(),5)!=null}   {5}");
            WriteLine($"{TreeFind(CreateSampleIntTree1(), 100) != null}   {100}");
            WriteLine($"{TreeFind(CreateSampleIntTree1(), 1) != null}   {1}");
            var stree = MkTNode(5, MkTNode(6), MkTNode(5));
            WriteLine($"{TreeFind(stree, 6) != null}   {6}");
            WriteLine("Task 5");
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(stree, 2), new int[] { 6, 5 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(empty, 5), new int[] { }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateSampleIntTree1(), 3), new int[] { 4, 5 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateSampleIntTree2(), 3), new int[] {0,11,-5 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateSampleIntTree3(), 4), new int[] { -57}));
            WriteLine("Тесты пройдены");
            WriteLine("Task 6");
            (var odd,var even) = (0,0);
            CountOddEven(CreateSampleIntTree1(), out odd, out even);
            Debug.Assert(odd == 3);
            Debug.Assert(even == 2);
            ( odd, even) = (0, 0);
            CountOddEven(CreateSampleIntTree2(), out odd, out even);
            Debug.Assert(odd == 3);
            Debug.Assert(even == 3);
            (odd, even) = (0, 0);
            CountOddEven(CreateSampleIntTree3(), out odd, out even);
            Debug.Assert(odd == 3); 
            Debug.Assert(even == 1);
            WriteLine("Тесты пройдены");
            WriteLine("Task 7.1");
            WriteLine(LvlWidth(CreateSampleIntTree1(), 1));
            WriteLine(LvlWidth(CreateSampleIntTree2(), 2));
            WriteLine(LvlWidth(CreateSampleIntTree3(), 100));
            WriteLine("Task 7.2");
            WriteLine(MaxWidth(CreateSampleIntTree1()));
            WriteLine(MaxWidth(CreateSampleIntTree2()));
            WriteLine(MaxWidth(CreateSampleIntTree3()));
            WriteLine("Task 1");
            var kk = SaveFromFile("Numbers.txt");
            PrefixPrintlnTree(kk);
            WriteLine("Task 2");
            Debug.Assert(Enumerable.SequenceEqual( SaveToLL(CreateTree(1,2,3,4,5), x => x % 2 == 1),new int[] { 5,3,1}));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateTree(2,5,77,100,888,0), x => x % 2 == 1), new int[] { 77,5 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateTree(1, 2, 3, 4, 5), x => x % 2 == 0), new int[] { 4,2 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateTree(1, 2, 3, 4, 5), x => x >= 1), new int[] { 5, 4,3,2,1 }));
            Debug.Assert(Enumerable.SequenceEqual(SaveToLL(CreateTree(1, 2, 3, 4, 5), x => x > 100),new int[] { }));
            WriteLine("Тесты пройдены");
            WriteLine("Task 3");
            InfixPrintlnTree(TreeCreate(1, 2, 3, 4, 5));
            WriteLine("Extra 1");
            PrintlnTree(CreateSampleIntTree1());
            WriteLine("Extra 2");
            var t = MakeSTree("addt.txt");
            InfixPrintlnTree<Crefs>(t);
            WriteLine("Extra 4");
            var tr1 = CreateSampleIntTree4();
            InfixPrintlnTree(CreateSampleIntTree4());
            DeleteNode(ref tr1,5);
            InfixPrintlnTree(tr1);
            var tr2 = CreateSampleIntTree4();
            DeleteNode(ref tr2, 0);
            InfixPrintlnTree(tr2);
            var tr3 = CreateSampleIntTree5();
            InfixPrintlnTree(tr3);
            DeleteNode(ref tr3, 8);
            InfixPrintlnTree(tr3);
            var pr = int.MinValue;
            LocalMax(CreateSampleIntTree2(), ref pr);
            WriteLine(pr);
            WriteLine();
            InfixPrintlnTree(CreateSampleIntTree5());
            var tr6 = CreateSampleIntTree5();
            DeleteNode(ref tr6, 7);
            InfixPrintlnTree(tr6);
            InfixPrintlnTree(MkTNode(4, null, MkTNode(8, MkTNode(1))));
        }
        
    }
}


/*
 
3 6 4
3 3 2
<empty tree>
<empty tree>
3 5 -1
3 5 -1
Task 2
2 5
2 5 0
Task 3
Тесты пройдены
Task 4
2 1 4 3 5
True   5
False   100
True   1
True   6
Task 5
Тесты пройдены
Task 6
Тесты пройдены
Task 7.1
2
3
0
Task 7.2
2
3
1
Task 1
5 -55 0 66 8 88 99
Task 2
Тесты пройдены
Task 3
1 2 3 4 5
Extra 1
    2
1
        4
    3
        5
Extra 2
Lines: 0 3 , word: бабуин;  Lines: 0 1 3 , word: бедуин;  Lines: 0 1 2 3 , word: Илья;  Lines: 0 1 3 , word: корова;  Lines: 0 3 , word: кот;  Lines: 0 3 , word: собака;
Extra 4
0 1 3 4 5
0 1 3 4
1 3 4 5
4 7 1 8
4 7 1
32

4 7 1 8
4 1 8
4 1 8
 */