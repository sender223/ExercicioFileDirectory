using System;
using System.IO;
using System.Globalization;
using ExercicioFileDirectory.Entidades;

//criando as pastas e o arquivo inicialmente c:\exercicio\origem\produtos.csv

namespace ExercicioFileDirectory {
    class Program {
        static void Main(string[] args) {
            //iniciamos pedindo ao usuário que digite o caminho completo do arquivo
            Console.Write("Digite o caminho completo do arquivo: ");
            //depois armazene na variavel tipo string caminhoOrigemArquivo. 
            string caminhoOrigemArquivo = Console.ReadLine();
            //abrimos um try catch para tratar erros.
            try {
                //usamos um vetor de linhas para ler todas as linhas do arquivo.
                string[] lines = File.ReadAllLines(caminhoOrigemArquivo);

                //usamos uma variavel caminhoOrigemPasta para pegar o caminho do diretorio
                //do arquivo
                string caminhoOrigemPasta = Path.GetDirectoryName(caminhoOrigemArquivo);
                //depois criamos mais uma variavel caminhoDestinoPasta e concatenamos ela
                //com o caminhoOrigemPasta + \out para criarmos logo abaixo um novo diretorio
                string caminhoDestinoPasta = caminhoOrigemPasta + @"\out";
                //mais uma variavel, dessa vez para criar o destino do novo arquivo
                //ja com o nome descrito
                string caminhoDestinoArquivo = caminhoDestinoPasta + @"\summary.csv";
                //aqui criamos a pasta de destino do arquivo
                Directory.CreateDirectory(caminhoDestinoPasta);

                //aqui usamos o using para instanciar o StreamWriter
                //e utilizando a classe File.AppendText iremos abrir o caminho destino
                //do arquivo, escrever nele e salvar.
                using (StreamWriter sw = File.AppendText(caminhoDestinoArquivo)) {
                    //para cada linha in lines
                    foreach (string line in lines) {
                        //criamos um vetor dos camposTabela e usamos o Split, para separar
                        //todo o conteúdo do arquivo que está após as virgulas. 
                        string[] camposTabela = line.Split(',');
                        //depois criamos uma variavel nome, e atribuimos o valor que 
                        //segmentamos em blocos dos campos da tabela que separamos logo acima. 
                        string nome = camposTabela[0];
                        //variavel preco com o bloco [1] da camposTabela. 
                        double preco = double.Parse(camposTabela[1], CultureInfo.InvariantCulture);
                        //variavel quantidade com o bloco [2] da camposTabela
                        int quantidade = int.Parse(camposTabela[2]);
                        //depois instanciamos a Classe produtos com os atributos acima
                        Produtos prod = new Produtos(nome, preco, quantidade);
                        //por ultimo iremos imprimir a nossa StreamWriter sw com prod.Nome +
                        //o metodo para calcular o total dos produtos prod.Total().
                        sw.WriteLine(prod.Nome + ", " + prod.Total().ToString("F2", CultureInfo.InvariantCulture));
                    }
                }
            }
            catch (IOException e) {
                Console.WriteLine("An Error Ocurred");
                Console.WriteLine(e.Message);
            }
        }
    }
}