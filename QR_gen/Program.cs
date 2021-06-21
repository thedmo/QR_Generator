//using IronBarCode;
using System;
using System.IO;
using QRCoder;
using System.Drawing;

namespace QR_gen {
	class Program {
		static void Main(string[] args) {

			string stringToConvert;
			bool endApplication = false;

			string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "MyQrCodes");
			string filename = Path.Combine(directoryPath, "MyQr_" + DateTime.Now.ToString("yyyyMMdd_HHmmss"));

			QRCodeGenerator qRCodeGenerator = new QRCodeGenerator();


			if (!Directory.Exists(directoryPath)) {
				Directory.CreateDirectory(directoryPath);
			}

			do {

				do {

					Console.WriteLine("Hier den String reinkopieren, welcher als QR Code abgespeichert werden soll: ");
					stringToConvert = Console.ReadLine();

					QRCodeData qrCodeData = qRCodeGenerator.CreateQrCode(stringToConvert, QRCodeGenerator.ECCLevel.Q);
					QRCode qrCode = new QRCode(qrCodeData);
					Bitmap qrCodeImage = qrCode.GetGraphic(100);

					qrCodeImage.Save(filename+".bmp");

					//byte[] qrCodeBitmapAsByteArray = qrCode.GetGraphic(100);


					if (stringToConvert == string.Empty) {
						Console.WriteLine("Bitte einen Wert eingeben... ");
					}

				} while (stringToConvert == string.Empty);



				//QRCodeWriter.CreateQrCode(stringToConvert, 500, QRCodeWriter.QrErrorCorrectionLevel.Medium).SaveAsPng($"{filename}.png");

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
