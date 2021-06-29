using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {

        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            //variáveis de auxílio
            var r = '\r';
            var n = '\n';
            var numLinhas = 9;
            var numColunas = 9;

            //matriz para guardar posições das bombas
            int[,] minas = new int[numLinhas, numColunas];
            Array.Clear(minas, 0, minas.Length);

            while (campoMinado.JogoStatus == 0 )
            {

                //cria uma cópia do tabuleiro atual
                var copiaTabuleiro = campoMinado.Tabuleiro;
                var aux = 0;
                char[] auxTabuleiro = copiaTabuleiro.ToCharArray();
                char[] tabuleiro = new char[numLinhas * numColunas];
                char[,] jogo = new char[numLinhas, numColunas];


                foreach (var c in auxTabuleiro)
                {
                    if (c != r && c != n)
                    {
                        tabuleiro[aux] = c;
                        aux++;
                    }

                }

                aux = 0;

                // monta a matriz do estado atual do jogo
                for (var x = 0; x < numLinhas; x++)
                {
                    for (var y = 0; y < numColunas; y++)
                    {
                        jogo[x, y] = tabuleiro[aux];
                        aux++;

                    }
                }

                //descobrir aonde estão as minas
                for (var x = 0; x < numLinhas; x++)
                {
                    for (var y = 0; y < numColunas; y++)
                    {
                        if (jogo[x, y] == '-' | jogo[x, y] == '0')
                        {
                            continue;
                        }
                        else
                        {
                            var numCasa = (int)Char.GetNumericValue(jogo[x, y]);
                            var casasLivres = 0;

                            //verificar quantas casas livres há em volta da casa atual
                            if (x - 1 >= 0 && y - 1 >= 0)
                            {
                                if (jogo[x - 1, y - 1] == '-')
                                {
                                    casasLivres++;
                                }

                            }
                            if (x - 1 >= 0)
                            {
                                if (jogo[x - 1, y] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (x - 1 >= 0 && y + 1 < numColunas)
                            {
                                if (jogo[x - 1, y + 1] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (y - 1 >= 0)
                            {
                                if (jogo[x, y - 1] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (y + 1 < numColunas)
                            {
                                if (jogo[x, y + 1] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numLinhas && y - 1 >= 0)
                            {
                                if (jogo[x + 1, y - 1] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numLinhas)
                            {
                                if (jogo[x + 1, y] == '-')
                                {
                                    casasLivres++;
                                }
                            }

                            if (x + 1 < numLinhas && y + 1 < numColunas)
                            {
                                if (jogo[x + 1, y + 1] == '-')
                                {
                                    casasLivres++;
                                }
                            }


                            //preenche a matriz com a localização das bombas
                            if (numCasa == casasLivres)
                            {
                                if (x - 1 >= 0 && y - 1 >= 0)
                                {
                                    if (jogo[x - 1, y - 1] == '-')
                                    {
                                        minas[x - 1, y - 1] = 1;
                                    }
                                }

                                if (x - 1 >= 0)
                                {
                                    if (jogo[x - 1, y] == '-')
                                    {
                                        minas[x - 1, y] = 1;
                                    }
                                }

                                if (x - 1 >= 0 && y + 1 < numColunas)
                                {
                                    if (jogo[x - 1, y + 1] == '-')
                                    {
                                        minas[x - 1, y + 1] = 1;
                                    }
                                }

                                if (y - 1 >= 0)
                                {
                                    if (jogo[x, y - 1] == '-')
                                    {
                                        minas[x, y - 1] = 1;
                                    }
                                }

                                if (y + 1 < numColunas)
                                {
                                    if (jogo[x, y + 1] == '-')
                                    {
                                        minas[x, y + 1] = 1;
                                    }
                                }

                                if (x + 1 < numColunas && y - 1 >= 0)
                                {
                                    if (jogo[x + 1, y - 1] == '-')
                                    {
                                        minas[x + 1, y - 1] = 1;
                                    }
                                }

                                if (x + 1 < numLinhas)
                                {
                                    if (jogo[x + 1, y] == '-')
                                    {
                                        minas[x + 1, y] = 1;
                                    }
                                }

                                if (x + 1 < numLinhas && y + 1 < numColunas)
                                {
                                    if (jogo[x + 1, y + 1] == '-')
                                    {
                                        minas[x + 1, y + 1] = 1;
                                    }

                                }
                            }
                        }
                    }
                }


                //abre as posições possíveis sem bombas
                for (var x = 0; x < numLinhas; x++)
                {
                    for (var y = 0; y < numColunas; y++)
                    {
                        if (jogo[x, y] == '-' | jogo[x, y] == '0')
                        {
                            continue;
                        }
                        else
                        {
                            var numCasa = (int)Char.GetNumericValue(jogo[x, y]);
                            var numMinas = 0;

                            //conta quantas minas tem em volta da casa selecionada
                            if (x - 1 >= 0 && y - 1 >= 0)
                            {
                                if (minas[x - 1, y - 1] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (x - 1 >= 0)
                            {
                                if (minas[x - 1, y] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (x - 1 >= 0 && y + 1 < numColunas)
                            {
                                if (minas[x - 1, y + 1] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (y - 1 >= 0)
                            {
                                if (minas[x, y - 1] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (y + 1 < numColunas)
                            {
                                if (minas[x, y + 1] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (x + 1 < numLinhas && y - 1 >= 0)
                            {
                                if (minas[x + 1, y - 1] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (x + 1 < numLinhas)
                            {
                                if (minas[x + 1, y] == 1)
                                {
                                    numMinas++;
                                }
                            }

                            if (x + 1 < numLinhas && y + 1 < numColunas)
                            {
                                if (minas[x + 1, y + 1] == 1)
                                {
                                    numMinas++;
                                }

                            }

                            //abre as casas que não tem mina em volta da casa selecionada
                            if(numMinas == numCasa)
                            {
                                if (x - 1 >= 0 && y - 1 >= 0)
                                {
                                    if (jogo[x - 1, y - 1] == '-' && minas[x - 1, y - 1] != 1)
                                    {
                                        campoMinado.Abrir(x, y);
                                    }
                                }

                                if (x - 1 >= 0)
                                {
                                    if (jogo[x - 1, y] == '-' && minas[x - 1, y] != 1)
                                    {
                                        campoMinado.Abrir(x, y + 1);
                                    }
                                }

                                if (x - 1 >= 0 && y + 1 < numColunas)
                                {
                                    if (jogo[x - 1, y + 1] == '-' && minas[x - 1, y + 1] != 1)
                                    {
                                        campoMinado.Abrir(x, y + 2);
                                    }
                                }

                                if (y - 1 >= 0)
                                {
                                    if (jogo[x, y - 1] == '-' && minas[x, y - 1] != 1)
                                    {
                                        campoMinado.Abrir(x + 1, y);
                                    }
                                }

                                if (y + 1 < numColunas)
                                {
                                    if (jogo[x, y + 1] == '-' && minas[x, y + 1] != 1)
                                    {
                                        campoMinado.Abrir(x + 1, y + 2);
                                    }
                                }

                                if (x + 1 < numLinhas && y - 1 >= 0)
                                {
                                    if (jogo[x + 1, y - 1] == '-' && minas[x + 1, y - 1] != 1)
                                    {
                                        campoMinado.Abrir(x + 2, y);
                                    }
                                }

                                if (x + 1 < numLinhas)
                                {
                                    if (jogo[x + 1, y] == '-' && minas[x + 1, y] != 1)
                                    {
                                        campoMinado.Abrir(x + 2, y + 1);
                                    }
                                }

                                if (x + 1 < numLinhas && y + 1 < numColunas)
                                {
                                    if (jogo[x + 1, y + 1] == '-' && minas[x + 1, y + 1] != 1)
                                    {
                                        campoMinado.Abrir(x + 2, y + 2);
                                    }

                                }
                            }
                        }
                    }
                }

                Console.WriteLine("=========");
                Console.WriteLine(campoMinado.Tabuleiro);

                if (campoMinado.JogoStatus == 1)
                {
                    Console.WriteLine("=========");
                    Console.WriteLine("VITÓRIA");
                }
                else if (campoMinado.JogoStatus == 2)
                {
                    Console.WriteLine("=========");
                    Console.WriteLine("GAME OVER");
                }
            }
        }
    }
}