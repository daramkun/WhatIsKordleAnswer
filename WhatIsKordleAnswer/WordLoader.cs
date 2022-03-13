using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace WhatIsKordleAnswer;

public static class WordLoader
{
    private static List<string> totalWords = new();

    private static string RemoveNumber(string word)
    {
        var charArray = word.ToCharArray();
        var newCharArray = new char[charArray.Length];
        var count = 0;

        foreach (var ch in charArray)
        {
            if (char.IsNumber(ch))
                continue;
            newCharArray[count++] = ch;
        }
        
        return new string(newCharArray, 0, count);
    }

    public static void LoadWords()
    {
        using var stream = Assembly.GetEntryAssembly()?.GetManifestResourceStream("WhatIsKordleAnswer.WordList.txt")
                           ?? throw new NullReferenceException();
        using var reader = new StreamReader(stream, Encoding.UTF8, true);

        var words = new List<string>();
        while (true)
        {
            var word = reader.ReadLine();
            if (word == null)
                break;
            
            word = RemoveNumber(word);

            if (words.Contains(word))
                continue;
            
            words.Add(word);
        }

        foreach (var word in words)
        {
            var builder = new StringBuilder();
            foreach (var ch in word)
            {
                WordTranslator.SplitWord(ch, out var initialChar, out var neuterChar, out var finalChar);
                if (initialChar == 'ㄲ')
                    builder.Append('ㄱ').Append('ㄱ');
                else if (initialChar == 'ㄸ')
                    builder.Append('ㄷ').Append('ㄷ');
                else if (initialChar == 'ㅆ')
                    builder.Append('ㅅ').Append('ㅅ');
                else if (initialChar == 'ㅃ')
                    builder.Append('ㅂ').Append('ㅂ');
                else if (initialChar == 'ㄳ')
                    builder.Append('ㄱ').Append('ㅅ');
                else if (initialChar == 'ㄵ')
                    builder.Append('ㄴ').Append('ㅈ');
                else if (initialChar == 'ㄶ')
                    builder.Append('ㄴ').Append('ㅎ');
                else if (initialChar == 'ㅄ')
                    builder.Append('ㅂ').Append('ㅅ');
                else if (initialChar == 'ㄺ')
                    builder.Append('ㄹ').Append('ㄱ');
                else if (initialChar == 'ㄺ')
                    builder.Append('ㄹ').Append('ㄱ');
                else if (initialChar == 'ㄻ')
                    builder.Append('ㄹ').Append('ㅁ');
                else if (initialChar == 'ㄼ')
                    builder.Append('ㄹ').Append('ㅂ');
                else if (initialChar == 'ㄽ')
                    builder.Append('ㄹ').Append('ㅅ');
                else if (initialChar == 'ㄾ')
                    builder.Append('ㄹ').Append('ㅌ');
                else if (initialChar == 'ㄿ')
                    builder.Append('ㄹ').Append('ㅍ');
                else if (initialChar == 'ㅀ')
                    builder.Append('ㄹ').Append('ㅎ');
                else if (initialChar == 'ㅉ')
                    builder.Append('ㅈ').Append('ㅈ');
                else
                    builder.Append(initialChar);
                
                if (neuterChar == 'ㅢ')
                    builder.Append('ㅡ').Append('ㅣ');
                else if (neuterChar == 'ㅖ')
                    builder.Append('ㅕ').Append('ㅣ');
                else if (neuterChar == 'ㅔ')
                    builder.Append('ㅓ').Append('ㅣ');
                else if (neuterChar == 'ㅒ')
                    builder.Append('ㅑ').Append('ㅣ');
                else if (neuterChar == 'ㅐ')
                    builder.Append('ㅏ').Append('ㅣ');
                else if (neuterChar == 'ㅟ')
                    builder.Append('ㅜ').Append('ㅣ');
                else if (neuterChar == 'ㅝ')
                    builder.Append('ㅜ').Append('ㅓ');
                else if (neuterChar == 'ㅙ')
                    builder.Append('ㅗ').Append('ㅏ').Append('ㅣ');
                else if (neuterChar == 'ㅞ')
                    builder.Append('ㅜ').Append('ㅓ').Append('ㅣ');
                else
                    builder.Append(neuterChar);

                if (finalChar != '\0' && finalChar != ' ')
                {
                    if (finalChar == 'ㄲ')
                        builder.Append('ㄱ').Append('ㄱ');
                    else if (finalChar == 'ㄸ')
                        builder.Append('ㄷ').Append('ㄷ');
                    else if (finalChar == 'ㅆ')
                        builder.Append('ㅅ').Append('ㅅ');
                    else if (finalChar == 'ㅃ')
                        builder.Append('ㅂ').Append('ㅂ');
                    else if (finalChar == 'ㄳ')
                        builder.Append('ㄱ').Append('ㅅ');
                    else if (finalChar == 'ㄵ')
                        builder.Append('ㄴ').Append('ㅈ');
                    else if (finalChar == 'ㄶ')
                        builder.Append('ㄴ').Append('ㅎ');
                    else if (finalChar == 'ㅄ')
                        builder.Append('ㅂ').Append('ㅅ');
                    else if (finalChar == 'ㄺ')
                        builder.Append('ㄹ').Append('ㄱ');
                    else if (finalChar == 'ㄺ')
                        builder.Append('ㄹ').Append('ㄱ');
                    else if (finalChar == 'ㄻ')
                        builder.Append('ㄹ').Append('ㅁ');
                    else if (finalChar == 'ㄼ')
                        builder.Append('ㄹ').Append('ㅂ');
                    else if (finalChar == 'ㄽ')
                        builder.Append('ㄹ').Append('ㅅ');
                    else if (finalChar == 'ㄾ')
                        builder.Append('ㄹ').Append('ㅌ');
                    else if (finalChar == 'ㄿ')
                        builder.Append('ㄹ').Append('ㅍ');
                    else if (finalChar == 'ㅀ')
                        builder.Append('ㄹ').Append('ㅎ');
                    else if (finalChar == 'ㅉ')
                        builder.Append('ㅈ').Append('ㅈ');
                    else
                        builder.Append(finalChar);
                }
            }

            if (builder.Length != 6)
                continue;
            
            totalWords.Add(builder.ToString());
        }
    }

    public static IEnumerable<string> GetMatchingWords(char[] specificCharArray, params char[] existChars)
    {
        foreach (var word in totalWords)
        {
            var matching = true;
            for (var i = 0; i < 6; ++i)
            {
                if (specificCharArray[i] == '\0')
                    continue;
                if (word[i] != specificCharArray[i])
                {
                    matching = false;
                    break;                    
                }
            }

            if (!matching)
                continue;

            foreach (var existChar in existChars)
            {
                if (!word.Contains(existChar))
                {
                    matching = false;
                    break;
                }
            }

            if (!matching)
                continue;

            yield return word;
        }
    }
}