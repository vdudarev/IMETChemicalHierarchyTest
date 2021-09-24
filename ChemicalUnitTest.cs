using System;
using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IMETlib.Chemistry;

namespace ChimicalHierarchyTest
{
    [TestClass]
    public class ChemicalUnitTest
    {
        [TestMethod]
        public void TestSystem()
        {
            XmlNode InXmlNode = null;
            int NumElements = 0;
            string mySystemXML = "LiNbO<sub>3</sub>";
            string mySystemString = "";
            string resp = "";
            int ret = REFACTOR_ChemicalUtils.GetSystemStringByDescription(2, ref InXmlNode, ref NumElements, ref mySystemXML, ref mySystemString, ref resp);

            Assert.AreEqual(ret, 0);
            Assert.AreEqual(mySystemXML, "<ChemicalSystem><Element>Li</Element><Element>Nb</Element><Element>O</Element></ChemicalSystem>");
            Assert.AreEqual(mySystemString, "-Li-Nb-O-");

        }



        [TestMethod]
        public void TestSubstance()
        {
            string html = "LiNbO<sub>3</sub>";
            string substanceXML;
            string substanceString = REFACTOR_ChemicalUtils.GetSubstanceStringByHtml(html, out substanceXML);
            
            Assert.AreEqual(substanceXML, "<ChemicalSubstanceComposition><Item Element=\"Li\" value=\"1\" /><Item Element=\"Nb\" value=\"1\" /><Item Element=\"O\" value=\"3\" /></ChemicalSubstanceComposition>");
            Assert.AreEqual(substanceString, "Li(1)Nb(1)O(3)");
        }

    }
}
