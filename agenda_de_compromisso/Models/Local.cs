using System;

namespace Models
{
    public class Local
    {
        public string Nome { get; private set; }
        public int Capacidade { get; private set; }

        public Local(string nome, int capacidade)
        {
            Nome = nome ?? throw new ArgumentException("Nome inválido.");
            Capacidade = capacidade > 0 ? capacidade : throw new ArgumentException("Capacidade deve ser maior que 0.");
        }

        public void ValidarCapacidade(int quantidade)
        {
            if (quantidade > Capacidade)
                throw new InvalidOperationException("Capacidade do local excedida.");
        }
    }
}