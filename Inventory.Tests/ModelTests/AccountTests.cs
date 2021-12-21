using Inventory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Inventory.Tests
{
  [TestClass]
  public class AccountTests : IDisposable
  {
    public void Dispose()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM accounts";
      cmd.ExecuteNonQuery();
      conn.Close();
      if(conn != null)
      {
        conn.Dispose();
      }
    }
    public AccountTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=epicodus;port=3306;database=accounts_and_inventories_test;";
    }

    [TestMethod]
    public void RequestInventoryFromDB_returnsAnEmptyListIfTheAccountHasNoItems_List()
    {
      Account player = new Account("test");
      List<Item> testList = new List<Item> {};

      CollectionAssert.AreEqual(testList, player.RequestInventoryFromDB());
    }
    
    [TestMethod]
    public void Add_AddsANewAccountToDatabase_Account()
    {
      Account player = new Account("player");
      Account test = Account.Load(0);

      Assert.AreEqual(player, test);
    }

    [TestMethod]
    public void Load_ReturnsNullIfNoAccountAtId_Null()
    {
      Assert.AreEqual(null, Account.Load(0));
    }

    [TestMethod]
    public void Load_LoadsAccountFromDatabase_Account()
    {
      Account playerZero = new Account("playerZero");
      Account playerOne = new Account("playerOne");
      Assert.AreEqual(playerOne, Account.Load(1));
    }

    // [TestMethod]
    // public void Save_SavesAccountToDatabase_Account()
    // {

    // }
  }
}