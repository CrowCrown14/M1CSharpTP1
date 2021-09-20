using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace C_
{
    class Program
    {
        static void Main(string[] args)
        {
            // //Exercice 1.1
            // multiplicationTable();

            // //Exercice 1.2
            // multiplicationTableOdd();
            
            // Exercice 1.3 inclu dans le 1.1 et 1.2

            // //Exercice 2.1
            // prime();

            // //Exercice 2.2
            // fiboPrint();

            // //Exercice 2.3
            // factoriellePrint();

            // // Exercice 3
            // PowerFunctionPrint();

            // // Exercice 4
            // square(1,1);
            // square(1,5);
            // square(4,1);
            // square(5,7);
            // square(3,3);

            // Exercice 5
            readJson();

        }

        //Exercice 1.1
        static void multiplicationTable() {
            
            Console.Write("Multiplication table until : ");
            int choix = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1 ; i <= choix ; i++) {
                Console.WriteLine("Table de " + i);
                for (int j = 1 ; j <= 10 ; j++) {
                    Console.WriteLine(i+"*"+j+"="+(i*j));
                }
                Console.WriteLine();
            }
        }

        //Exercice 1.2
        static void multiplicationTableOdd() 
        {
            Console.Write("Multiplication table until : ");   
            int choix = Convert.ToInt32(Console.ReadLine());
            
            for (int i = 1 ; i <= choix ; i++) {
                Console.WriteLine("Table de " + i);
                for (int j = 1 ; j <= 10 ; j++) {
                    if (Convert.ToBoolean((i*j)%2)) {
                        Console.WriteLine(i+"*"+j+"="+(i*j));
                    }
                   
                }
                Console.WriteLine(); //pour retourner a la ligne
            }
        }

        //Exercice 1.3
        //Je n'ai pas fait expres de repondre a la question 3 quand je faisais les questions 1.1 et 1.2

        //Exercice 2.1 (totalement pas optimisé)
        static void prime() 
        {
            Console.Write("Choisissez un nombre max : ");
            int number = Convert.ToInt32(Console.ReadLine());
            
            Boolean[] array = new Boolean[number];

            for (int i = 2 ; i < number ; i++)
            {
                if (!array[i])
                {
                    int j = i + i;
                    while (j < number) {
                        array[j] = true;
                        j += i;
                    }
                }
            }

            //Affichage
            for (int i = 2 ; i < array.Length ; i++) {
                if(!array[i]) {
                    Console.WriteLine(i);
                }
            }
        }

        //Exercice 2.2 (fonction recurssive)
        static int fibo(int number)
        {
            if (number == 0) 
            {
                return 0;
            }
            else if (number == 1) 
            {
                return 1;
            } 
            else {
                return fibo(number-1) + fibo(number-2);
            }
        }

        //Afficher l'exerice 2.2
        static void fiboPrint()
        {
            Console.Write("Choisissez un nombre : ");
            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("F(" + number +") = " + fibo(number));
        }

        //Exercice 2.3 (fonction recursive)
        static ulong factorielle(ulong number) {
            if (number == 0 || number == 1) {
                return 1;
            }
            else {
                return number * factorielle(number-1);
            }
        }

        //Afficher l'exerice 2.3
        static void factoriellePrint()
        {
            Console.Write("Choisissez un nombre (a partir de 21 cela depasse la capacite max du ulong et du coup, le resultat est faux) : ");
            ulong number = Convert.ToUInt64(Console.ReadLine());

            Console.WriteLine(number + "! = " + factorielle(number));
        }

        //Exercice 3 (fonction PowerFunction)
        static int PowerFunction(int x)
        {
            return (int) (Math.Pow(x,2) - 4 );
        }

        //Exercice 3 (solution)
        static void PowerFunctionPrint() {
            for (int i = -3 ; i < 3 ; i++) {
                try {
                    Console.WriteLine(10/PowerFunction(i));
                }
                catch (DivideByZeroException e) {
                    Console.WriteLine(e);
                    Console.WriteLine("Avec " + i + ", la fonction = 0 et donc 10/0 impossible");
                }
            }
        }

        //Exercice 4
        static void square(int N, int M) {
            
            Console.WriteLine("Square de " + N + "*" + M);

            squareCoin(N);
            for (int i = 0 ; i < M ; i++) {
                squareMid(N);
            }
            squareCoin(N);

            Console.WriteLine();
        }

        // Affichage de la premiere et derniere ligne de l'exo 4
        static void squareCoin(int N) {
            Console.Write("0");
            for (int i = 0 ; i < N ; i++) {
                Console.Write("_");
            }
            Console.WriteLine("0");
        }

        // Affichage des autres lignes de l'exo 4
        static void squareMid(int N) {
            Console.Write("|");
            for (int i = 0 ; i < N ; i++) {
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }
        
        // Exercice 5
        static void readJson() {
            string path = @"DOGE_AllDataPoints_3Days.json";

            if (!File.Exists(path))
            {
                Console.WriteLine("Le fichier n'est pas trouvable ou n'existe pas.");
            }
            else {
                string jsonText = File.ReadAllText(path);
                JObject rss = JObject.Parse(jsonText);
                Console.WriteLine(rss);
            }
        }

    }
}
