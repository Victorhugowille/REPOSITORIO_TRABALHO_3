using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Compromisso
    {
        public DateTime DataHora { get; private set; }
        public string Descricao { get; private set; }
        public Usuario Responsavel { get; private set; }
        public Local Local { get; private set; }

        private List<Participante> participantes = new List<Participante>();
        private List<Anotacao> anotacoes = new List<Anotacao>();

        public IReadOnlyCollection<Participante> Participantes => participantes.AsReadOnly();
        public IReadOnlyCollection<Anotacao> Anotacoes => anotacoes.AsReadOnly();

        public Compromisso(DateTime dataHora, string descricao, Usuario responsavel, Local local)
        {
            if (dataHora <= DateTime.Now)
                throw new ArgumentException("Data e hora devem estar no futuro.");

            if (string.IsNullOrWhiteSpace(descricao))
                throw new ArgumentException("Descrição é obrigatória.");

            DataHora = dataHora;
            Descricao = descricao;
            Responsavel = responsavel ?? throw new ArgumentException("Responsável é obrigatório.");
            Local = local ?? throw new ArgumentException("Local é obrigatório.");

            Responsavel.AdicionarCompromisso(this);
        }

        public void AdicionarParticipante(Participante participante)
        {
            if (Local != null && participantes.Count + 1 > Local.Capacidade)
                throw new InvalidOperationException("Capacidade máxima do local excedida.");

            if (!participantes.Contains(participante))
            {
                participantes.Add(participante);
                participante.AdicionarCompromisso(this);
            }
        }

        public void AdicionarAnotacao(string texto)
        {
            anotacoes.Add(new Anotacao(texto));
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Descrição: {Descricao}");
            sb.AppendLine($"Data e hora: {DataHora}");
            sb.AppendLine($"Local: {Local.Nome} (Capacidade: {Local.Capacidade})");
            sb.AppendLine($"Participantes ({participantes.Count}):");
            foreach (var p in participantes)
            {
                sb.AppendLine($" - {p.NomeCompleto}");
            }
            sb.AppendLine("Anotações:");
            foreach (var a in anotacoes)
            {
                sb.AppendLine($" - [{a.DataCriacao}] {a.Texto}");
            }
            return sb.ToString();
        }
    }
}