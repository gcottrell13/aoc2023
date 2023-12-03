using System.Text.RegularExpressions;

namespace AOC2023;

internal class Day1 : AOCHelper
{
    private static readonly Dictionary<string, int> NUMBERS = new()
    {
        {"one",1 },
        {"two",2},
        {"three",3},
        {"four",4},
        {"five",5 },
        {"six", 6 },
        {"seven", 7 },
        {"eight", 8 },
        {"nine", 9 },
    };

    private static int getNum(string n) => NUMBERS.TryGetValue(n, out var num) ? num : int.Parse(n);

    private static Regex re1 = new(@"(\d)");
    private static Regex re2 = new(@"(\d|one|two|three|four|five|six|seven|eight|nine)");


    public Day1() : base("2023", "1")
    {
        testData1 = """
            1abc2
            pqr3stu8vwx
            a1b2c3d4e5f
            treb7uchet
            """;
        testData2 = """
            two1nine
            eightwothree
            abcone2threexyz
            xtwone3four
            4nineeightseven2
            zoneight234
            7pqrstsixteen
            """;
    }

    protected override string part1(string[] input)
    {
        int total = 0;
        foreach (var line in input)
        {
            var m = re1.Matches(line);
            var first = int.Parse(m[0].Value);
            var last = int.Parse(m[^1].Value);
            total += first * 10 + last;
        }
        return total.ToString();
    }

    protected override string part2(string[] input)
    {
        int total = 0;
        foreach (var line in input)
        {
            var m = re2.Match(line);
            var first = getNum(m.Value);

            var pos = line.Length - 1;
            while (true)
            {
                m = re2.Match(line, pos);
                if (m.Success)
                {
                    var last = getNum(m.Value);
                    //Console.WriteLine($"{line} - {first} - {last}");
                    total += first * 10 + last;
                    break;
                }
                pos--;
            }
        }
        return total.ToString();
    }
}