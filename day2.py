# day 2 
from getinput import fetch_input 
data = fetch_input(2023, 2)

allowed = {
    'red': 12,
    'green': 13,
    'blue': 14,
}

d1ata = """
Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
""".strip()

products = []

for line in data.splitlines():
    game, cubes = line.split(': ')
    _, id = game.split()
    counts = {}
    color_counts = [
        color_count
        for handful in cubes.split('; ')
        for color_count in handful.split(', ')
    ]
    for color_count in color_counts:
        count, color = color_count.split()
        counts[color] = max(int(count), counts.get(color, 0))
    product = 1
    for v in counts.values():
        product *= v
    products.append(product)

print(sum(products))

