namespace Lesson1.Inheritance;

public class B : A
{
    public int MyProperty { get; set; }

    public B(int number, int myProperty) : base(number)
    {
        this.MyProperty = myProperty;
    }
}