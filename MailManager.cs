using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPractice
{
	class MailManager
	{
		private static readonly MailManager instance_;

		protected MailManager()
		{ 
		}

		static MailManager()
		{
			instance_ = new MailManager();
			Console.WriteLine("Single instance of MailManager has been created");
		}

		public static MailManager Instance
		{
			get { return instance_; }
		}

		protected virtual void OnNewMail(NewMailEventArgs e)
		{
			if (NewMail != null)
			{
				NewMail(this, e);
			}
		}

		public event EventHandler<NewMailEventArgs> NewMail;

		private String ReadEventArg(StreamReader reader)
		{
			String textLine = reader.ReadLine();
			if (textLine != null)
			{
				String[] splitData = textLine.Split();
				if (splitData.Length != 3)
				{
					throw new FormatException("Incorrect format of input in file");
				}

				return splitData[2];
			}
			else 
			{
				throw new EndOfStreamException("The end of the file has been reached");
			}
			
		}

		public void SimulateNewMail(StreamReader reader)
		{
			try
			{
				reader.ReadLine();
				String mailFrom = ReadEventArg(reader);
				String mailTo = ReadEventArg(reader);
				String mailSubject = ReadEventArg(reader);
				reader.ReadLine();
				
				var e = new NewMailEventArgs(mailFrom, mailTo, mailSubject);
				OnNewMail(e);
			}
			catch (EndOfStreamException ex)
			{
				Console.WriteLine(ex.Message);
				return;
			}
		}
	}
}
