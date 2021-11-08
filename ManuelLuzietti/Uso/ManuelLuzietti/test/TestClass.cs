using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uso.ManuelLuzietti.osu.controller;
using Uso.ManuelLuzietti.osu.util;

namespace Uso.ManuelLuzietti.test
{


    [TestClass]
    public class TestClass
    {

        [TestMethod]
        public void Test1()
        {
            BeatmapReader reader = new BeatmapReader(Properties.Resources.Imagine_Dragons___Warriors);
            reader.GetHitpoints().ForEach(x => Console.WriteLine(x.ToString()));
            reader.GetOptionMap(ManuelLuzietti.osu.util.BeatmapReader.BeatmapOptions.General).ToList().ForEach(x => Console.WriteLine(x.ToString()));
        }

        [TestMethod]
        public void test2()
        {
            ScoreManager manager = new ScoreManager(new osu.model.Score());
            Assert.AreEqual(manager.GetPoints(), 0);
            manager.Hit(osu.model.GamePoints.gamePoints.OK);
            Assert.AreEqual(manager.GetPoints(), 50);
            Assert.AreEqual(manager.GetMultiplier(), 1);
            manager.Missed();
            Assert.AreEqual(manager.GetPoints(), 50);
            Assert.AreEqual(manager.GetMultiplier(), 0);
            for(int i = 0; i < 10; i++)
            {
                manager.Hit(osu.model.GamePoints.gamePoints.GREAT);
            }
            Assert.AreEqual(manager.GetMultiplier(), 10);
        }
    }
}
