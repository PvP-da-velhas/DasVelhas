using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testando
{
    internal class JogoDaVelha
    {
        private bool FimDeJogo;
        private char[] Posicoes;
        private char vez;
        private int QuantidadePreenchida;
        List<int> Lista1 = new List<int>();

        public JogoDaVelha()
        {
            FimDeJogo = false;
            Posicoes = new[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            vez = 'X';
            QuantidadePreenchida = 0;
        }
        
        public void Iniciar()
        {
            Console.WriteLine("Jogará contra o computador [Comp] ou contra outro jogador [Jog]?");
            String EscolhaAdver = Console.ReadLine().ToLower();

            // Jogador contra Computador
            if (EscolhaAdver == "comp" || EscolhaAdver == "computador")
            {
                while (!FimDeJogo)
                {
                    FazerTabela();
                    VerEscolhaUsuario();
                    FazerTabela();
                    VerificarFimDeJogo();
                    VezComputador();
                    computadorVez();
                    Delay();
                    MudarVez();
                }
            }

            // Jogador contra Jogador
            else if (EscolhaAdver == "jogador" || EscolhaAdver == "jog")
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

        private void VezJogador()
        {
            vez = 'X';
        }

        private void VezComputador()
        {
            vez = 'O';
        }

        public void computadorVez()
        {
         
            // Verificando a linha 1
            if ((Posicoes[0] == Posicoes[1] && Posicoes[0] == 'X') && (Posicoes[2] != 'X') && (Posicoes[2] != 'O'))
                PreencherEscolha(3);
            else if ((Posicoes[0] == Posicoes[2] && Posicoes[0] == 'X') && (Posicoes[1] != 'X') && (Posicoes[1] != 'O'))
                PreencherEscolha(2);
            else if ((Posicoes[1] == Posicoes[2] && Posicoes[0] == 'X') && (Posicoes[0] != 'X') && (Posicoes[0] != 'O'))
                PreencherEscolha(1);

            // Verificando a linha 2
            else if ((Posicoes[3] == Posicoes[4] && Posicoes[3] == 'X') && (Posicoes[5] != 'X') && (Posicoes[5] != 'O'))
                PreencherEscolha(6);
            else if ((Posicoes[3] == Posicoes[5] && Posicoes[3] == 'X') && (Posicoes[4] != 'X') && (Posicoes[4] != 'O'))
                PreencherEscolha(5);
            else if ((Posicoes[4] == Posicoes[5] && Posicoes[4] == 'X') && (Posicoes[3] != 'X') && (Posicoes[3] != 'O'))
                PreencherEscolha(4);

            // Verificando a linha 3
            else if ((Posicoes[6] == Posicoes[7] && Posicoes[6] == 'X') && (Posicoes[8] != 'X') && (Posicoes[8] != 'O'))
                PreencherEscolha(9);
            else if ((Posicoes[6] == Posicoes[8] && Posicoes[6] == 'X') && (Posicoes[7] != 'X') && (Posicoes[7] != 'O'))
                PreencherEscolha(8);
            else if ((Posicoes[7] == Posicoes[8] && Posicoes[7] == 'X') && (Posicoes[6] != 'X') && (Posicoes[6] != 'O'))
                PreencherEscolha(7);

            //Verificando a coluna 1
            else if ((Posicoes[0] == Posicoes[3] && Posicoes[0] == 'X') && (Posicoes[6] != 'X') && (Posicoes[6] != 'O'))
                PreencherEscolha(7);
            else if ((Posicoes[0] == Posicoes[6] && Posicoes[0] == 'X') && (Posicoes[3] != 'X') && (Posicoes[3] != 'O'))
                PreencherEscolha(4);
            else if ((Posicoes[3] == Posicoes[6] && Posicoes[3] == 'X') && (Posicoes[0] != 'X') && (Posicoes[0] != 'O'))
                PreencherEscolha(1);

            //Verificando a coluna 2
            else if ((Posicoes[1] == Posicoes[4] && Posicoes[1] == 'X') && (Posicoes[7] != 'X') && (Posicoes[7] != 'O'))
                PreencherEscolha(8);
            else if ((Posicoes[1] == Posicoes[7] && Posicoes[1] == 'X') && (Posicoes[4] != 'X') && (Posicoes[4] != 'O'))
                PreencherEscolha(5);
            else if ((Posicoes[4] == Posicoes[7] && Posicoes[4] == 'X') && (Posicoes[1] != 'X') && (Posicoes[1] != 'O'))
                PreencherEscolha(2);

            //Verificando a coluna 3
            else if ((Posicoes[2] == Posicoes[5] && Posicoes[2] == 'X') && (Posicoes[8] != 'X') && (Posicoes[8] != 'O'))
                PreencherEscolha(9);
            else if ((Posicoes[2] == Posicoes[8] && Posicoes[2] == 'X') && (Posicoes[5] != 'X') && (Posicoes[5] != 'O'))
                PreencherEscolha(6);
            else if ((Posicoes[5] == Posicoes[8] && Posicoes[8] == 'X') && (Posicoes[2] != 'X') && (Posicoes[2] != 'O'))
                PreencherEscolha(3);

            //Verificando a diagonal 1
            else if ((Posicoes[0] == Posicoes[4] && Posicoes[0] == 'X') && (Posicoes[8] != 'X') && (Posicoes[8] != 'O'))
                PreencherEscolha(9);
            else if ((Posicoes[0] == Posicoes[8] && Posicoes[0] == 'X') && (Posicoes[4] != 'X') && (Posicoes[4] != 'O'))
                PreencherEscolha(5);
            else if ((Posicoes[4] == Posicoes[8] && Posicoes[4] == 'X') && (Posicoes[0] != 'X') && (Posicoes[0] != 'O'))
                PreencherEscolha(1);

            //Verificando a diagonal 2
            else if ((Posicoes[2] == Posicoes[4] && Posicoes[2] == 'X') && (Posicoes[6] != 'X') && (Posicoes[6] != 'O'))
                PreencherEscolha(7);
            else if ((Posicoes[2] == Posicoes[6] && Posicoes[2] == 'X') && (Posicoes[4] != 'X') && (Posicoes[4] != 'O'))
                PreencherEscolha(5);
            else if ((Posicoes[4] == Posicoes[6] && Posicoes[4] == 'X') && (Posicoes[2] != 'X') && (Posicoes[2] != 'O'))
                PreencherEscolha(3);
            else
            {
                int trava = 0;
                while (trava != 1)
                {
                    Random NumAleatorio = new Random();
                    int EscolhaComp = NumAleatorio.Next(1, 9);
                    if (Posicoes[EscolhaComp - 1] != 'X' && Posicoes[EscolhaComp - 1] != 'O')
                    {
                        trava = 1;
                        PreencherEscolha(EscolhaComp);
                        Lista1.Add(EscolhaComp);
                    }
                    else { string Nada = "Absolutamente nada";}
                }
            }
        }

        public void Delay()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(500);
                return ;
            });
            t.Wait();
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
            return
                   $"|-----|-----|-----|\n" +
                   $"│  {Posicoes[0]}  │  {Posicoes[1]}  │  {Posicoes[2]}  │\n" +
                   $"│-----│-----│-----│\n" +
                   $"│  {Posicoes[3]}  │  {Posicoes[4]}  │  {Posicoes[5]}  │\n" +
                   $"│-----│-----│-----│\n" +
                   $"│  {Posicoes[6]}  │  {Posicoes[7]}  │  {Posicoes[8]}  │\n" +
                   $"│_____│_____│_____│\n\n";
                    
        }
    }
}