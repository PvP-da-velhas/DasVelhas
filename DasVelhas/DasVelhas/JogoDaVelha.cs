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
        List<string> Lista1 = new List<string>();
        private string Simb1;
        private string Simb2;
        private int Adversario;
        private string PrimeiroJogador;
        private string Dificuldade;
        private int contagem;
        private int limite;

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

            //Escolhendo a dificuldade
            Console.WriteLine("Jogará em qual dificuldade?\n\n" +
                              "Muito rápido[1]\n\n" +
                              "Rápido[2]\n\n" +
                              "Normal[3]");
            while (true)
            {
                Dificuldade = Console.ReadLine();
                if (Dificuldade != "1" && Dificuldade != "2" && Dificuldade != "3")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Escolha uma opção válida.");
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else { Console.Clear(); break; }
            }

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
                            if ((Simb1.Length != 1) || (Simb1 == " ") || (Simb1 == ""))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else { P1 = 1; }
                        }

                        // Símbolo do computador
                        Console.WriteLine("Digite o símbolo que o computador usará: ");
                        int P2 = 0;
                        while (P2 == 0)
                        {
                            Simb2 = Console.ReadLine();
                            if ((Simb2.Length != 1) || (Simb2 == " ") || (Simb2 == Simb1) || (Simb1 == ""))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Escolha um único carácter diferente de espaço como símbolo.");
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                            else { P2 = 1; }
                        }

                        // Quem começará
                        Console.Clear();
                        Console.WriteLine("Começar com você[1] ou com o computador[2]?");
                        int P3 = 0;
                        while (P3 == 0)
                        {
                            PrimeiroJogador = Console.ReadLine();
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

                        //Caso o computador jogue primeiro
                        if (PrimeiroJogador == "2")
                        {
                            FazerTabela();
                            Delay();
                            computadorVez();
                            MudarVez();
                        }

                        //Jogo Rodando
                        while (!FimDeJogo)
                        {
                            Tempos();
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
                            Simb2 = Console.ReadLine();
                            if ((Simb2.Length != 1 ) || (Simb2 == " ") || (Simb2 == Simb1))
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
                            Tempos();
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
                QuantidadePreenchida++;
                contagem = 0;
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
                QuantidadePreenchida++;
                contagem = 0;
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
            //Vitória
            if ((ExisteVitoriaHorizontal() || ExisteVitoriaDiagonal() || ExisteVitoriaVertical()) && !FimDeJogo)
            {
                FimDeJogo = true;
                Console.Clear();
                Pontos();
                Console.WriteLine(ObterTabela());
                Console.WriteLine($"Fim de jogo. Vitória de {vez}.");
                Console.ReadLine();
            }
            
            //Empate
            else if ((QuantidadePreenchida == 9) && !FimDeJogo)
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
        }

        //Tempo por turno
        public void Tempos()
        {
            if (QuantidadePreenchida > 0)
            {
                contagem++;
            }
            if (Dificuldade == "1")
            {
                limite = 3000;
            }
            else if (Dificuldade == "2")
            {
                limite = 6000;
            }
            else if (Dificuldade == "3")
            {
                limite = 10000;
            }
            PerdaDeVez();
        }

        public void PerdaDeVez()
        {
            if (!FimDeJogo)
            {
                if (limite < contagem)
                {
                    if (Adversario == 1)
                    {
                        contagem = 0;
                        MudarVez();
                    }
                    else if (Adversario == 2)
                    {
                        MudarVez();
                        computadorVez();
                        VerificarFimDeJogo();
                        Delay();
                        MudarVez();
                    }
                }
            }
        }
        

        // Escolhas de marcação do computador
        public void computadorVez()
        {
            if (FimDeJogo)
            {
                return;
            }
            int linhas = 0;

            //Verificando linhas
            bool jogadaFeita = false;

            while (linhas < 2)
            {
                if (jogadaFeita) { break; }
                else
                {
                    if (Posicoes[linhas, 0] == Posicoes[linhas, 1] && Posicoes[linhas, 0] == Simb1 && Posicoes[linhas, 2] == " ")
                    {
                        PreencherEscolha(linhas, 2);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                    else if (Posicoes[linhas, 0] == Posicoes[linhas, 2] && Posicoes[linhas, 0] == Simb1 && Posicoes[linhas, 1] == " ")
                    {
                        PreencherEscolha(linhas, 1);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                    else if (Posicoes[linhas, 1] == Posicoes[linhas, 2] && Posicoes[linhas, 1] == Simb1 && Posicoes[linhas, 0] == " ")
                    {
                        PreencherEscolha(linhas, 0);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                }
                linhas++;
            }
                               

            //Verificando colunas
            int colunas = 0;
            while (colunas < 2)
            {
                if (jogadaFeita) { break; }
                else
                {
                    if (Posicoes[0, colunas] == Posicoes[1, colunas] && Posicoes[0, colunas] == Simb1 && Posicoes[2, colunas] == " ")
                    {
                        PreencherEscolha(2, colunas);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                    else if (Posicoes[0, colunas] == Posicoes[2, colunas] && Posicoes[0, colunas] == Simb1 && Posicoes[0, colunas] == Simb1 && Posicoes[1, colunas] == " ")
                    {
                        PreencherEscolha(1, colunas);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                    else if (Posicoes[1, colunas] == Posicoes[2, colunas] && Posicoes[1, colunas] == Simb1 && Posicoes[0, colunas] == " ")
                    {
                        PreencherEscolha(0, colunas);
                        QuantidadePreenchida++;
                        jogadaFeita = true;
                    }
                }
                colunas++;
            }

            //Verificando diagonal que vai para baixo
            if (!jogadaFeita) 
            {
                if (Posicoes[0, 0] == Posicoes[1, 1] && Posicoes[0, 0] == Simb1 && Posicoes[2, 2] == " ")
                {
                    PreencherEscolha(2, 2);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
                if (Posicoes[0, 0] == Posicoes[2, 2] && Posicoes[0, 0] == Simb1 && Posicoes[1, 1] == " ")
                {
                    PreencherEscolha(1, 1);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
                if (Posicoes[1, 1] == Posicoes[2, 2] && Posicoes[1, 1] == Simb1 && Posicoes[0, 0] == " ")
                {
                    PreencherEscolha(1, 1);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
            }

            //Verificando diagonal que vai para cima
            if (!jogadaFeita)
            {
                if (Posicoes[2, 0] == Posicoes[1, 1] && Posicoes[2, 0] == Simb1 && Posicoes[0, 2] == " ")
                {
                    PreencherEscolha(0, 2);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
                if (Posicoes[2, 0] == Posicoes[0, 2] && Posicoes[2, 0] == Simb1 && Posicoes[1, 1] == " ")
                {
                    PreencherEscolha(1, 1);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
                if (Posicoes[1, 1] == Posicoes[0, 2] && Posicoes[1, 1] == Simb1 && Posicoes[2, 0] == " ")
                {
                    PreencherEscolha(2, 0);
                    QuantidadePreenchida++;
                    jogadaFeita = true;
                }
            }

            // Marcando aleatorimente
            int trava = 0;
            while (trava != 1)
            {
                if (jogadaFeita) { break; }
                else
                {
                    Random NumAleatorio1 = new Random();
                    Random NumAleatorio2 = new Random();
                    int EscolhaComp1 = NumAleatorio1.Next(0, 3);
                    int EscolhaComp2 = NumAleatorio2.Next(0, 3);
                    if (Posicoes[EscolhaComp1, EscolhaComp2] != Simb1 && Posicoes[EscolhaComp1, EscolhaComp2] != Simb2)
                    {
                        trava = 1;
                        jogadaFeita = true;
                        QuantidadePreenchida++;
                        PreencherEscolha(EscolhaComp1, EscolhaComp2);
                    }
                }
            }
            contagem = 0;
        }

        // Tempo que o computador demora para jogar depois do usuário jogar
        public void Delay()
        {
            var t = Task.Run(async delegate
            {
                await Task.Delay(200);
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

        //Adiciona espaços vazios no array Posicoes
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
                $"│  {Posicoes[1, 0]}  │  {Posicoes[1, 1]}  │  {Posicoes[1, 2]}  │                                             Tempo: {contagem}\n" +
                $"│-----│-----│-----│                                             Limite de tempo: {limite}\n" +
                $"│  {Posicoes[2, 0]}  │  {Posicoes[2, 1]}  │  {Posicoes[2, 2]}  │\n" +
                $"│_____│_____│_____│\n\n";
                    
        }
    }
}