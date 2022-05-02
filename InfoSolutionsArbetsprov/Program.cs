using NumberServiceProxy;
using System;
using System.IO;
using System.Threading.Tasks;

namespace InfoSolutionsArbetsprov
{
    class Program
    {
        static async Task Main(string[] args)
        {
            int sequenceLength = 100;
            string numberSeriesCode = "TEST";
            string fileName = string.Join('.', numberSeriesCode, "txt");

            Console.Clear();
            using NumberServiceSoapClient client = new(NumberServiceSoapClient.EndpointConfiguration.NumberServiceSoap);

            var getNextNumberResponse = await client.GetNextNumberAsync(numberSeriesCode);

            var result = getNextNumberResponse.Body.GetNextNumberResult;
            if (!int.TryParse(result, out int number)) return;

            using FileStream fileStream = new(fileName, FileMode.Append, FileAccess.Write);
            using StreamWriter streamWriter = new(fileStream);

            for (int i = number; i <= number + sequenceLength; i++)
            {
                if (i % 15 == 0) WriteLine($"{i} TreMultipelFemMultipel", streamWriter);
                else if (i % 3 == 0) WriteLine($"{i} TreMultipel", streamWriter);
                else if (i % 5 == 0) WriteLine($"{i} FemMultipel", streamWriter);
                else WriteLine($"{i}", streamWriter);
            }
        }

        private static void WriteLine(string message, StreamWriter writer)
        {
            Console.WriteLine(message);
            writer.WriteLine(message);
        }
    }
}
