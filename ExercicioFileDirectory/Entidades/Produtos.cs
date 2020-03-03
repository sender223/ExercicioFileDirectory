namespace ExercicioFileDirectory.Entidades {
    class Produtos {
        //propriedades autoimplementadas
        public string Nome { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }

        //construtor padrão com argumentos.
        public Produtos(string nome, double preco, int quantidade) {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        //metodo do tipo double para calcular o total dos produtos
        public double Total() {
            return Preco * Quantidade;
        }
    }
}
