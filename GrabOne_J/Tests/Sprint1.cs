using GrabOne_J.Global;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrabOne_J.Tests
{
    class Sprint1
    {
        [TestFixture]
        [Category("Sprint1")]
        class Sprint1_Admin : Base
        {

            [Test]
            public void Login()
            {
                // Creates a toggle for the given test, adds all log events under it    
                test = extent.StartTest("Login test");

                // check Login functionality
                
            }

           


        }
    }
}
