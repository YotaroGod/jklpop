namespace ArrayPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INTEGER TEST CASES:\n\nAdding items...\n");
            var arrayInt = new ExtendedArray<int>();
            arrayInt.Add(0);
            arrayInt.Add(35);
            arrayInt.Add(2);
            arrayInt.Add(8);
            arrayInt.Add(3);

            Console.WriteLine("\nOriginal array: " + arrayInt.ToString());

            Console.WriteLine();
            arrayInt.Remove(2);
            Console.WriteLine("Array after removing: " + arrayInt.ToString());

            Console.WriteLine();
            arrayInt.Sort();
            Console.WriteLine("Array after sorting: " + arrayInt.ToString());

            Console.WriteLine();
            arrayInt.Reverse();
            Console.WriteLine("Array after reverse: " + arrayInt.ToString());

            Console.WriteLine();
            arrayInt.ForEach(p => p + 1);
            Console.WriteLine("Increasing all elements by +1: " + arrayInt.ToString());

            Console.WriteLine("\nChecking other methods...");

            Console.WriteLine();
            Console.WriteLine($"Amount of elements greater than 5: {arrayInt.Count(p => p > 5)}");
            Console.WriteLine($"Array contains '8': {arrayInt.Contains(8)}");
            Console.WriteLine($"Array contains '9': {arrayInt.Contains(9)}");
            Console.WriteLine($"Element greater than 5 found: {arrayInt.TryGet(p => p > 5, out int result)}");
            Console.WriteLine($"First element greater than 5: {result}");

            Console.WriteLine($"Maximum value in the array: {arrayInt.GetMax()}");
            Console.WriteLine($"Minimum value in the array: {arrayInt.GetMin()}");

            Console.Write("Elements greater than 6: ");
            foreach (var item in arrayInt.Select(p => p > 6))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("GetRange(1,2): ");
            foreach (var item in arrayInt.GetRange(1, 2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("GetRange(0,3): ");
            foreach (var item in arrayInt.GetRange(0, 3))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\n\n");



            Console.WriteLine("STRING TEST CASES:\n\nAdding items...\n");
            var arrayString = new ExtendedArray<string>();
            arrayString.Add("apple");
            arrayString.Add("banana");
            arrayString.Add("cherry");
            arrayString.Add("date");
            arrayString.Add("grape");

            Console.WriteLine("\nOriginal array: " + arrayString.ToString());

            Console.WriteLine();
            arrayString.Remove("cherry");
            Console.WriteLine("Array after removing: " + arrayString.ToString());

            Console.WriteLine();
            arrayString.Sort();
            Console.WriteLine("Array after sorting: " + arrayString.ToString());

            Console.WriteLine();
            arrayString.Reverse();
            Console.WriteLine("Array after reverse: " + arrayString.ToString());

            Console.WriteLine();
            Console.WriteLine("Checking other methods...");

            Console.WriteLine();
            Console.WriteLine($"Amount of elements containing 'a': {arrayString.Count(p => p.Contains("a"))}");
            Console.WriteLine($"Array contains 'banana': {arrayString.Contains("banana")}");
            Console.WriteLine($"Array contains 'kiwi': {arrayString.Contains("kiwi")}");
            Console.WriteLine($"Element containing 'a' found: {arrayString.TryGet(p => p.Contains("a"), out string resultS)}");
            Console.WriteLine($"First element containing 'a': {resultS}");

            Console.WriteLine($"Maximum value in the array: {arrayString.GetMax()}");
            Console.WriteLine($"Minimum value in the array: {arrayString.GetMin()}");

            Console.Write("Elements containing 'e': ");
            foreach (var item in arrayString.Select(p => p.Contains("e")))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("GetRange(1,2): ");
            foreach (var item in arrayString.GetRange(1, 2))
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            Console.Write("GetRange(0,3): ");
            foreach (var item in arrayString.GetRange(0, 3))
            {
                Console.Write(item + " ");
            }

            Console.WriteLine("\n\n\n");



            Console.WriteLine("HUMAN TEST CASES:\n\nAdding items...\n");

            var arrayHuman = new ExtendedArray<Human>();

            arrayHuman.Add(new Adult { Name = "Kara", Age = 25 });
            arrayHuman.Add(new Adult { Name = "Luthor", Age = 32 });
            arrayHuman.Add(new Adult { Name = "Ralph", Age = 26 });
            arrayHuman.Add(new Child { Name = "Alice", Age = 8 });

            Console.WriteLine("\nOriginal array:");
            Console.WriteLine(arrayHuman.ToString());

            Console.WriteLine();
            arrayHuman.Remove(arrayHuman.Select(p => p.Name == "Ralph").First());
            Console.WriteLine("Array after removing:");
            Console.WriteLine(arrayHuman.ToString());

            Console.WriteLine();
            arrayHuman.Sort();
            Console.WriteLine("Array after sorting by age:");
            Console.WriteLine(arrayHuman.ToString());

            Console.WriteLine();
            arrayHuman.Reverse();
            Console.WriteLine("Array after reverse:");
            Console.WriteLine(arrayHuman.ToString());

            Console.WriteLine();
            Console.WriteLine("Checking other methods...");

            Console.WriteLine();
            Console.WriteLine($"Amount of people older than 25: {arrayHuman.Count(p => p.Age > 25)}");
            Console.WriteLine($"Array contains a person named 'Alice': {arrayHuman.Contains(arrayHuman.Select(p => p.Name == "Alice").First())}");
            Console.WriteLine($"Array contains a person named 'Connor': {arrayHuman.Contains(arrayHuman.Select(p => p.Name == "Connor").FirstOrDefault())}");
            Console.WriteLine($"Person older than 23 found: {arrayHuman.TryGet(p => p.Age > 23, out var resultP)}");
            Console.WriteLine($"First person older than 23: {resultP}");

            Console.WriteLine($"Oldest person in the array: {arrayHuman.GetMax()}");
            Console.WriteLine($"Youngest person in the array: {arrayHuman.GetMin()}");

            Console.Write("People with names longer than 4 characters: ");
            foreach (var person in arrayHuman.Select(p => p.Name.Length > 4))
            {
                Console.Write($"{person} ");
            }
            Console.WriteLine();

            Console.Write("GetRange(1,2): ");
            foreach (var person in arrayHuman.GetRange(1, 2))
            {
                Console.Write($"{person} ");
            }
            Console.WriteLine();

            Console.Write("GetRange(0,2): ");
            foreach (var person in arrayHuman.GetRange(0, 2))
            {
                Console.Write($"{person} ");
            }
            Console.WriteLine();

            Console.Write("Projecting names: ");
            IEnumerable<string> names = arrayHuman.Project(p => p.Name);
            foreach (string name in names)
            {
                Console.Write(name+" ");
            }
            Console.WriteLine();

            Console.Write("Get only adults: ");
            IEnumerable<Adult> adults = arrayHuman.GetElementsOfType<Adult>();
            foreach (Adult adult in adults)
            {
                Console.Write(adult+" ");
            }
            Console.WriteLine();

            Console.WriteLine("\n\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
