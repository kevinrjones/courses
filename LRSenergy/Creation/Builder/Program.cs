using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new SmtpBuilder();
            var mail = builder.AddTo("kevin@rocksolidknowledge.com")
                .SetSubject("Hello")
                .SetBody("How's it going")
                .SetFrom("andy@rocksolidknowledge.com")
                .Build();

            Console.WriteLine("{0} : {1}", mail.From, mail.To);

            var b1 = builder.SetFrom("kevin@rocksolidknowledge.com");

            SendMail(b1, "andy@rocksolidknowledge.com", "Hello", "Body");
        }

        private static void SendMail(MailBuilder mailBuilder, string to, string subject, string body)
        {
            mailBuilder.AddTo(to).SetBody(body).SetSubject(subject).Build().Send();
        }
    }

    public abstract class MailBuilder
    {
        public abstract MailBuilder SetFrom(string name);
        public abstract MailBuilder SetBody(string body);
        public abstract MailBuilder SetSubject(string subject);
        public abstract MailBuilder AddTo(string name);
        public abstract MailBuilder AddCC(string name);
        public abstract MailBuilder AddAttachment(string filename);

        public abstract Mail Build();
    }

    public class SmtpBuilder : MailBuilder
    {
        private string _from;
        private string _filename;
        private string _body;
        private string _subject;
        private string _to;
        private string _cc;

        public override MailBuilder SetFrom(string from)
        {
            _from = from;
            return this;
        }

        public override MailBuilder SetBody(string body)
        {
            this._body = body;
            return this;
        }

        public override MailBuilder SetSubject(string subject)
        {
            this._subject = subject;
            return this;
        }

        public override MailBuilder AddTo(string to)
        {
            this._to = to;
            return this;
        }

        public override MailBuilder AddCC(string cc)
        {
            this._cc = cc;
            return this;
        }

        public override MailBuilder AddAttachment(string filename)
        {
            this._filename = filename;
            return this;
        }

        public override Mail Build()
        {
            return new SmtpMail(_to, _from);
        }
    }

    public abstract class Mail
    {
        public string To { get; set; }
        public string From { get; set; }

        public abstract void Send();
    }

    public class SmtpMail : Mail
    {
        public SmtpMail(string to, string from)
        {
            To = to;
            From = from;
        }

        public override void Send()
        {
            Console.WriteLine("Sent");
        }
    }
}
