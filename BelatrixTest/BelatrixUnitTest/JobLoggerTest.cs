using BelatrixTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
namespace BelatrixUnitTest
{
    using BelatrixTest;
    
    /// <summary>
    ///This is a test class for JobLoggerTest and is intended
    ///to contain all JobLoggerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class JobLoggerTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de SetLog enviando los parámetros correctos.
        ///</summary>
        [TestMethod()]
        public void SetLogTest()
        {
            JobLogger target = new JobLogger();
            var typeMessage = TypeMessage.Info;
            var lstSource = new List<Source>() ;

            var message = "Test"; 
            var expected = string.Empty;
            var actual = "";

            lstSource.Add(Source.Console);

            actual = target.SetLog(message, typeMessage, lstSource);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de SetLog enviando "Message" vacío
        ///</summary>
        [TestMethod()]
        public void SetLogTestMessage()
        {
            JobLogger target = new JobLogger();
            
            var typeMessage = TypeMessage.Info;
            var lstSource = new List<Source>();
            
            var expected = string.Empty;
            var message = "";
            var actual = "";

            lstSource.Add(Source.Console);

            actual = target.SetLog(message, typeMessage, lstSource);
            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///Una prueba de SetLog enviando la lista Source vacía
        ///</summary>
        [TestMethod()]
        public void SetLogTestSource()
        {
            JobLogger target = new JobLogger();

            var typeMessage = TypeMessage.Warning;
            var lstSource = new List<Source>();

            var expected = string.Empty;
            var message = "An error has ocurred.";
            var actual = "";
            
            actual = target.SetLog(message, typeMessage, lstSource);
            Assert.AreNotEqual(expected, actual);
        }
    }
}
