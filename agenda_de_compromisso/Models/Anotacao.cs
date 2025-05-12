using System;

namespace Models
{
    public class Anotacao
    {
        public string Texto { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public Anotacao(string texto)
        {
            Texto = texto ?? throw new ArgumentException("Texto inválido.");
            DataCriacao = DateTime.Now;
        }
    }
}