namespace ConsoleApp2;

public class Person
{
    public string Name { get; private set; }
    public Gender Gender { get; private set; }
    private Person father = null;
    public Person Father
    {
        get
        {
            return this.father;
        }

        set
        {
            this.father = value;
            value.Children.Add(this);
        }
    }
    private Person mother = null;

    public Person Mother
    {
        get
        {
            return this.mother;
        }
        set
        {
            this.mother = value;
            value.Children.Add(this);
        }
    }
    public int Age { get; set; }
    public List<Person> Children { get; private set; }

    public Person(string name, Gender gender)
    {
        this.Name = name;
        this.Gender = gender;
        this.Age = 0;
        this.Children = new List<Person>();
    }
}

public enum Gender { Male, Female }