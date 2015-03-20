using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MyPractice
{
	class Program
	{
		static void Main()
		{
			try
			{
				String readFilePath = "ReceivedMessages.txt";
				if (!File.Exists(readFilePath))
				{
					throw new FileNotFoundException("Required file has not been found", readFilePath);
				}

				using (var reader = new StreamReader(readFilePath))
				{
					String faxWriteFilePath = "Faxes.txt";
					String printerWriteFilePath = "Prints.txt";

					using (StreamWriter faxWriter = new StreamWriter(new FileStream(faxWriteFilePath, FileMode.Create)),
										printerWriter = new StreamWriter(new FileStream(printerWriteFilePath, FileMode.Create)))
					{
						var aFax = new Fax("Fax ONE", faxWriter, MailManager.Instance);
						var aPrinter = new Printer("Printer ONE", printerWriter, MailManager.Instance);

						MailManager.Instance.SimulateNewMail(reader);
						MailManager.Instance.SimulateNewMail(reader);

						aPrinter.Unregister(MailManager.Instance);

						MailManager.Instance.SimulateNewMail(reader);

						aFax.Unregister(MailManager.Instance);
						aPrinter.Register(MailManager.Instance);

						MailManager.Instance.SimulateNewMail(reader);
						MailManager.Instance.SimulateNewMail(reader);
						MailManager.Instance.SimulateNewMail(reader);
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
		}
	}
}
