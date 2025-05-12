using System;
using System.Collections.Generic;
using Models;

class Program
{
    static void Main()
    {
        Console.Write("Digite seu nome completo: ");
        string nomeUsuario = Console.ReadLine();
        Usuario usuario = new Usuario(nomeUsuario);

        Console.Write("Quantos compromissos deseja registrar? ");
        int total = int.Parse(Console.ReadLine());

        for (int i = 0; i < total; i++)
        {
            Console.WriteLine($"\nCompromisso {i + 1}:");

            Console.Write("Data (AAAA-MM-DD): ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Hora (HH:MM): ");
            TimeSpan hora = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            Console.Write("Nome do local: ");
            string nomeLocal = Console.ReadLine();

            Console.Write("Capacidade do local: ");
            int capacidade = int.Parse(Console.ReadLine());

            Local local = new Local(nomeLocal, capacidade);
            DateTime dataHora = data.Date + hora;

            Compromisso compromisso;
            try
            {
                compromisso = new Compromisso(dataHora, descricao, usuario, local);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar compromisso: " + ex.Message);
                i--;
                continue;
            }

            Console.Write("Quantos participantes? ");
            int n = int.Parse(Console.ReadLine());

            for (int j = 0; j < n; j++)
            {
                Console.Write($"Nome do participante {j + 1}: ");
                string nomeParticipante = Console.ReadLine();
                Participante p = new Participante(nomeParticipante);
                try
                {
                    compromisso.AdicionarParticipante(p);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao adicionar participante: " + ex.Message);
                    j--;
                }
            }

            Console.Write("Quantas anotações deseja adicionar? ");
            int m = int.Parse(Console.ReadLine());

            for (int k = 0; k < m; k++)
            {
                Console.Write($"Texto da anotação {k + 1}: ");
                string texto = Console.ReadLine();
                compromisso.AdicionarAnotacao(texto);
            }
        }

        Console.WriteLine("\nCOMPROMISSOS REGISTRADOS:\n");

        foreach (var compromisso in usuario.Compromissos)
        {
            Console.WriteLine(compromisso);
            Console.WriteLine(new string('-', 50));
        }
    }
}