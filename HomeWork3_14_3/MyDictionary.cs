using System.Collections;

namespace HomeWork3_14_3;

public class MyDictionary<T1, T2> : IEnumerable<KeyValuePair<T1, T2>> {

    private List<T1> _keys = new List<T1>();
    private List<T2> _values = new List<T2>();

    public void Add(T1 key, T2 value) {
        _keys.Add(key);
        _values.Add(value);
    }

    public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator() {
        var u = new MyDictionaryEnumerator<T1, T2>(this);
        return u;
    }

    IEnumerator IEnumerable.GetEnumerator() {
        return GetEnumerator();
    }

    public KeyValuePair<T1, T2> GetKeyAndValueByIndex (int index) {
        return new KeyValuePair<T1, T2>(_keys[index], _values[index] );
    }

    public int DictionaryCount {
        get { return _keys.Count; }
    }

    public T2 this[T1 index] {
        get {
            var indexlast = _keys.IndexOf(index);
            if (indexlast >= 0) {
                return _values[indexlast];
            } else {
                throw new Exception("The key is not found in the MyDictionary");
            }
        }
    }

}

public class MyDictionaryEnumerator<T1, T2> : IEnumerator<KeyValuePair<T1, T2>> {
    public KeyValuePair<T1, T2> _corrent;
    public KeyValuePair<T1, T2> Current {
        get {
            return _corrent;
        }
        set {
            _corrent = value;
        }
    }

    object IEnumerator.Current { get { return Current; } }

    private MyDictionary<T1, T2> _list;
    private int _innerIndex;

    public MyDictionaryEnumerator(MyDictionary<T1, T2> list)  {
        _list = list;
        Reset();
    }

    public void Dispose() {
    }

    public bool MoveNext() {
        if (_list.DictionaryCount > (_innerIndex + 1)){
            _innerIndex++;
            Current = _list.GetKeyAndValueByIndex(_innerIndex);
            return true;
        }else {
            return false;
        }
    }

    public void Reset() {
        _innerIndex = -1;
    }
}

