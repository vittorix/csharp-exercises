public class Employee : IComparable
{
   public String Name { get; set; }
   public int Id { get; set; }

   public int CompareTo(Object o )
   {
      Employee e = o as Employee; // same as: e =  (Employee) o;
      if (e == null)
         throw new ArgumentException("o is not an Employee object.");
      return Name.CompareTo(e.Name);
   }
}

public class EmployeeSearch
{
    string s;

    public EmployeeSearch(string s) {
        this.s = s;
    }

    public bool StartsWith(Employee e) {
        return e.Name.StartsWith(s, StringComparison.InvariantCultureIgnoreCase);
    }
}