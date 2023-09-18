using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//抽象聚合类 
public interface ITroopQueue<T>
{
    Iterator<T> GetIterator();
}

//迭代器抽象类
public interface Iterator<T>
{
    bool MoveNext();
    T GetCurrent();
    void Next();
    void Reset();
}

//具体聚合类
public sealed class ConcreateTroopQueue<T> : ITroopQueue<T>
{
    public T[] collection;
    public ConcreateTroopQueue(T[] ts)
    {
        collection = ts;
    }
    public Iterator<T> GetIterator()
    {
        return new ConcreateIterator<T>(this);
    }
    public int Length
    {
        get
        {
            return collection.Length;
        }
    }
    public T GetElement(int index)
    {
        return collection[index];
    }
}

//具体迭代类
public sealed class ConcreateIterator<T>: Iterator<T>
{
    //迭代器要对集合对象进行遍历操作 自然需要引用集合对象
    private ConcreateTroopQueue<T> _list;
    private int _index;
    public ConcreateIterator(ConcreateTroopQueue<T> list)
    {
        _list = list;
        _index = 0;
    }
    public T GetCurrent()
    {
        return _list.GetElement(_index);
    }

    public bool MoveNext()
    {
        if (_index < _list.Length)
        {
            return true;
        }
        return false;
    }

    public void Next()
    {
        if (_index < _list.Length)
        {
            _index++;
        }
    }

    public void Reset()
    {
        _index = 0;
    }
}

public class D_15_IteratorPattern : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Iterator<string> iterator;
        string[] ss = { "sunhao", "niuyongqiang", "liulugang", "guxinyu" };
        ITroopQueue<string> list = new ConcreateTroopQueue<string>(ss);
        iterator = list.GetIterator();

        while (iterator.MoveNext())
        {
            string ren = iterator.GetCurrent();
            Debug.Log("___" + ren);
            iterator.Next();
        }
    }

}
