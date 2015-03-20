using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPractice
{
	class Printer
	{
		private readonly String printerId_;
		private readonly StreamWriter streamToWrite_;

		public String PrinterId
		{
			get { return printerId_; }
		}

		public Printer(String printerId, StreamWriter streamToWrite, MailManager mm)
		{
			streamToWrite_ = streamToWrite;
			printerId_ = printerId;
			mm.NewMail += PrintMsg;
		}

		public void Register(MailManager mm)
		{
			mm.NewMail += PrintMsg;
		}

		public void Unregister(MailManager mm)
		{
			mm.NewMail -= PrintMsg;
		}

		private void PrintMsg(Object sender, NewMailEventArgs e)
		{
			streamToWrite_.WriteLine("Printing mail message by printer \"{0}\"", PrinterId);
			streamToWrite_.WriteLine("\tFrom: {0}", e.MailFrom);
			streamToWrite_.WriteLine("\tTo: {0}", e.MailTo);
			streamToWrite_.WriteLine("\tMail subject: {0}\n", e.MailSubject);
		}
	}
}