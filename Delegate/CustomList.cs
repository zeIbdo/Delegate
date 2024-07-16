using System.Collections;

namespace Delegate;

public class CustomList<T>:IEnumerable<T>
{
    private T[] arr;
    public CustomList()
    {
        arr = new T[0];

    }
    public void Add(T item)
    {
        Array.Resize(ref arr, arr.Length+1);
        arr[arr.Length - 1] = item;
    }
    public T this[int index] { get => arr[index]; set => arr[index] = value;}
    public bool Remove(T item)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if(arr[i].Equals(item))
            {
                for(int j = i; j < arr.Length-1; j++)
                {
                    arr[j] = arr[j+1];
                }
                Array.Resize(ref arr, arr.Length-1);
                return true;
            }
            else return false;                
        }
        return false;
    }
    public T? Find(Predicate<T> predicate)
    {
        foreach(T item in  arr)
        {
            if (predicate(item))
            {
                return item;
            }
        }
        return default(T);
    }
    public CustomList<T> FindAll(Predicate<T> predicate)
    {
        CustomList<T> list = new CustomList<T>();
        foreach(T item in arr)
        {
            if(predicate(item)==true)
                list.Add(item);

        }
        return list;
    }
    public int RemoveAll(Predicate<T> predicate)
    {
        int count = 0;
        for(int i = 0; i < arr.Length; i++)
        {
            if(predicate(arr[i]) == true)
            {
                count++;
                for(int j = i; j < arr.Length - 1; j++)
                {
                    arr[j] = arr[j+1];
                }
                Array.Resize(ref arr,arr.Length-1);
            }
        }
        return count;
    }
    public void Clear()
    {
        arr = new T[0];
    }
    public int Count
    {
        get => arr.Length;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < arr.Length; i++)
        {
            yield return arr[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
