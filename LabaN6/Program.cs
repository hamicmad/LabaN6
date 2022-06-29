using System.Text;
using System.Text.RegularExpressions;

var sb = new StringBuilder();

// 1.Написать  программу замены в тексте "О" на "А".
string str1 = "";
str1 = str1.Replace('O', 'A');

// 2.Напечатать в столбик числовые коды букв введенного слова.
string str2 = "Хелоу Ворлд";
foreach (char c in str2)
    Console.WriteLine((int)c + "\t");

// 3.Написать программу  подсчета  количества  гласных в тексте 
var count3 = Regex.Matches(str2, @"[ауоыиэяюёе]", RegexOptions.IgnoreCase).Count;
Console.WriteLine("!!!!!!!" + count3);
// 4. Написать программу, удваивающую каждый символ в заданном  тексте
foreach (var item in str2)
{
    sb.Append(item.ToString() + item.ToString());
}
Console.WriteLine(sb);

// 5.Написать  программу,  выясняющую, является ли данное слово палиндромом ("перевёртышем").
string str5 = "казак";
char[] chr = str5.ToCharArray();
Array.Reverse(chr);
string str6 = new string(chr);
if (str5 == str6) Console.WriteLine("True");
else Console.WriteLine("False");

// 6. Написать программу, вычёркивающую  из  данного слова все буквы   "а"  
// (так, чтобы, например, из  слова  "заноза"   получилось "зноз").
string str7 = "заноза";
str7 = str7.Replace("а", "");

// 7.Написать программу, проверяющую, является ли частью данного слова слово "сок".
string str8 = "Сокровище";
if (str8.ToLower().Contains("сок"))
    Console.WriteLine("true");
else Console.WriteLine("false");

// 8.Написать программу, подсчитывающую, сколько раз в данном слове встречается сочетание "со".
string str9 = "сососокросовка";
var count9 = Regex.Matches(str9, @"со", RegexOptions.IgnoreCase).Count();
Console.WriteLine(count9);

// 9.Написать программу, заменяющую  в  тексте  все  большие латинские буквы на маленькие

var alphabet = Enumerable.Range(65, 26).Select(x => (char)x);
string str10 = "HELLO WORLD - ПРИВЕТ МИР";
char[] chr10 = str10.ToCharArray();
for (var c = 0; c < chr10.Length; c++)
    if (alphabet.Contains(chr10[c]))
        chr10[c] = char.ToLower(chr10[c]);

var str11 = str10.Select(x => alphabet.Contains(x) ? char.ToLower(x) : x);


// 10.Дана строка символов, состоящая из произвольного текста на английском языке, слова отделены пробелами.
// После каждого гласного символа вставить символ “*”.
var sb1 = "Ahe band eventually split due to creative differences";
string res10 = Regex.Replace(sb1, @"[aeiouy]", match => match.Value + "*", RegexOptions.IgnoreCase);
Console.WriteLine(res10);
char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y' };
var res11 = sb1.Select(x => vowels.Contains(x) ? new string(x + "*") : x.ToString());
Console.WriteLine(string.Concat(res11));

// 11.Вывести все строчные гласные латинские буквы, встречающие в данной строке ровно один раз.
var str12 = "ThE band eventually";
Console.WriteLine(string.Concat(str12.Where(x => vowels.Contains(x) &&
                                                    char.IsLower(x) &&
                                                    str12.Count(v => v == x)== 1)));

// 12.В заданном тексте подсчитать количество четырехбуквенных слов
// и каждое четное из них заменить на сочетание "SsSs". 
var str13 = "The band eventually spli duet to creative differences";
var res12 = str13.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                 .Select((x, index) => x.Length == 4 && (index + 1) % 2 == 0 ? "SsSs" : x );

Console.WriteLine(string.Join(" ",res12));

int count = 0;
string[] words = str13.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
for (int i = 0; i < words.Length; i++)
    if (words[i].Length == 4 && (i + 1) % 2 == 0)
    {
        count++;
        words[i] = "SsSs";
    }
Console.WriteLine($"Количество слов: {count}. \n{string.Join(" ", words)}") ;

// 13.Отредактировать предложение, удаляя из него лишние пробелы, оставляя по одному пробелу между словами.
// Убирая лишний пробел перед знаками препинания.
var str14 = "The   ,   band eventually   ,   split due to creative   ,   differences";
str14 = Regex.Replace(str14,@"\s+", " ");
var res14 = str14.ToCharArray();

