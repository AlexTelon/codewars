def are_opposite(a, b):
    invert = {
        "NORTH": "SOUTH",
        "SOUTH": "NORTH",
        "WEST": "EAST",
        "EAST": "WEST",
        "None": "None"
    }
    return a == invert[b]

def dirReduc(directions):
    directions.append('None')

    result = []
    for i, (current, upcomming) in enumerate(zip(directions, directions[1:])):
        if are_opposite(current, upcomming):
            return dirReduc(result + directions[i+2:])
        else:
            result.append(current)

    return result

u=["NORTH", "WEST", "SOUTH", "EAST"]
if dirReduc(u) == ["NORTH", "WEST", "SOUTH", "EAST"]:
    print('ok')
else:
    print(dirReduc(u))

a = ["NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST"]
if dirReduc(a) == ['WEST']:
    print('ok')
else:
    print(dirReduc(a))