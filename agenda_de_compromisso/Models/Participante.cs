using System;
using System.Collections.Generic;

namespace Models
{
    public class Participante
    {
        public string NomeCompleto { get; private set; }

        private List<Compromisso> compromissos = new List<Compromisso>();
        public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();

        public Participante(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto ?? throw new ArgumentException("Nome inválido.");
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (!compromissos.Contains(compromisso))
            {
                compromissos.Add(compromisso);
            }
        }
    }
}