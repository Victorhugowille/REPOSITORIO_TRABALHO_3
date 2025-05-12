using System;
using System.Collections.Generic;

namespace Models
{
    public class Usuario
    {
        public string NomeCompleto { get; private set; }

        private List<Compromisso> compromissos = new List<Compromisso>();

        public IReadOnlyCollection<Compromisso> Compromissos => compromissos.AsReadOnly();

        public Usuario(string nomeCompleto)
        {
            NomeCompleto = nomeCompleto ?? throw new ArgumentException("Nome não pode ser nulo.");
        }

        public void AdicionarCompromisso(Compromisso compromisso)
        {
            if (compromisso == null)
                throw new ArgumentException("Compromisso inválido.");

            compromissos.Add(compromisso);
        }
    }
}