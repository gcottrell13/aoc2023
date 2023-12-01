# day 1 
from getinput import fetch_input

data = fetch_input(2023, 1)
import re

# data = """
# two1nine
# eightwothree
# abcone2threexyz
# xtwone3four
# 4nineeightseven2
# zoneight234
# 7pqrstsixteen
# """.strip()

numbers = 'one|two|three|four|five|six|seven|eight|nine'
names = {
    n: str(i + 1)
    for i, n in enumerate(numbers.split('|'))
}

for v in list(names.values()):
    names[str(v)] = v

total = 0
digit_re = re.compile(rf'(\d|{numbers})')
for line in data.splitlines():
    pos = 0
    digits = []
    while match := digit_re.search(line, pos=pos):
        digits.append(names[match.groups()[0]])
        pos = match.pos + 1
    if not digits:
        print('NO DIGITS', line)
        break
    first, second = names[digits[0]], names[digits[-1]]
    print(first, second, line)
    total += int(first + second)

print(total)
