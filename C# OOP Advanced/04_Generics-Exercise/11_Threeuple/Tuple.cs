public class Tuple<T1, T2, T3>
{
    public Tuple(T1 firstItem, T2 secondItem, T3 thirdItem)
    {
        FirstItem = firstItem;
        SecondItem = secondItem;
        ThirdItem = thirdItem;
    }

    public T1 FirstItem { get; set; }

    public T2 SecondItem { get; set; }

    public T3 ThirdItem { get; set; }

    public override string ToString()
    {
        return $"{FirstItem} -> {SecondItem} -> {ThirdItem}";
    }
}
