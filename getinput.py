import requests

with open('session_id', 'r') as f:
    session_id = f.read()


def fetch_input(year, day):
    url = f'https://adventofcode.com/{year}/day/{day}/input'
    headers = {'Cookie': f'session={session_id}'}
    response = requests.get(url, headers=headers)
    return response.text.strip()

