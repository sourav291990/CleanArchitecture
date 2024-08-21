namespace CleanArchitecture.Domain.ValueObjects;

using CleanArchitecture.Domain.Primitives;
public class Title : ValueObject
{
    public const int MaxValue = 50;
    public Title(string value)
    {
        Value = value;
    }
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
