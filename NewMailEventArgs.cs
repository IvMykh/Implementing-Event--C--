using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPractice
{
	class NewMailEventArgs
		  : EventArgs
	{
		private readonly String mailFrom;
		private readonly String mailTo;
		private readonly String mailSubject;

		public NewMailEventArgs(String mf, String mt, String ms)
		{
			mailFrom = mf;
			mailTo = mt;
			mailSubject = ms;
		}

		public String MailFrom
		{
			get { return mailFrom; }
		}

		public String MailTo
		{
			get { return mailTo; }
		}

		public String MailSubject
		{
			get { return mailSubject; }
		}
	}
}