using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SET2_alt
{
    internal class Program
    {    
        }
        private static void P17()
        {
            Console.WriteLine("ex 17:\n   Se da o secventa de 0 si 1, unde 0 inseamna paranteza deschisa si 1 inseamna paranteza inchisa. \n    Determinati daca secventa reprezinta o secventa de paranteze corecta si,\n    daca este, determinati nivelul maxim de incuibare a parantezelor.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countst = 0; 
            int countf = 0; 
            int incuib = 1;
            int incuibaux1 = 0;
            int incuibaux2 = 1;
            bool cerinta = true;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a < 0 || a > 1)
                    {
                        Console.WriteLine("Secventa poate contine doar 0-uri si 1-uri!!!");
                        return;
                    }
                    if (i == 0)
                    {
                        if (a == 1)
                        {
                            cerinta = false;
                        }
                    }
                    if (a == 0)
                    {
                        countst++;
                        incuibaux1++;
                    }
                    if (a == 1)
                    {
                        countst--;
                        incuibaux1--;
                    }
                    if (incuibaux1 > 0 && a == 0)
                    {
                        incuib = incuibaux1;
                        if (incuibaux2 < incuib)
                        {
                            incuibaux2 = incuib;
                        }
                    }
                    if (incuibaux1 == 0) incuib = 0;
                    if (countst < 0)
                    {
                        cerinta = false;
                    }
                }
                if (countst != 0 || !cerinta)
                {
                    Console.WriteLine("Secventa introdusa este incorecta");
                    return;
                }
                Console.WriteLine($"Secventa introdusa este corecta si are nivelul maxim de incuibare {incuibaux2}"); // - 1 pentru ca nivel 1 = 1 paranteza intr-o paranteza prin interpretarea mea.
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        /// <summary>
        /// secventa bitonica rotita
        /// </summary>
        private static void P16()
        {
            Console.WriteLine("ex 16:\n   Se da o secventa de n numere. Se cere sa se determine daca este o secventa bitonica rotita.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int wascresc = 0;
            int wasdescresc = 0;
            bool bitonic = true;
            bool rotit = false;
            bool crescmax1 = false;
            bool descrescmax1 = false;
            int endseq = 0, startseq = 0;
            int prevnr = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (!bitonic)
                    {
                        continue;
                    }
                    if (i == 0) 
                    {
                        prevnr = a;
                        startseq = a;
                    }
                    if (i == n - 1) 
                    {
                        endseq = a;
                    }
                    if (wascresc > 1 || wasdescresc > 1) 
                    {
                        rotit = true;
                    }
                    if (wascresc >= 1 && wasdescresc >= 1) 
                    {
                        if (crescmax1) 
                        {
                            if (a < prevnr)
                            {
                                wasdescresc = 2;
                                prevnr = a;
                                continue;
                            }
                            if (a > prevnr)
                            {
                                if (wasdescresc == 2)
                                {
                                    bitonic = false;
                                    continue;
                                }
                                prevnr = a;
                                continue;
                            }
                        }
                        if (descrescmax1) 
                        {
                            if (a > prevnr)
                            {
                                wascresc = 2;
                                prevnr = a;
                                continue;
                            }
                            if (a < prevnr)
                            {
                                if (wascresc == 2)
                                {
                                    bitonic = false;
                                    continue;
                                }
                                prevnr = a;
                                continue;
                            }
                        }
                    }
                    if (a > prevnr)
                    {
                        if (wasdescresc == 1) 
                        {
                            crescmax1 = true;
                        }
                        wascresc = 1;
                    }
                    if (a < prevnr)
                    {
                        if (wascresc == 1) 
                        {
                            descrescmax1 = true;
                        }
                        wasdescresc = 1;
                    }
                    prevnr = a;
                }
                if (rotit) 
                {
                    if (crescmax1)
                    {
                        if (startseq > endseq)
                        {
                            bitonic = false;
                        }
                    }
                    if (descrescmax1)
                    {
                        if (startseq < endseq)
                        {
                            bitonic = false;
                        }
                    }
                }
                if (!bitonic)
                {
                    Console.WriteLine("Secventa nu este bitonica rotita");
                    return;
                }
                Console.WriteLine("Secventa este bitonica rotita"); 
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P15()
        {
            Console.WriteLine("ex 15:\n   Se da o secventa de n numere. Sa se determine daca este bitonica. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            bool bitonic = false;
            bool cresc = false;
            try
            {
                int a, prevnr = Int32.MinValue;
                for (int i = 0; i < n; i++)
                {
                    if (!bitonic) 
                    {
                        a = int.Parse(Console.ReadLine());
                        if (i > 0 && a > prevnr) 
                        {
                            cresc = true;
                        }
                        if (prevnr > a)
                        {
                            bitonic = true;
                            continue;
                        }
                        prevnr = a;
                    }
                    if (bitonic)
                    {
                        a = int.Parse(Console.ReadLine());
                        if (prevnr < a)
                        {
                            bitonic = false;
                        }
                        prevnr = a;
                    }
                }
                if (bitonic && cresc)
                {
                    Console.WriteLine("Secventa este bitonica.");
                    return;
                }
                Console.WriteLine("Secventa nu este bitonica.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }

        private static void P14()
        {
            Console.WriteLine("ex 14:\n   Determinati daca o secventa de n numere este o secventa monotona rotita. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countcresc = 0, countdescresc = 0;
            int prevnr = int.MaxValue; 
            int startseq = 0;
            int endseq = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        prevnr = a;
                        startseq = a;
                    }
                    if (i == n - 1)
                    {
                        endseq = a;
                    }
                    if (a > prevnr)
                    {
                        countcresc++;
                    }
                    if (a < prevnr)
                    {
                        countdescresc++;
                    }
                    prevnr = a;
                }
                if (countdescresc == 0 || countcresc == 0)
                {
                    Console.WriteLine("Secventa este monotona rotita.");
                    return;
                }
                if (countdescresc < 2 && countcresc < 2) 
                {
                    Console.WriteLine("Secventa este monotona rotita.");
                    return;
                }
                if (countdescresc < 2 && countcresc > 2) 
                {
                    if (startseq > endseq)
                    {
                        Console.WriteLine("Secventa este monotona rotita.");
                        return;
                    }
                }
                if (countcresc < 2 && countdescresc > 2) 
                {
                    if (startseq < endseq)
                    {
                        Console.WriteLine("Secventa este monotona rotita.");
                        return;
                    }
                }
                Console.WriteLine("Secventa nu este monotona rotita.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P13()
        {
            Console.WriteLine("ex 13:\n   Determinati daca o secventa de n numere este o secventa crescatoare rotita. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            bool cerinta = true;
            bool rotit = false;
            int startseq = 0;
            int endseq = 0;
            try
            {
                int a, prevnr = Int32.MinValue;
                for (int i = 0; i < n; i++)
                {
                    a = int.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        startseq = a;
                    }
                    if (i == n - 1)
                    {
                        endseq = a;
                    }
                    if (rotit)
                    {
                        if (prevnr > a)
                        {
                            cerinta = false;
                        }
                    }
                    if (prevnr > a)
                    {
                        rotit = true;
                    }
                    prevnr = a;
                }
                if (rotit)
                {
                    if (startseq < endseq)
                    {
                        Console.WriteLine("Secventa nu este o secventa crescatoare rotita.");
                        return;
                    }
                }
                if (cerinta)
                {
                    Console.WriteLine("Secventa este o secventa crescatoare rotita.");
                }
                else Console.WriteLine("Secventa nu este o secventa crescatoare rotita.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P12()
        {
            Console.WriteLine("ex 12:\n   Cate grupuri de numere consecutive diferite de zero sunt intr-o secventa de n numere. \n   Considerati fiecare astfel de grup ca fiind un cuvant, zero fiind delimitator de cuvinte.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countegal = 0, countgrup = 1;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a != 0)
                    {
                        countegal++;
                    }
                    if (a == 0 && countegal != 0)
                    {
                        countgrup++;
                        countegal = 0;
                    }
                    if (i == n - 1) 
                    {
                        if (a == 0)
                        {
                            countgrup--;
                        }
                    }
                }
                Console.WriteLine($"Secventa contine {countgrup} grupuri de numere consecutive diferite de zero");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P11()
        {
            Console.WriteLine("ex 11:\n   Se da o secventa de n numere. Se cere sa se calculeze suma inverselor acestor numere.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            long suma = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a, inv = 0;
                    a = int.Parse(Console.ReadLine());
                    while (a != 0)
                    {
                        inv = inv * 10 + a % 10;
                        a /= 10;
                    }
                    suma += inv;
                }
                Console.WriteLine($"Suma inverselor numerelor din secventa este: {suma}");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P10()
        {
            Console.WriteLine("ex 10:\n   Se da o secventa de n numere. Care este numarul maxim de numere consecutive egale din secventa.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countegal = 0, countmax = 0, countmaxaux = 0, st = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        st = a;
                        continue;
                    }
                    if (a == st)
                    {
                        countegal++;
                        countmax = countegal;
                        if (countmaxaux < countmax)
                        {
                            countmaxaux = countmax;
                        }
                    }
                    if (a != st)
                    {
                        countegal = 0;
                    }
                    st = a;
                }
                Console.WriteLine($"Secventa contine maxim {countmaxaux + 1} numere consecutive egale.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P9()
        {
            Console.WriteLine("Sa se determine daca o secventa de n numere este monotona.");
            Console.WriteLine("Introduceti lungimea secventei (n): ");
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countcresc = 0, countdescresc = 0;
            int st = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (i == 0)
                    {
                        st = a;
                    }
                    if (a > st)
                    {
                        st = a;
                        countcresc++;
                    }
                    if (a < st)
                    {
                        st = a;
                        countdescresc++;
                    }
                }
                if (countdescresc > 0 && countcresc > 0)
                {
                    Console.WriteLine("Secventa nu este monotona.");
                    return;
                }
                Console.WriteLine("Secventa este monotona.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P8()
        {
            Console.WriteLine("ex 8:\n   Determianti al n-lea numar din sirul lui Fibonacci.\n   Sirul lui Fibonacci se construieste astfel: f1 = 0, f2 = 1, f_n = f_(n-1) + f(n-2).");
            int nr0 = 0;
            int nr1 = 1;
            int nr = 1;
            Console.WriteLine("\nIntroduceti n : ");
            if (n == 0) return;
            if (n == 1)
            {
                Console.WriteLine("Primul termen din sirul lui fibonacci este 0.");
                return;
            }
            if (n == 2)
            {
                Console.WriteLine("Al 2-lea termen din sirul lui fibonacci este 1.");
                return;
            }
            for (uint i = 3; i <= n; i++)
            {
                nr = nr0 + nr1;
                nr0 = nr1;
                nr1 = nr;
            }
            Console.WriteLine($"\nAl {n}-lea termen din sirul lui Fibonacci este: {nr}");

        }
        private static void P7()
        {
            Console.WriteLine("ex 7:\n   Se da o secventa de n numere. Sa se determine cea mai mare si cea mai mica valoare din secventa. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int max = Int32.MinValue, min = Int32.MaxValue;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a > max)
                    {
                        max = a;
                    }
                    if (a < min)
                    {
                        min = a;
                    }                
                }
                Console.WriteLine($"\nValoarea minima din secventa este {min} iar valoarea maxima este {max}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P6()
        {
            Console.WriteLine("ex 6:\n   Se da o secventa de n numere. Sa se determine daca numerele din secventa sunt in ordine crescatoare.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            bool cerinta = true;
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            try
            {
                int a, prevnr = Int32.MinValue;
                for (int i = 0; i < n; i++)
                {
                    a = int.Parse(Console.ReadLine());
                    if (prevnr > a)
                    {
                        cerinta = false;
                    }
                    prevnr = a;
                }
                if (cerinta)
                {
                    Console.WriteLine("\nNumerele din secventa sunt in ordine crescatoare");
                }
                else
                {
                    Console.WriteLine("\nNumerele din secventa nu sunt in ordine crescatoare");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P5()
        {
            Console.WriteLine("ex 5:\n   Cate elemente dintr-o secventa de n numere sunt egale cu pozitia pe care apar in secventa. \n   Se considera ca primul element din secventa este pe pozitia 0. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int count = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a == i) count++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
            Console.WriteLine($"In aceasta secventa sunt {count} numere egale cu pozitia lor in secventa");
        }
        private static void P4()
        {
            Console.WriteLine("ex 4:\n   Se da o secventa de n numere. Determinati pe ce pozitie se afla in secventa un numar 'a'.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            int a;
            Console.WriteLine("\nIntroduceti numarul 'a' pe care vreti sa il gasiti in secventa: ");
            var aAsString = Console.ReadLine();
            while (!int.TryParse(aAsString, out a))
            {
                Console.WriteLine("Trebuie sa introduci un numar! Incearca din nou!");
                Console.WriteLine();
                Console.Write("a = ");
                aAsString = Console.ReadLine();
            }
            int count = -1;
            int poz = count;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int x;
                    x = int.Parse(Console.ReadLine());
                    count++;
                    if (x == a)
                    {
                        poz = count;
                    }
                }
                Console.WriteLine($"Numarul {a} se afla in pozitia {poz}.");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
        }
        private static void P3()
        {
            Console.WriteLine("ex 3:\n   Calculati suma si produsul numerelor de la 1 la n.");
            Console.WriteLine("\nIntroduceti 'n' : ");
            ulong n = ulong.Parse(Convert.ToString(N_CHECK()));
            if (n == 0) return;
            if (n < 1)
            {
                Console.WriteLine("'n' trebuie sa fie mai mare decat 1 ca operatia sa aiba sens!!!"); // serios cine nu citeste indicatia
                return;
            }
            ulong suma; 
            double produs = 1; 
            try
            {
                checked
                {
                    if (n % 2 == 0)
                    {
                        suma = n / 2 * (n + 1);
                    }
                    else suma = ((n + 1) / 2) * n;
                }
                if (n > 170) 
                {
                    Console.WriteLine($"Pentru numerele de la 1 la {n}:\nSuma lor este: {suma}\nProdusul lor este prea mare sa poata fi calculat ( peste 20 de cifre lung ).");
                    return;
                }
                else
                {
                    for (double i = 2; i <= n; i++)
                    {
                        produs *= i;

                    }
                }
                Console.WriteLine($"Pentru numerele de la 1 la {n}:\nSuma lor este: {suma}\nProdusul lor este: {produs}");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Numarul introdus este prea mare pentru a putea fi calculat!!!");
            }

        }
        private static void P2()
        {
            Console.WriteLine("ex 2:\n   Se da o secventa de n numere. Sa se determina cate sunt negative, cate sunt zero si cate sunt pozitive. ");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int countneg = 0;
            int countzero = 0;
            int countpos = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a < 0) countneg++;
                    if (a == 0) countzero++;
                    if (a > 1) countpos++;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
            Console.Write($"\nIn secventa ");
            if (countpos == 0) Console.Write("nu este nici un numar pozitiv,");
            if (countpos == 1) Console.Write("este 1 numar pozitiv,");
            if (countpos > 1) Console.Write($"sunt {countpos} numere pozitive,");
            if (countzero == 0) Console.Write(" nu este nici un zero,");
            if (countzero == 1) Console.Write(" este 1 zero,");
            if (countzero > 1) Console.Write($" sunt {countzero} zerouri,");
            if (countneg == 0) Console.Write(" nu este nici un numar negativ.");
            if (countneg == 1) Console.Write(" este 1 numar negativ.");
            if (countneg > 1) Console.Write($" sunt {countneg} numere negative.");
        }
        private static void P1()
        {
            Console.WriteLine("ex 1:\n   Se da o secventa de n numere. Sa se determine cate din ele sunt pare.");
            Console.WriteLine("\nIntroduceti lungimea secventei (n): ");
            uint n = N_CHECK();
            if (n == 0) return;
            Console.WriteLine("\nIntroduceti secventa de numere:");
            int count = 0;
            try
            {
                for (int i = 0; i < n; i++)
                {
                    int a;
                    a = int.Parse(Console.ReadLine());
                    if (a % 2 == 0) count++;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine caractere necorespunzatoare sau nu corespunde lungimii declarate anterior!!!");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("\nSecventa de numere introdusa contine un numar prea mare!!!");
                return;
            }
            Console.WriteLine($"In secventa sunt {count} numere pare.");
        }
    }
}
