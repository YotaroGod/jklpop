using System.Text;

namespace ArrayPro
{
    
    public class ExtendedArray<T>
    {
        private T[] array;

        
        private int size = 0;
        
        
        private int Capacity => array.Length;

        public const int DefaultLength = 0;

        
        public ExtendedArray(int length)
        {
            array = new T[length];
        }

        
        public ExtendedArray() : this(DefaultLength) { }

        public void ForEach(Func<T, T> operation)
        {
            for (int i = 0; i < size; i++)
            {
                array[i] = operation(array[i]);
            }
        }

        public void Add(T item)
        {
            if (size == Capacity)
            {
                T[] newArray = new T[2 * array.Length + 1];
                array.CopyTo(newArray, 0);
                Console.WriteLine($"{nameof(Capacity)} changed from {array.Length} to {newArray.Length}");
                array = newArray;
            }
            array[size++] = item;
            Console.WriteLine($"Item added: {item}");
        }

       
        public void Remove(T item)
        {
            int index = Array.IndexOf(array, item);
            if(index == -1)
            {
                throw new InvalidOperationException($"item: {item} not in the array");
            }
            if (index >= 0)
            {
                
                for (int i = index; i < size - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[size - 1] = default(T); 
                size--; 
            }
            Console.WriteLine($"Item removed: {item}");
        }

      
        public void Sort()
        {
            CheckIfTypeImplementsIComparable();
            
            Array.Sort(array, 0, size);
            Console.WriteLine($"Array sorted");
        }
        
      
        public void Reverse()
        {
            Array.Reverse(array, 0, size);
            Console.WriteLine("Array reversed");
        }
        public bool TryGet(Func<T, bool> condition, out T result)
        {
            result = default(T);
            foreach (T item in array.Take(size))
            {
                if (condition(item))
                {
                    result = item;
                    return true; 
                }
            }
            return false;
        }

        
        public IEnumerable<T> GetRange(int index, int amount)
        {
           
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range");
            }

          
            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero", nameof(amount));
            }

           
            int endIndex = index + amount;
            if (endIndex > size)
            {
                throw new ArgumentException("index + amount cannot be greater than the size of the array");
            }

            for (int i = index; i < endIndex; i++)
            {
                yield return array[i];
            }
        }

        
        public IEnumerable<T> Select(Func<T, bool> condition)
        {
            List<T> selectedItems = new List<T>();
            foreach (T item in array.Take(size))
            {
                if (condition(item))
                {
                    selectedItems.Add(item);
                }
            }
            return selectedItems;
        }

      
        public T GetMax()
        {
            return array.Max();
        }

      
        public T GetMin()
        {
            return array.Min();
        }

        public int Count(Func<T, bool> condition)
        {
            return array.Take(size).Count(condition);
        }


        public int Count()
        {
            return size;
        }

    
        public bool Contains(T item)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

    
        public override string ToString()
        {
          
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < size; i++)
            {
                sb.Append(array[i].ToString());
                if (i < size - 1)
                {
                    sb.Append(", ");
                }
            }
            return sb.ToString();
        }

   
        public IEnumerable<TResult> Project<TResult>(Func<T, TResult> projection)
        {
            foreach (T item in array.Take(size))
            {
                yield return projection(item);
            }
        }

  
        public TResult GetMinProjected<TResult>(Func<T, TResult> projection)
        {
            return Project(projection).Min();
        }

     
        public TResult GetMaxProjected<TResult>(Func<T, TResult> projection)
        {
            return Project(projection).Max();
        }

       
        public IEnumerable<TElement> GetElementsOfType<TElement>()
        {
            List<TElement> selectedItems = new List<TElement>();
            foreach (T item in array.Take(size))
            {
                if (item is TElement element)
                {
                    selectedItems.Add(element);
                }
            }
            return selectedItems;
        }

        private void CheckIfTypeImplementsIComparable()
        {
            if (!typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
            {
                throw new InvalidOperationException($"The type {typeof(T)} does not implement IComparable<T>.");
            }
        }
    }
}
