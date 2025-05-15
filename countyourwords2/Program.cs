using System;

public class Program
{
    public static void Main() {
        string filePath = "input.txt";
        string[] input = readFile(filePath);
        sortWords(input, 0, input.Length-1);
        Console.WriteLine(input);
        List<Pair<int, string>> pairs = pairWords(input);
        printPairs(pairs);
    }

    /**
    * Prints each pair of the pairs List
    */
    public static void printPairs(List<Pair<int, string>> pairs) {
        foreach (Pair<int, string> p in pairs) {
            Console.WriteLine(p.Second + " " + p.First);
        }
    }

    /**
    * Counts the occurrence of each word and puts it into a Pair<int, string> List
    */
    public static List<Pair<int, string>> pairWords(string[] words) {
        int count = 1;
        string word = words[0];
        List<Pair<int, string>> pairs = new List<Pair<int, string>>();
        Pair<int, string> pair;

        for (int i = 1; i < words.Length; i++) {
            if (!Equals(words[i], word)) {
                pair = new Pair<int, string>(count, word);
                pairs.Add(pair);
                word = words[i];
                count = 1;
            } //no more occurrences of the current word
            else {
                count++;
            }
        }
        pair = new Pair<int, string>(count, word);
        pairs.Add(pair);
        
        return pairs;
    }

    /**
    * Sorts the words[] array using Merge sort.
    * This function splits the array into two smaller arrays.
    */
    public static void sortWords(string[] words, int left, int right) {
        if (left < right) {
            int middle = left + (right - left) / 2;

            sortWords(words, left, middle);
            sortWords(words, middle+1, right);

            merge(words, left, middle, right);
        }
    }
    
    /**
    * Sorts the smaller arrays into words[].
    */
    public static void merge(string[] words, int left, int middle, int right) {
        int i, j, k;
        int leftSize = middle - left + 1;
        int rightSize = right - middle;
        string[] leftArr = new string[leftSize];
        string[] rightArr = new string[rightSize];

        for (i = 0; i < leftSize; i++) {
            leftArr[i] = words[i + left];
        } //[0, middle]
        for (i = 0; i < rightSize; i++) {
            rightArr[i] = words[middle + 1 + i];
        } //[middle+1, right];
        i = 0;
        j = 0;
        k = left;

        while (i < leftSize && j < rightSize) {
            if (String.Compare(leftArr[i], rightArr[j]) == -1) {
                words[k] = leftArr[i];
                i++;
            } //-1 == left < right
            else {
                words[k] = rightArr[j];
                j++;
            }
            k++;
        }
        while (i < leftSize && k < words.Length) {
            words[k] = leftArr[i];
            i++;
            k++;
        } //leftovers
        while (j < rightSize && k < words.Length) {
            words[k] = rightArr[j];
            j++;
            k++;
        }
    }
    
    /**
    * Reads file from "filePath" and separates the words into a string[] array.
    * Removes non-alphabetical characters and converts upper case characters to lower case.
    *
    * Returns an unsorted string[] array containing the split words.
    */
    public static string[] readFile(string filePath) {
        if (!File.Exists(filePath))
            throw new FileNotFoundException();

        string text = File.ReadAllText(filePath);
        char[] delimiters = { ' ', '\n', '\r', '\t' };
        string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
        List<string> words2 = new List<string>(); //prevents empty strings

        for (int i = 0; i < words.Length; i++) {
            string word = words[i];
            string newWord = "";

            for (int j = 0; j < word.Length; j++) {
                char c = word[j];

                if (c >= 'a' && c <= 'z') {
                    newWord += c;
                }
                else if (c >= 'A' && c <= 'Z') {
                    newWord += (char)(c + 32); 
                }
            }
            if (newWord.Length > 0) {
                words2.Add(newWord);
            }
        } //convert upper case characters to lower case, remove non-alphabetic characters

        return words2.ToArray();
    }
}
