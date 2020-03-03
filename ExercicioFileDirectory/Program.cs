using System;
using System.IO;
using System.Globalization;
using ExercicioFileDirectory.Entidades;

namespace ExercicioFileDirectory {
    class Program {
        static void Main(string[] args) {

            Console.Write("Digite o caminho inteiro do arquivo: ");
            string caminhoOrigemArquivo = Console.ReadLine();

            try {
                string[] lines = File.ReadAllLines(caminhoOrigemArquivo);

                string caminhoOrigemPasta = Path.GetDirectoryName(caminhoOrigemArquivo);
                string caminhoDestinoPasta = caminhoOrigemArquivo + @"\out";
                string caminhoDestinoArquivo = caminhoDestinoPasta + @"\summary.csv";

                Directory.CreateDirectory(caminhoDestinoPasta);

                using (StreamWriter sw = File.AppendText(caminhoDestinoArquivo)) {
                    foreach (string line in lines) {

                        string[] fields = line.Split(',');
                        string nome = fields[0];
                        double preco = double.Parse(fields[1], CultureInfo.InvariantCulture);
                        int quantidade = int.Parse(fields[2]);

                        Produtos prod = new Produtos(nome, preco, quantidade);
                        sw.WriteLine(prod.Nome + "," + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }

                }
                

            }
            catch (IOException e) {
                Console.WriteLine("An Error Ocurred" );
                Console.WriteLine(e.Message);
            }
        }
    }
}
