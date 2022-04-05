namespace WebApiHW;

public class ValuesHolder
{
    private List<string> _values { get; set; }
    public ValuesHolder()
    {
        _values = new List<string>();
    }
    public bool Add(string value)
    {
        _values.Add(value);
        return value == _values[^1];
    }

    public string? Get(int count) => _values.Count > count ? _values[count] : null;
    public bool Delete(int count)
    {
        if (Get(count) is not null)
        {
            _values.RemoveAt(count);
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Update(int count, string str)
    {
        if (Get(count) is not null)
        {
            _values[count] = str;
            return true;
        }
        return false;
    }
}
