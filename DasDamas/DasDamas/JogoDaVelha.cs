using System;

namespace Testando
{
    internal class JogoDaVelha
    {
        private bool FimDeJogo;
        private char[] Posicoes;
        private char vez;
        private int QuantidadePreenchida;

        public JogoDaVelha()
        {
            FimDeJogo = false;
            Posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            QuantidadePreenchida = 0;
        }

        public void Iniciar()
        {
            while (!FimDeJogo)
            {
                FazerTabela();
                VerEscolhaUsuario();
                FazerTabela();
                VerificarFimDeJogo();
                MudarVez();

            }


        }

        private void PreencherEscolha(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            Posicoes[indice] = vez;
            QuantidadePreenchida++;
        }

        private void MudarVez()
        {
            vez = vez == 'X' ? 'O' : 'X';
        }

        private void VerificarFimDeJogo()
        {
            if (QuantidadePreenchida < 5)
                return;

            if (ExisteVitoriaHorizontal() || ExisteVitoriaDiagonal() || ExisteVitoriaVertical())
            {
                FimDeJogo = true;
                Console.WriteLine($"Fim de jogo. Vitória de {vez}.");
                Console.Read();
                return;
            }

            if (QuantidadePreenchida is 9)
            {
                FimDeJogo = true;
                Console.WriteLine("Fim de jogo. Empate.");
                Console.Read();
            }
        }

        private bool ExisteVitoriaHorizontal()
        {
            bool VitoriaLinha1 = Posicoes[0] == Posicoes[1] && Posicoes[0] == Posicoes[2];
            bool VitoriaLinha2 = Posicoes[3] == Posicoes[4] && Posicoes[3] == Posicoes[5];
            bool VitoriaLinha3 = Posicoes[6] == Posicoes[7] && Posicoes[6] == Posicoes[8];

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool VitoriaLinha1 = Posicoes[0] == Posicoes[3] && Posicoes[0] == Posicoes[6];
            bool VitoriaLinha2 = Posicoes[1] == Posicoes[4] && Posicoes[1] == Posicoes[7];
            bool VitoriaLinha3 = Posicoes[2] == Posicoes[5] && Posicoes[2] == Posicoes[8];

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool VitoriaLinha1 = Posicoes[0] == Posicoes[4] && Posicoes[0] == Posicoes[8];
            bool VitoriaLinha2 = Posicoes[6] == Posicoes[4] && Posicoes[6] == Posicoes[2];


            return VitoriaLinha1 || VitoriaLinha2;
        }

        private void VerEscolhaUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha uma posição disponível.");
            bool conversao = int.TryParse(s: Console.ReadLine(), out int posicaoEscolhida);

            while (!conversao || !ValidarEscolhaUsuario(posicaoEscolhida))
            {
                Console.WriteLine("O campo escolhido é invalido, são válidos apenas os números disponíveis na tabela");
                conversao = int.TryParse(s: Console.ReadLine(), out posicaoEscolhida);
            }

            PreencherEscolha(posicaoEscolhida);
        }

        private bool ValidarEscolhaUsuario(int posicaoEscolhida)
        {
            int indice = posicaoEscolhida - 1;
            return Posicoes[indice] != 'O' && Posicoes[indice] != 'X';


        }

        private void FazerTabela()
        {
            Console.Clear();
            Console.WriteLine(ObterTabela());
        }

        private string ObterTabela()
        {
            return $"__{Posicoes[0]}__│__{Posicoes[1]}__│__{Posicoes[2]}__\n" +
                   $"__{Posicoes[3]}__│__{Posicoes[4]}__│__{Posicoes[5]}__\n" +
                   $"__{Posicoes[6]}__│__{Posicoes[7]}__│__{Posicoes[8]}__\n\n";
        }
    }
}