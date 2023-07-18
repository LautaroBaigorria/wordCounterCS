using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class WordCounter1
    {
    static void Main(string[] args)
    {
        string paragraph = "The Zen of Python, by Tim Peters Beautiful is better than ugly.Explicit is better than implicit. Simple is better than complex.";
        var dictionary = WordCounter(paragraph,false);
        Print_ascii_bar_chart(dictionary);
        
    }
    
    static IDictionary<string, int> WordCounter(string paragraph, bool omitCommonWords=false)
    {
        Regex r = new Regex("(?:[^a-z0-9 ]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
        paragraph = r.Replace(paragraph, " "); // reemplazo simbolos por 1 espacio
        paragraph = Regex.Replace(paragraph, @"\s+", " "); //reemplazo multiples espacios por 1 solo
        IDictionary<string, int> counter = new Dictionary<string, int>();
        // var counter = new Dictionary<string, int>();

        string[] paragraph_list = paragraph.ToLower().Split(' '); 

        if (omitCommonWords == true)
        {
            string[] words_en = {"the","of","and","to","a","in","for","is","on","that","by","this","with","i","you","it","not","or","be","are","from","at","as","your","all","have","new","more","an","was","we","will","home","can","us","about","if","page","my","has","search","free","but","our","one","other","do","no","information","time","they","site","he","up","may","what","which","their","news","out","use","any","there","see","only","so","his","when","contact","here","business","who","web","also","now","help","get","pm","view","online","c","e","first","am","been","would","how","were","me","s","services","some","these","click","its","like","service","x","than","find"};
            
            string[] words_sp = {"que","de","no","a","la","el","es","y","en","lo","un","por","qué","me","una","te","los","se","con","para","mi","está","si","bien","pero","yo","eso","las","sí","su","tu","aquí","del","al","como","le","más","esto","ya","todo","esta","vamos","muy","hay","ahora","algo","estoy","tengo","nos","tú","nada","cuando","ha","este","sé","estás","así","puedo","cómo","quiero","sólo","soy","tiene","gracias","o","él","bueno","fue","ser","hacer","son","todos","era","eres","vez","tienes","creo","ella","he","ese","voy","puede","sabes","hola","sus","porque","dios","quién","nunca","dónde","quieres","casa","favor","esa","dos","tan","señor","tiempo","verdad","estaba"};

            var paragraph_filtered = paragraph_list.Where(x=>!words_en.Any(y=>y==x));
            paragraph_list = paragraph_filtered.ToArray();
            paragraph_filtered = paragraph_list.Where(x=>!words_sp.Any(y=>y==x));
            paragraph_list = paragraph_filtered.ToArray();
        }

        // for (int i = 0; i < paragraph_list.Length; i++)
        // {
        //     Console.WriteLine(paragraph_list[i]);    
        // }
        // Print_ascii_bar_chart(paragraph_list);
    
        foreach (string word in paragraph_list)
        {
            if (counter.ContainsKey(word))
            {
                counter[word]+=1;
            }
            else
            {
                counter[word]=1;
            }
        }
        
        

        return counter;
    }

    static void Print_ascii_bar_chart(IDictionary<string, int> counter)
    {
        string longestWord = string.Empty;
        List<KeyValuePair<string, int>> myList = counter.ToList();

        // Sort the list based on the values
        myList.Sort((x, y) => y.Value.CompareTo(x.Value));

        Dictionary<string, int> sortedDict = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> pair in myList)
        {
            sortedDict.Add(pair.Key, pair.Value);
        }

        foreach (var kvp in sortedDict)
        {
            if (kvp.Key.Length > longestWord.Length)
            {
                longestWord = kvp.Key;
            }
        }

        Console.WriteLine("funcion Print_ascii_bar_chart");
        // foreach (var kvp in sortedDict)
        // {
        //     Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        // }
        Console.WriteLine ("Cantidad de palabras contabilizadas: {0}",  sortedDict.Count);
        Console.WriteLine ("Palabra mas larga: {0}",  longestWord);

        foreach (var kvp in sortedDict)
        {
            // string symbol = "#";
            // int frequency = kvp.Value;
            string symbols = new string ('#', kvp.Value);
            double percentage = kvp.Value / (double)sortedDict.Count * 100;
            percentage = Math.Round(percentage,2);
            // string paddingS = "-";
            string paddingM = new string ('-', (sortedDict.Count - kvp.Key.Length));
            Console.WriteLine ( "{0}{1} | {2} {3} | {4}%", kvp.Key, paddingM, symbols, kvp.Value, percentage);
            // Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);
        }
    }

    static void openTextFile()
    {
        
    } 
}
    
}