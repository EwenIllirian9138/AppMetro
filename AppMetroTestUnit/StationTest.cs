using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Librairie;
using System.Collections.Generic;

namespace AppMetroTestUnit
{
    [TestClass]
    public class StationTest
    {
        [TestMethod]
        public void TestMethod_RequestApi_WithMock()
        {
            MockFactory mockFactory = new MockFactory();
            Mock<IApiMetro> mockIApiMetro = mockFactory.CreateMock<IApiMetro>();
            mockIApiMetro.Expects.One.Method(_ => _.Request("")).WithAnyArguments().WillReturn(JsonFakeYou.JsonFake);

            mockIApiMetro.Expects.One.Method(_ => _.Request("")).WithAnyArguments().WillReturn(JsonFakeYou.JsonFake1316C4);
            mockIApiMetro.Expects.One.Method(_ => _.Request("")).WithAnyArguments().WillReturn(JsonFakeYou.JasonFake57C4C1121613);


            Station test = new Station(mockIApiMetro.MockObject);
            List<ArretAndLineDetails> result = test.Finalstatus();

            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("GRENOBLE, CASERNE DE BONNE", result[0].ArretName);

            List<ChampApiRoutes> bonne = result[0].LineDetails;
            Assert.AreEqual(3, bonne.Count);
            Assert.AreEqual("SEM:16", bonne[0].Id);
            Assert.AreEqual("SEM:C4", bonne[1].Id);
            Assert.AreEqual("SEM:13", bonne[2].Id);

            Assert.AreEqual("GRENOBLE, DOCTEUR MARTIN", result[1].ArretName);

            List<ChampApiRoutes> docteurMartin = result[1].LineDetails;
            Assert.AreEqual(6, docteurMartin.Count);
            Assert.AreEqual("SEM:12", docteurMartin[0].Id);
            Assert.AreEqual("SEM:16", docteurMartin[1].Id);
            Assert.AreEqual("SEM:57", docteurMartin[2].Id);
            Assert.AreEqual("SEM:C4", docteurMartin[3].Id);
            Assert.AreEqual("SEM:13", docteurMartin[4].Id);
            Assert.AreEqual("SEM:C1", docteurMartin[5].Id);

        }
    }
}
