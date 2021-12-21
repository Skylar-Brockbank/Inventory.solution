//Account Properties

//Name
//Items
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace Inventory.Models
{
  public class Account
  {
    public string Name {get;}
    public int ID {get;}
    public List<Item> PlayerInventory {get; set;} = new List<Item> {};
    public Account(string name)
    {
      Name = name;
      Account existing = Load(name);
      if (existing != null)
      {
        ID = existing.ID;
      }
      else
      {
        ID = Add();
      }
      PlayerInventory = RequestInventoryFromDB();
    }

    public Account(string name, int id)
    {
      Name = name;
      ID = id;
    }

    public override bool Equals(System.Object otherAccount)
    {
      if (!(otherAccount is Account))
      {
        return false;
      }
      else
      {
        Account castAccount = (Account) otherAccount;
        bool nameEquality = (this.Name == castAccount.Name);
        bool idEquality = (this.ID == castAccount.ID);
        return (nameEquality && idEquality);
      }
    }
    
    public int Add()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO accounts (name) VALUES (@Name);";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = Name;
      cmd.Parameters.Add(name);
      cmd.ExecuteNonQuery();
      int id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return id;
    }

    public List<Item> RequestInventoryFromDB()
    {
      List<Item> output = new List<Item> {};
      return output;
    }

    public static Account Load(string nameToLoad)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM accounts WHERE name = @Name;";
      MySqlParameter name = new MySqlParameter();
      name.ParameterName = "@Name";
      name.Value = nameToLoad;
      cmd.Parameters.Add(name);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int loadedId = 0;
      string loadedName = "";
      while(rdr.Read())
      {
        loadedId = rdr.GetInt32(0);
        loadedName = rdr.GetString(1);
      }
      Account foundAcct = new Account(loadedName, loadedId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      if (foundAcct.Name == "")
      {
        return null;
      }
      else
      {
      return foundAcct;
      }
    }

    public static Account Load(int idToLoad)
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM accounts WHERE id = @Id;";
      MySqlParameter eyedee = new MySqlParameter("@Id", idToLoad);
      cmd.Parameters.Add(eyedee);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int loadedId = 0;
      string loadedName = "";
      while(rdr.Read())
      {
        loadedId = rdr.GetInt32(0);
        loadedName = rdr.GetString(1);
      }
      Account foundAcct = new Account(loadedName, loadedId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      if (foundAcct.Name == "")
      {
        return null;
      }
      else
      {
      return foundAcct;
      }
    }

    public void Save()
    {
      
    }
  }
}