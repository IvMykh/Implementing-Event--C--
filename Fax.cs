using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPractice
{
	class Fax
	{
		private readonly String faxId_;
		private readonly StreamWriter streamToWrite_;

		public String FaxId
		{
			get { return faxId_; }
		}

		public Fax(String faxId, StreamWriter streamToWrite, MailManager mm)
		{
			streamToWrite_ = streamToWrite;
			faxId_ = faxId;
			mm.NewMail += FaxMsg;
		}

		public void Register(MailManager mm)
		{
			mm.NewMail += FaxMsg;
		}

		public void Unregister(MailManager mm)
		{
			mm.NewMail -= FaxMsg;
		}

		private void FaxMsg(Object sender, NewMailEventArgs e)
		{
			streamToWrite_.WriteLine("Faxing mail message by fax \"{0}\"", FaxId);
			streamToWrite_.WriteLine("\tFrom: {0}", e.MailFrom);
			streamToWrite_.WriteLine("\tTo: {0}", e.MailTo);
			streamToWrite_.WriteLine("\tMail subject: {0}\n", e.MailSubject);
		}
	}
}