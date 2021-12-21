namespace Inventory.Models
{
  public class Item
  {
    public string Name {get;}
    public int Id {get;}
    public Item(string name, int id)
    {
      Name = name;
      Id = id;
    }
  }
}