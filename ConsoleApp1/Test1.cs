using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Test1 : IAmTheTest
    {

        public string[] GetSuggestions(string term, string[] terms, int n)
        {
            // Convertir tous les termes en minuscule et enlever les caractères non alphanumériques
            terms = terms.Select(x => new string(x.ToLower().Where(char.IsLetterOrDigit).ToArray())).ToArray();
            term = new string(term.ToLower().Where(char.IsLetterOrDigit).ToArray());

            // Calculer la distance de Levenshtein entre le terme entré et chaque terme de la liste
            int[] distances = terms.Select(x => LevenshteinDistance(term, x)).ToArray();

            // Trier les termes par distance, puis par longueur, puis par ordre alphabétique
            string[] sortedTerms = terms.OrderBy(x => distances[Array.IndexOf(terms, x)])
                                        .ThenBy(x => Math.Abs(term.Length - x.Length))
                                        .ThenBy(x => x)
                                        .ToArray();

            // Retourner les N premiers termes triés
            return sortedTerms.Take(n).ToArray();
        }

        private int LevenshteinDistance(string s, string t)
        {
            // Implémentation de l'algorithme de distance de Levenshtein
            int n = s.Length;
            int m = t.Length;
            int[,] d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
                d[i, 0] = i;
            for (int j = 0; j <= m; j++)
                d[0, j] = j;

            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= m; j++)
                    d[i, j] = Math.Min(Math.Min(d[i - 1, j], d[i, j - 1]) + 1, d[i - 1, j - 1] + (s[i - 1] == t[j - 1] ? 0 : 1));

            return d[n, m];
        }
    }
}
