using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Testando
{
    internal class JogoDaVelha
    {
        private int Pontos_jogador1 = 0;
        private int Pontos_jogador2 = 0;
        private bool FimDeJogo;
        private string[,] Posicoes = new string[3, 3];
        private string vez;
        private int QuantidadePreenchida;
        List<int> Lista1 = new List<int>();
        private string Simb1;
        private string Simb2;
        private int Adversario;

        public JogoDaVelha()
        {
            FimDeJogo = false;
            QuantidadePreenchida = 0;
        }
        
        public void Iniciar()
        {
            Console.Clear();
            Console.WriteLine("Utilize os números do NumPad para fazer as marcações.\n" +
                "Pressione ENTER para continuar");
            Console.ReadLine();
            Console.Clear();

            //Escolhendo o adversário
                Console.WriteLine("Jogará contra o computador [Comp] ou contra outro jogador [Jog]?");
            int P0 = 0;
            while(P0 == 0)
            {
                String EscolhaAdver = Console.ReadLine().ToLower();


                // Jogador contra Computador
                Console.CursorVisible = false;
                if (EscolhaAdver == "comp" || EscolhaAdver == "computador")
                {
                    Adversario = 2;
                    string continuar = "s";
                    while (continuar == "s")
                    {
                        Console.Clear();

                        // Símbolo do jogador 1
                        Console.WriteLine("Digite o símbolo que você usará: ");
                        int P1 = 0;
                        while (P1 == 0)
                        {
                            Simb1 = Console.ReadLine();
                            if ((Simb1.Length != 1) || (Simb1 == " "))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else { P1 = 1; }
                        }

                        // Símbolo do jogador 2
                        Console.WriteLine("Digite o símbolo que o computador usará: ");
                        int P2 = 0;
                        while (P2 == 0)
                        {
                            Simb2 = Console.ReadLine();
                            if ((Simb2.Length != 1) || (Simb2 == " "))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else { P2 = 1; }
                        }

                        // Quem começará
                        Console.Clear();
                        Console.WriteLine("Começar com o você[1] ou com o computador[2]?");
                        int P3 = 0;
                        while (P3 == 0)
                        {
                            string PrimeiroJogador = Console.ReadLine();
                            if (PrimeiroJogador == "1")
                            {
                                vez = Simb1;
                                P3 = 1;
                            }
                            else if (PrimeiroJogador == "2")
                            {
                                vez = Simb2;
                                P3 = 1;
                            }
                            else 
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha uma opção válida.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }

                        // Iniciando a partida
                        Console.Clear();
                        MostradosNaTabela();

                        //Jogo Rodando
                        while (!FimDeJogo)
                        {
                            FazerTabela();
                            VerEscolhaUsuario();
                        }

                        // Jogar novamente
                        Console.WriteLine("Deseja continuar jogando? [s/n]");
                        continuar = Console.ReadLine().ToLower();
                        if (continuar == "s")
                        {
                            QuantidadePreenchida = 0;
                            FimDeJogo = false;
                        }
                        else { continuar = "n"; P0 = 1; }
                    }
                }


                // Jogador contra Jogador
                else if (EscolhaAdver == "jogador" || EscolhaAdver == "jog")
                {
                    Adversario = 1;
                    string continuar = "s";
                    while (continuar == "s")
                    {
                        Console.Clear();

                        // Símbolo do jogador 1
                        Console.WriteLine("Digite o símbolo que o Jogador 1 usará: ");
                        int P1 = 0;
                        while (P1 == 0)
                        {
                            Simb1 = Console.ReadLine();
                            if ((Simb1.Length != 1) || (Simb1 == " "))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else { P1 = 1; }
                        }

                        // Símbolo do jogador 2
                        Console.WriteLine("Digite o símbolo que o Jogador 2 usará: ");
                        int P2 = 0;
                        while (P2 == 0)
                        {
                            Simb1 = Console.ReadLine();
                            if ((Simb1.Length != 1) || (Simb1 == " "))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                            else { P2 = 1; }
                        }

                        // Quem começará
                        Console.Clear();
                        Console.WriteLine("Começar com o jogador 1[1] ou com o jogador 2[2]?");
                        int P3 = 0;
                        while (P3 == 0)
                        {
                            string PrimeiroJogador = Console.ReadLine();
                            if (PrimeiroJogador == "1")
                            {
                                vez = Simb1;
                                P3 = 1;
                            }
                            else if (PrimeiroJogador == "2")
                            {
                                vez = Simb2;
                                P3 = 1;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha uma opção válida.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }

                        // Iniciando a partida
                        Console.Clear();
                        MostradosNaTabela();

                        // Jogo rodando
                        while (!FimDeJogo)
                        {
                            FazerTabela();
                            VerEscolhaUsuario();
                        }

                        // Jogar novamente
                        Console.WriteLine("Deseja continuar jogando? [s/n]");
                        continuar = Console.ReadLine().ToLower();
                        if (continuar == "s")
                        {
                            QuantidadePreenchida = 0;
                            FimDeJogo = false;
                        }
                        else { continuar = "n"; P0 = 1; }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha uma opção válida.");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }

        // Chamará outras funções após o jogador tentar fazer uma marcação em JxJ.
        private void TeclaPressionadaJxJ(int posicaoEscolhida01, int posicaoEscolhida02)
        {
            if (ValidarEscolhaUsuario(posicaoEscolhida01, posicaoEscolhida02) == true)
            {
                PreencherEscolha(posicaoEscolhida01, posicaoEscolhida02);
                VerificarFimDeJogo();
                MudarVez();
            }
            else { }
        }

        // Chamará outras funções após o jogador tentar fazer uma marcação em JxC.
        private void TeclaPressionadaJxC(int posicaoEscolhida01, int posicaoEscolhida02)
        {
            if (ValidarEscolhaUsuario(posicaoEscolhida01, posicaoEscolhida02) == true)
            {
                PreencherEscolha(posicaoEscolhida01, posicaoEscolhida02);
                VerificarFimDeJogo();
                MudarVez();
                FazerTabela();
                Delay();
                computadorVez();
                VerificarFimDeJogo();
                MudarVez();
            }
            else { }
        }
        // Verifica se há um ganhador ou se há um empate
        private void VerificarFimDeJogo()
        {
            if ((ExisteVitoriaHorizontal() || ExisteVitoriaDiagonal() || ExisteVitoriaVertical()) && !FimDeJogo)
            {
                FimDeJogo = true;
                Console.Clear();
                Pontos();
                Console.WriteLine(ObterTabela());
                Console.WriteLine($"Fim de jogo. Vitória de {vez}.");
                Console.ReadLine();
            }
            else if ((QuantidadePreenchida == 8) && !FimDeJogo)
            {
                FimDeJogo = true;
                Console.Clear();
                Console.WriteLine(ObterTabela());
                Console.WriteLine($"Fim de jogo. Empate.");
                Console.ReadLine();
            }
        }

        // Alterna os símbolos escolhidos
        private void MudarVez()
        {
            vez = vez == Simb1 ? Simb2 : Simb1;
            QuantidadePreenchida++;
        }

        private void VezJogador()
        {
            vez = Simb1;
        }

        private void VezComputador()
        {
            vez = Simb2;
        }

        // Escolhas de marcação do computador
        public void computadorVez()
        {
            if (FimDeJogo)
            {
                return;
            }
            int trava = 0;
            while (trava != 1)
            {
                Random NumAleatorio1 = new Random();
                Random NumAleatorio2 = new Random();
                int EscolhaComp1 = NumAleatorio1.Next(0, 3);
                int EscolhaComp2 = NumAleatorio2.Next(0, 3);
                if (Posicoes[EscolhaComp1, EscolhaComp2] != Simb1 && Posicoes[EscolhaComp1, EscolhaComp2] != Simb2)
                {
                    trava = 1;
                    PreencherEscolha(EscolhaComp1, EscolhaComp2);
                }
                else { }
                /*

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
                */
            }
        }

        public void Delay()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(300);
                return ;
            });
            t.Wait();
        }

        // Sistema de pontuação
        private void Pontos()
        {
            if (Simb1 == vez)
            {
                Pontos_jogador1++;
            }
            else if (Simb2 == vez)
            {
                Pontos_jogador2++;
            }
        }


        private bool ExisteVitoriaHorizontal()
        {
            bool VitoriaLinha1 = Posicoes[0, 0] == Posicoes[0, 1] && Posicoes[0, 0] == Posicoes[0, 2] && Posicoes[0, 0] != " ";
            bool VitoriaLinha2 = Posicoes[1, 0] == Posicoes[1, 1] && Posicoes[1, 0] == Posicoes[1, 2] && Posicoes[1, 0] != " ";
            bool VitoriaLinha3 = Posicoes[2, 0] == Posicoes[2, 1] && Posicoes[2, 0] == Posicoes[2, 2] && Posicoes[2, 0] != " ";

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }

        private bool ExisteVitoriaVertical()
        {
            bool VitoriaLinha1 = Posicoes[0, 0] == Posicoes[1, 0] && Posicoes[0, 0] == Posicoes[2, 0] && Posicoes[0, 0] != " ";
            bool VitoriaLinha2 = Posicoes[0, 1] == Posicoes[1, 1] && Posicoes[0, 1] == Posicoes[2, 1] && Posicoes[0, 1] != " ";
            bool VitoriaLinha3 = Posicoes[0, 2] == Posicoes[1, 2] && Posicoes[0, 2] == Posicoes[2, 2] && Posicoes[0, 2] != " ";

            return VitoriaLinha1 || VitoriaLinha2 || VitoriaLinha3;
        }

        private bool ExisteVitoriaDiagonal()
        {
            bool VitoriaLinha1 = Posicoes[0, 0] == Posicoes[1, 1] && Posicoes[0, 0] == Posicoes[2, 2] && Posicoes[0, 0] != " ";
            bool VitoriaLinha2 = Posicoes[2, 0] == Posicoes[1, 1] && Posicoes[2, 0] == Posicoes[0, 2] && Posicoes[2, 0] != " ";

            return VitoriaLinha1 || VitoriaLinha2;
        }

        private void PreencherEscolha(int posicaoEscolhida1, int posicaoEscolhida2)
        {
            Posicoes[posicaoEscolhida1, posicaoEscolhida2] = vez;
            
        }
        

        //Verifica se é um jogo Jogado X Jogador ou um Jogador X Computador
        private void JogadorOuComputador(int num1, int num2)
        {
            if (Adversario == 1)
            {
                TeclaPressionadaJxJ(num1, num2);
            }

            else if (Adversario == 2)
            {
                TeclaPressionadaJxC(num1, num2);
            }
        }


        // Verifica se a posição escolhida pelo jogador já não está ocupada
        private bool ValidarEscolhaUsuario(int posicaoEscolhida1, int posicaoEscolhida2)
        {
            int indice1 = posicaoEscolhida1;
            int indice2 = posicaoEscolhida2;
            return Posicoes[indice1,indice2] != Simb1 && Posicoes[indice1,indice2] != Simb2;
        }

        private void VerEscolhaUsuario()
        {
            Console.WriteLine($"Agora é a vez de {vez}, escolha uma posição disponível.");
            

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.NumPad9:
                        JogadorOuComputador(0,2);
                        break;
                    case ConsoleKey.NumPad8:
                        JogadorOuComputador(0,1);
                        break;
                    case ConsoleKey.NumPad7:
                        JogadorOuComputador(0,0);
                        break;
                    case ConsoleKey.NumPad6:
                        JogadorOuComputador(1,2);
                        break;
                    case ConsoleKey.NumPad5:
                        JogadorOuComputador(1,1);
                        break;
                    case ConsoleKey.NumPad4:
                        JogadorOuComputador(1,0);
                        break;
                    case ConsoleKey.NumPad3:
                        JogadorOuComputador(2,2);
                        break;
                    case ConsoleKey.NumPad2:
                        JogadorOuComputador(2,1);
                        break;
                    case ConsoleKey.NumPad1:
                        JogadorOuComputador(2,0);
                        break;
                    default:
                        break;
                }
            }
        }

        private void FazerTabela()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(ObterTabela());
        }

        private void MostradosNaTabela()
        {
            Posicoes[0, 0] = " "; Posicoes[0, 1] = " "; Posicoes[0, 2] = " ";

            Posicoes[1, 0] = " "; Posicoes[1, 1] = " "; Posicoes[1, 2] = " ";

            Posicoes[2, 0] = " "; Posicoes[2, 1] = " "; Posicoes[2, 2] = " ";
        }

        private string ObterTabela()
        {
            string Texto1 = " ";
            string jogadorAdver = " ";
            if (Adversario == 1)
            {
                Texto1 = "Pontuação do Jogador 1";
                jogadorAdver = "Jogador 2";
            }
            else if (Adversario == 2)
            {
                Texto1 = "Sua pontuação";
                jogadorAdver = "Computador";
            }
            return
                   $"|-----|-----|-----|                                        {Texto1}: {Pontos_jogador1}\n" +
                   $"│  {Posicoes[0, 0]}  │  {Posicoes[0, 1]}  │  {Posicoes[0, 2]}  │                                        Pontuação do {jogadorAdver}: {Pontos_jogador2}\n" +
                   $"│-----│-----│-----│\n" +
                   $"│  {Posicoes[1, 0]}  │  {Posicoes[1, 1]}  │  {Posicoes[1, 2]}  │\n" +
                   $"│-----│-----│-----│\n" +
                   $"│  {Posicoes[2, 0]}  │  {Posicoes[2, 1]}  │  {Posicoes[2, 2]}  │\n" +
                   $"│_____│_____│_____│\n\n";
                    
        }
    }
}