using System.Collections;
using System.Diagnostics;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        int listSize = 100000; 
        int elementsToInsert = 1000; 
        Random random = new Random();

        ArrayList arrayList = new ArrayList();
        LinkedList<int> linkedList = new LinkedList<int>();

        Stopwatch stopwatch = new Stopwatch();

        // Заповнення ArrayList

        Console.WriteLine("Заповнення списків:");
        stopwatch.Start();

        for (int i = 0; i < listSize; i++)
        {
            arrayList.Add(random.Next(0, listSize));
        }
        stopwatch.Stop();

        Console.WriteLine($"ArrayList Заповнення: {stopwatch.ElapsedMilliseconds} ms");

        // Заповнення LinkedList

        stopwatch.Restart();

        for (int i = 0; i < listSize; i++)
            { 
            linkedList.AddLast(random.Next(0, listSize)); 
        }
        stopwatch.Stop();

        Console.WriteLine($"LinkedList Заповнення: {stopwatch.ElapsedMilliseconds} ms");

        //Доступ за індексом
        
        Console.WriteLine("\nДоступ до елементів за індексом:");
        
        stopwatch.Restart();
        
        for (int i = 0; i < listSize; i++)
        {
            var value = arrayList[random.Next(0, listSize)];
        }
        stopwatch.Stop();

        Console.WriteLine($"ArrayList Random Access(Доступ за індексом): {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();

        for (int i = 0; i < listSize; i++)
        {
            var node = linkedList.First;
            for (int j = 0; j < random.Next(0, listSize); j++)
            { 
                node = node.Next; 
            }
        }
        stopwatch.Stop();

        Console.WriteLine($"LinkedList Random Access (Доступ за індексом): {stopwatch.ElapsedMilliseconds} мс");

        // Доступ за ітератором

        Console.WriteLine("\nПослідовний доступ:");
        stopwatch.Restart();

        foreach (var item in arrayList) 
        { 
            var temp = item; 
        }

        stopwatch.Stop();
        Console.WriteLine($"ArrayList Sequential Access(Доступ за ітератором): {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();

        foreach (var item in linkedList) 
        { 
            var temp = item; 
        }

        stopwatch.Stop();
        Console.WriteLine($"LinkedList Sequential Access(Доступ за ітератором): {stopwatch.ElapsedMilliseconds} мс");

        // Вставка на початок списку

        Console.WriteLine("\nВставка на початок:");
        stopwatch.Restart();

        for (int i = 0; i < elementsToInsert; i++)
        {
            arrayList.Insert(0, random.Next());
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList Вставка на початок: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();

        for (int i = 0; i < elementsToInsert; i++)
        {
            linkedList.AddFirst(random.Next());
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList Вставка на початок: {stopwatch.ElapsedMilliseconds} мс");

        // Вставка в кінець списку

        Console.WriteLine("\nВставка в кінець:");
        stopwatch.Restart();

        for (int i = 0; i < elementsToInsert; i++)
        {
            arrayList.Add(random.Next());
        }
        stopwatch.Stop();
        Console.WriteLine($"ArrayList Вставка в кінець: {stopwatch.ElapsedMilliseconds} мс");

        stopwatch.Restart();

        for (int i = 0; i < elementsToInsert; i++)
        {
            linkedList.AddLast(random.Next());
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList Вставка в кінець: {stopwatch.ElapsedMilliseconds} мс");

        // Вставка в середину списку

        Console.WriteLine("\nВставка в середину:");
        stopwatch.Restart();

        for (int i = 0; i < elementsToInsert; i++)
        {
            arrayList.Insert(arrayList.Count / 2, random.Next());
        }    
            
        stopwatch.Stop();
        Console.WriteLine($"ArrayList Вставка в середину: {stopwatch.ElapsedMilliseconds} мс");
        stopwatch.Restart()
            ;
        for (int i = 0; i < elementsToInsert; i++)
        {
            var middleNode = GetNodeAt(linkedList, linkedList.Count / 2);
            linkedList.AddAfter(middleNode, random.Next());
        }
        stopwatch.Stop();
        Console.WriteLine($"LinkedList Вставка в середину: {stopwatch.ElapsedMilliseconds} мс");
    }

    //Отримання вузла в LinkedList за індексом
    static LinkedListNode<int> GetNodeAt(LinkedList<int> list, int index)
    {
        var current = list.First;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current;
    }
}