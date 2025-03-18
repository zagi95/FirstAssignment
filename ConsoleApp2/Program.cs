namespace ConsoleApp2;

class Program
{ 
    static void Main(string[] args)
    {
        var mila = CreateFamilyForGrannyMila();

        /// prebrojimo potomke
        IsTrue(CountDescendants(mila) == 13);

        var jozo = mila.Children.First(pp => pp.Name == "Jozo");
        var mara = mila.Children.First(pp => pp.Name == "Mara");

        IsTrue(CountDescendants(mila) == 13);
        IsTrue(CountDescendants(jozo) == 7);
        IsTrue(CountDescendants(mara) == 4);

        /// uzmi sve potomke
        var descendants = GetAllDescendants(mila);

        /// koliko ih ima
        IsTrue(descendants.Count == 13);

        /// koliko muških 
        IsTrue(descendants.Count(ac => ac.Gender == Gender.Male) == 6);

        /// koliko ženskih
        IsTrue(descendants.Count(ac => ac.Gender == Gender.Female) == 7);

        /// zbroj godina svih potomaka
        IsTrue(descendants.Sum(ac => ac.Age) == 331);

        Console.ReadKey();
    }

    private static void IsTrue(bool exp)
    { 
        if (exp) 
            Console.WriteLine("OK");
        else 
            Console.WriteLine("ERR");
    }
    private static Person CreateFamilyForGrannyMila()
    {
        var mila = new Person("Mila", Gender.Female);
        mila.Age = 89;

        /// Mila djeca
        var jozo = new Person("Jozo", Gender.Male); 
        jozo.Age = 62;
        jozo.Mother = mila;

        var mara = new Person("Mara", Gender.Female);
        mara.Age = 59;
        mara.Mother = mila;

        /// jozo djeca
        var ivana = new Person("Ivana", Gender.Female);
        ivana.Age = 38;
        ivana.Father = jozo;

        var marko = new Person("Marko", Gender.Male);
        marko.Age = 36;
        marko.Father = jozo;

        var janko = new Person("Janko", Gender.Male);
        janko.Age = 36;
        janko.Father = jozo;

        /// mara djeca
        var sara = new Person("Sara", Gender.Female);
        sara.Age = 33;
        sara.Mother = mara;

        var tomislav = new Person("Tomislav", Gender.Male);
        tomislav.Age = 30;
        tomislav.Mother = mara;

        /// ivana djeca
        var petar = new Person("Petar", Gender.Male);
        petar.Age = 7;
        petar.Mother = ivana;

        /// marko djeca
        var željko = new Person("Željko", Gender.Male);
        željko.Age = 11;
        željko.Father = marko;

        /// janko djeca
        var tea = new Person("Tea", Gender.Female);
        tea.Age = 6;
        tea.Father = janko;

        var petra = new Person("Petra", Gender.Female);
        petra.Age = 3;
        petra.Father = janko;

        /// sara djeca
        var marija = new Person("Marija", Gender.Female);
        marija.Age = 1;
        marija.Mother = sara;

        // tomislav djeca
        var nina = new Person("Nina", Gender.Female);
        nina.Age = 9;
        nina.Father = tomislav;

        return mila;      
    }

    private static int CountDescendants(Person pers)
    {
        int count = 0;
        Stack<Person> stack = new Stack<Person>();
        stack.Push(pers);
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            count += current.Children.Count;
            foreach (var child in current.Children)
            {
                stack.Push(child);
            }
        }

        return count;
    }

    private static List<Person> GetAllDescendants(Person pers)
    {
        List<Person> result = new List<Person>();
        Stack<Person> stack = new Stack<Person>();
        
        stack.Push(pers);
        
        while (stack.Count > 0)
        {
            var current = stack.Pop();
            
            foreach (var child in current.Children)
            {
                result.Add(child);
                stack.Push(child);
            }
        }
        Console.WriteLine(result.Count);
        return result;
    }
}