using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileInjector
{
    public class Greeter
    {
        private MessageGreeter messageGreeter;

        public Greeter(MessageGreeter m)
        {
            messageGreeter = m;
        }

        public string GetMessage()
        {
            return messageGreeter.GetMessage();
        }
    }


    public class MessageGreeter
    {
        public string GetMessage()
        {
            return "foo";
        }
    }
}
