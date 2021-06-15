using System;
using System.Text;
using System.IO;

namespace Doom
{

    class Program
    {
        //Dimensões da tela
        public static int nScreenWidth = 120;
        public static int nScreenHeight = 40;

 //       public static int saveBufferWidth;
 //       public static int saveBufferHeight;
        public static int saveWindowHeight;
        public static int saveWindowWidth;
        public static bool saveCursorVisible;

        //Variveis do jogador
        public static float fPlayerX = 0.0f;
        public static float fPlayerY = 0.0f;
        public static float fPlayerAng = 0.0f;

        //Variaveis do mapa
        public static int nMapW = 16;
        public static int nMapH = 16;

        //Variaveis de visão
        public static float fFOV = 3.14159f/4;  //90º
        public static float fDepth = 16.0f;     //Distancia de visao

        
        public static void Main()
        {
            StringBuilder screen = new StringBuilder(nScreenWidth * nScreenHeight);


            StringBuilder map = new StringBuilder(nMapW * nMapH);
            map.Append("################");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("#..............#");
            map.Append("################");

            do
            {
                for (int i = 0; i < nScreenWidth; i++)
                {
                    //A visão do usuário será composta de um conjunto de "raios" que batem
                    //nas superfícies e as rendenizam.

                    //Dividimos o angulo de visão em 2, colocando meio angulo pra cada lado
                    //do centro da visão
                    float fAngleVisionRay = (fPlayerAng - fFOV / 2.0f) + ((float)i / (float)nScreenWidth) * fFOV;

                    //Calculamos a distância
                    float fDistanceToWall = 0.0f;
                    Boolean bHitWall = false;

                    float fEyeX = (float)Math.Sin(fAngleVisionRay);
                    float fEyeY = (float)Math.Cos(fAngleVisionRay);

                    while (!bHitWall && fDistanceToWall < fDepth)
                    {
                        fDistanceToWall += 0.1f;

                        //Só interessado nos limites das barreiras
                        int nTestX = (int)(fPlayerX + fEyeX * fDistanceToWall);
                        int nTestY = (int)(fPlayerY + fEyeY * fDistanceToWall);

                        //Testa se o raio de visão esta fora da area andavel
                        if (nTestX < 0 || nTestX >= nMapH || nTestY < 0 || nTestY >= nMapW)
                        {
                            bHitWall = true;
                            fDistanceToWall = fDepth;
                        }
                    }

                }
            } while (true);

        }
    }
}
