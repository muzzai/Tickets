using Nest;

namespace EventCatalogService.Infrastructure;

public abstract class Document
{
  protected Document(JoinField join)
  {
    Join = join;
  }

  public JoinField Join { get; set; }
}

public class Company : Document
{
  public string Name { get; set; }
  public List<Employee> Employees { get; set; }

  public Company(JoinField join, string name, List<Employee> employees) : base(join)
  {
    Name = name;
    Employees = employees;
  }
}

public class Employee : Document
{
  public string LastName { get; set; }
  public int Salary { get; set; }
  public DateTime Birthday { get; set; }
  public bool IsManager { get; set; }
  public List<Employee> Employees { get; set; }
  public TimeSpan Hours { get; set; }

  public Employee(JoinField join, string lastName, List<Employee> employees) : base(join)
  {
    LastName = lastName;
    Employees = employees;
  }
}


