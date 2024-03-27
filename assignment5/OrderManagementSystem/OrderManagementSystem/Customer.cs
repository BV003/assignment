using System.Collections.Generic;

public class Customer
{
    public string Name { get; set; }
    public string Contact { get; set; }
    public List<Order> Orders { get; set; } = new List<Order>();

    public Customer(string name, string contact)
    {
        Name = name;
        Contact = contact;
    }

    public override bool Equals(object obj)
    {
        if (obj is Customer other)
        {
            return Name == other.Name && Contact == other.Contact;
        }
        return false;
    }

    public override int GetHashCode()
    {
        int hash = 17;
        unchecked
        {
            hash = hash * 23 + (Name != null ? Name.GetHashCode() : 0);
            hash = hash * 23 + (Contact != null ? Contact.GetHashCode() : 0);
        }
        return hash;
    }

    public override string ToString()
    {
        return $"Customer Name: {Name}, Contact: {Contact}";
    }
}
