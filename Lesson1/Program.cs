{
    int number = 0;
    string text = "Text: " + number + ".";
    string textWithDollar = $"Text: {number}.";

    var k = "text";

//nullable 
    int? nullableInt = null;
    nullableInt = 10;
    Object? o = null;
}

{
    var list = new List<int>();
    list.Add(10);
    
    var dict = new Dictionary<string, int>();
    dict.Add("one", 1);
}
{
    try
    {
        throw new Exception();
    }
    catch (Exception e)
    {
        
    }
}
