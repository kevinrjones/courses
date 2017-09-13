using System;
using System.Windows.Forms;

namespace Failing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            throw new SpanishException("Nobody expects this!");
        }
    }

    [global::System.Serializable]
    public class SpanishException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public SpanishException() { }
        public SpanishException(string message) : base(message) { }
        public SpanishException(string message, Exception inner) : base(message, inner) { }
        protected SpanishException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
