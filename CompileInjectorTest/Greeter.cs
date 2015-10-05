using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompileInjector
{
    [RegisterService]
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

    [RegisterService]
    public class MessageGreeter
    {
        public string GetMessage()
        {
            return "foo";
        }
    }

    public class RegisterServiceAttribute : Attribute
    {

    }
}
