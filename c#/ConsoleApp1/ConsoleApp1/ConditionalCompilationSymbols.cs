using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordsTest
{
    internal class ConditionalCompilationSymbols
    {

        public void Test() {

            Console.WriteLine("BEGIN");
#if DEBUG
            Console.WriteLine("DEBUG");
#endif

#if RELEASE
            Console.WriteLine("Release");
#endif

#if UAT
            Console.WriteLine("TestSymbol");
#endif

        }
    }
}
