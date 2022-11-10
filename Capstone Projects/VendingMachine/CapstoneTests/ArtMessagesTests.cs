using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Capstone;

namespace CapstoneTests
{
    [TestClass]
    public class ArtMessagesTests
    {
        [TestMethod("The ItemMessage() method should return 'Crunch crunch, Yum!' if given the location of a 'chip' item")]
        public void ItemMessage_ChipStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "A1";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Crunch Crunch, Yum!", result);
        }

        [TestMethod("The ItemMessage() method should return 'Chew Chew, Yum!' if given the location of a 'gum' item")]
        public void ItemMessage_GumStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "D4";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Chew Chew, Yum!", result);
        }

        [TestMethod("The ItemMessage() method should return 'Glug Glug, Yum!' if given the slot location of a 'drink' item")]
        public void ItemMessage_DrinkStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "C3";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Glug Glug, Yum!", result);
        }

        [TestMethod("The ItemMessage() method should return 'Munch Munch, Yum!' if given the location of a 'candy' item")]
        public void ItemMessage_CandyStringTest()
        {
            Inventory menu = new Inventory();
            Item item = new Item();
            ArtMessages art = new ArtMessages();
            Inventory.GetMenu();
            string testInput = "B2";

            //Act
            string result = art.ItemMessage(testInput);

            //Assert
            Assert.AreEqual("Munch Munch, Yum!", result);
        }
    }
}
