using IronBarCode;
using System;
using System.IO;

namespace QR_gen {
	class Program {
		static void Main(string[] args) {

			string stringToConvert;
			bool endApplication = false;

			string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MyQrCodes");
			string filename = Path.Combine(directoryPath, "MyQr", DateTime.Now.ToString("yyyyMMdd_HHmmss"));



			if (!Directory.Exists(directoryPath)) {
				Directory.CreateDirectory(directoryPath);
			}

			do {

				do {

					Console.WriteLine("Hier den String reinkopieren, welcher als QR Code abgespeichert werden soll: ");
					stringToConvert = Console.ReadLine();

					if (stringToConvert == string.Empty) {
						Console.WriteLine("Bitte einen Wert eingeben... ");
					}

				} while (stringToConvert == string.Empty);



				QRCodeWriter.CreateQrCode(stringToConvert, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng($"{filename}.png");

				Console.WriteLine("qr Code wurde abgespeichert.");


				Console.WriteLine("'N' drücken für weiteren Code");


				string pressedKey = Console.ReadKey().Key.ToString().ToUpper();


				if (!(pressedKey == "N")) {
					endApplication = true;
				}
				Console.WriteLine("\n");

			} while (!endApplication);
		}
	}
}
