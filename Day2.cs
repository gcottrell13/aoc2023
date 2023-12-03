using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023;


internal class Day2 : AOCHelper
{
    public Day2() : base("2023", "2")
    {
        testData = """
            Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
            Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
            Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
            Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
            Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
            """;
    }

    protected override string part1(string[] input)
    {
        var maxCounts = new Dictionary<string, int>()
        {
            {"blue", 14 },
            {"red", 12 },
            {"green", 13 },
        };

        int total = 0;

        foreach (var line in input)
        {
            var (gamename, gameinfo) = twople(line.Split(": "));
            var (_, gameid) = twople(gamename.Split(" "));
            var pulls = gameinfo.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            foreach (var pull in pulls)
            {
                var (count, color) = twople(pull.Split(" "));
                if (int.Parse(count) > maxCounts[color]) goto Fail;
            }

            total += int.Parse(gameid);

            Fail: { }
        }

        return total.ToString();
    }

    protected override string part2(string[] input)
    {
        int total = 0;

        foreach (var line in input)
        {
            var (gamename, gameinfo) = twople(line.Split(": "));
            var (_, gameid) = twople(gamename.Split(" "));
            var pulls = gameinfo.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            var maxCounts = new Dictionary<string, int>()
            {
                {"blue", 0 },
                {"red", 0 },
                {"green", 0 },
            };

            foreach (var pull in pulls)
            {
                var (count, color) = twople(pull.Split(" "));
                maxCounts[color] = Math.Max(maxCounts[color], int.Parse(count));
            }
            var power = maxCounts.Values.Aggregate((agg, current) => agg * current);
            total += power;
        }

        return total.ToString();
    }


}
