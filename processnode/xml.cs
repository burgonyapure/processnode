using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace processnode
{
    class xml
    {
        public static void writeXml() {
            Console.WriteLine(new XElement("Foo",new XAttribute("Bar", "some & value"),new XElement("Comment", "data")));
        }
    }
}
<Foo Bar = "some &amp; value" >
  < Nested > data </ Nested >
</ Foo >