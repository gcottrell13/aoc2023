using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023;

internal abstract class AOCHelper
{
    private readonly string year;
    private readonly string day;
    protected string testData1 = "";
    protected string testData2 = "";
    protected readonly string data;

    public AOCHelper(string year, string day)
    {
        this.year = year;
        this.day = day;
        data = GetInput();
    }

    protected string testData { set
        {
            testData1 = value;
            testData2 = value;
        } }

    public string GetInput()
    {
        using HttpClient client = new();
        using var file = File.OpenRead("session_id");
        byte[] buffer = new byte[128];
        file.Read(buffer, 0, buffer.Length);
        var session = Encoding.UTF8.GetString(buffer);
        client.DefaultRequestHeaders.Add("Cookie", $"session={session}");
        var response = client.Send(new()
        {
            RequestUri= new($"https://adventofcode.com/{year}/day/{day}/input"),
        });
        response.EnsureSuccessStatusCode();
        return response.Content.ReadAsStringAsync().Result;
    }

    protected abstract string part1(string[] input);
    protected abstract string part2(string[] input);

    private static string[] sanitize(string input) => 
        input.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    public string Part1() => part1(sanitize(data));
    public string Part2() => part2(sanitize(data));
    public string Part1Test() => part1(sanitize(testData1));
    public string Part2Test() => part2(sanitize(testData2));

    public static (string, string) twople(string[] items)
    {
        if (items.Length > 2) throw new ArgumentException("more than 2 items");
        return (items[0], items[1]);
    }
}
