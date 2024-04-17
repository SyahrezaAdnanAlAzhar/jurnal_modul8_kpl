using System.Collections.Generic;
using System.Numerics;
using System.Text.Json;

public class Program
{
    public static void Main(string[] args)
    {
        BankTransferConfig BTConfig = new BankTransferConfig();

        string configPath = "BankTransfer_Config_1302223041.json";

        BTConfig.ReadAndWriteConfigFile(configPath);

        if (BTConfig.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer:");
        }
        else if (BTConfig.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer:");
        }

        int nominalTransfer = int.Parse(Console.ReadLine());
        int totalBiaya = 0;

        if (nominalTransfer <= BTConfig.transfer.threshold)
        {
            totalBiaya = BTConfig.transfer.low_fee + nominalTransfer;
        }
        else
        {
            totalBiaya = BTConfig.transfer.high_fee + nominalTransfer;
        }

        if (BTConfig.lang == "en")
        {
            Console.WriteLine($"Transfer fee = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total amount = {totalBiaya}");
            Console.WriteLine("Select transfer method:");
        }
        else if (BTConfig.lang == "id")
        {
            Console.WriteLine($"Biaya transfer = {totalBiaya - nominalTransfer}");
            Console.WriteLine($"Total biaya    = {totalBiaya}");
            Console.WriteLine("Pilih metode transfer:");
        }

        for (int i = 0; i < BTConfig.methods.Length; i++)
        {
            Console.WriteLine($"{i+1}. {BTConfig.methods[i]}");
        }
        Console.Write("Masukkan pilihan: ");
        int pilihan = int.Parse(Console.ReadLine());

        if (BTConfig.lang == "en")
        {
            Console.WriteLine($"Please type {BTConfig.confirmation.en} to confirm the transaction: ");
        }
        else if (BTConfig.lang == "id")
        {
            Console.WriteLine($"Ketik {BTConfig.confirmation.id} untuk mengkonfirmasi transaksi:");
        }

        string confirmationInput = Console.ReadLine();

        if (BTConfig.lang == "en" &&  confirmationInput == BTConfig.confirmation.en)
        {
            Console.WriteLine("The transfer is completed");
        }
        else if (BTConfig.lang == "en")
        {
            Console.WriteLine("Transfer is cancelled");
        }

        if (BTConfig.lang == "id" && confirmationInput == BTConfig.confirmation.id)
        {
            Console.WriteLine("Proses transfer berhasil");
        }
        else if (BTConfig.lang == "id")
        {
            Console.WriteLine("Transfer dibatalkan");
        }
    }
}