for (int i = 0;i < res14.Length; i++)
{
    if (char.IsPunctuation(res14[i]) && res14[i - 1] == ' ')
        res14[i - 1] -= ' ';
}

Console.WriteLine("res14" + string.Concat(res14));

//14.В заданном предложении указать слова, в котором доля гласных максимальна и их длина не превосходит n символов.
var str15 = "The band eventually split due to creative differences";
var wordss = str15.Split(' ');
foreach (string word in wordss)
{
    var matches = Regex.Matches(word, @"[aeiouy]", RegexOptions.IgnoreCase);
    var percentage = (double)matches.Count / word.Length * 100;
    if (percentage > 50 && word.Length <= 5)
        Console.WriteLine($"Доля гласных в слове \"{word}\": {percentage}%");

}
// 15.Для каждого слова заданного текста указать долю согласных.
//Определить слово, в котором доля согласных максимальна.
var searchWord = string.Empty;
var maxPercent = 0.0;
foreach (string word in wordss)
{
    var matches = Regex.Matches(word, @"[BСDFGHJKLMNPQRSTVWXYZ]", RegexOptions.IgnoreCase);
    var percentage = (double)matches.Count / word.Length * 100;
    Console.WriteLine($"Доля согласных в слове {word}: {percentage}%");
    if (maxPercent < percentage)
    {
        maxPercent = percentage;
        searchWord = word;
    }
}

// 16.Найти количество слов, которые располагаются между (),{},[].
// В ответе указать в каких скобках слов больше.
var str16 = "(ууу ууу ууу ууу ууу) {split due} [to creative differences aaa]";
var res16 = Regex.Matches(str16, @"\((.+)\) \{(.+)\} \[(.+)\]");
int max;
int cnt1 = 0;
int cnt2 = 0;
int cnt3 = 0;

foreach (Match m in res16)
{
     cnt1 = new string(m.Groups[1].Value).Split(' ').Count();
     cnt2 = new string(m.Groups[2].Value).Split(' ').Count();
     cnt3 = new string(m.Groups[3].Value).Split(' ').Count();
}
Console.WriteLine(cnt1);
max = cnt1;
if (cnt2 > cnt1)
{
    max = cnt2;
    Console.WriteLine("Больше слов в скобках {}");
}

else if (cnt3 > max)
{
    max = cnt3;
    Console.WriteLine("Больше слов в скобках []");
}

else
{
    Console.WriteLine("Больше слов в скобках ()");
}


// 17.Найти самое длинное симметричное слово заданного текста и указать номер позиции,
// с которого оно начинается
bool IsSimm(string word)
{
    for (int i = 0, j = word.Length - 1; i < word.Length / 2; i++, j--)
        if (word[i] != word[j])  return false;
    return true;
}

var str17 = "макакам малам мамам манекенам сэс";
var res17 = str17.Split(' ', StringSplitOptions.RemoveEmptyEntries);
var res18 = res17.Where(x => x.Length == res17.Max(x => x.Length) && IsSimm(x) == true);
var resIndex = Array.IndexOf(res17,string.Concat(res18));
Console.WriteLine($"Слово:{string.Concat(res18)}, Индекс: {resIndex}");

// 18. Из заданного текста предложения выбрать и вывести только те символы,
// которые встречаются в нем только один раз (в том порядке, в котором они встречаются в тексте).
var str18 = "The band  #eventually // split due to & creative differences";
var res19 = str18.Where(x => str18.Count(v => v == x) == 1);
foreach (var item in res19)
    Console.Write(item + " " );

// 19.Задан текст, состоящий из произвольной количества слов.
// В каждом из слов в этом тексте отсортировать символы в алфавитном порядке.
var str19 = "The band eventually split due to creative differences";
var res20 = Regex.Replace(str19, @"\w+", (x) => new string(x.Value.OrderBy(x => x).ToArray()));
Console.WriteLine();
Console.WriteLine(res20);

//// 20. Задана строка символов, состоящая из букв, цифр, точек, символов «+» и «-».
//// Заменить все выражения на их решение.
//var str20 = "abc 5 + 7 9 - 5 cda";
//var matches1 = Regex.Matches(str20, @"(\d+\W*) (\d+\W*)");

//string res21 = string.Empty;
//foreach (Match m in matches1)
//{
//    Console.WriteLine(m.Groups[1].Value);
   
//}








