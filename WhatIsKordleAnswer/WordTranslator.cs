using System;

namespace WhatIsKordleAnswer;

public static class WordTranslator
{
    // 초성, 중성, 종성 테이블.
    private static string initialTable = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";
    private static string neuterTable = "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";
    private static string finalTable = " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";
    private static ushort koreanUnicodeFirst = 0xAC00;
    private static ushort koreanUnicodeLast = 0xD79F;

    public static void SplitWord(char ch, out char initialChar, out char neuterChar, out char finalChar)
    {
        var uTempCode = Convert.ToUInt16(ch);
        if ((uTempCode < koreanUnicodeFirst) || (uTempCode > koreanUnicodeLast))
        {
            initialChar = '\0';
            neuterChar = '\0';
            finalChar = '\0';
        }
        
        var unicodeIndex = uTempCode - koreanUnicodeFirst;
        var initialIndex = unicodeIndex / (21 * 28);
        unicodeIndex = unicodeIndex % (21 * 28);
        var neuterIndex = unicodeIndex / 28;
        unicodeIndex = unicodeIndex % 28;
        var finalIndex = unicodeIndex;
        
        initialChar = initialTable[initialIndex];
        neuterChar = neuterTable[neuterIndex];
        finalChar = finalTable[finalIndex];
    }
}