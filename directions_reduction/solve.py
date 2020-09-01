# https://www.codewars.com/kata/550f22f4d758534c1100025a/solutions/python/all/best_practice

def dirReduc_original(directions):
    def are_opposite(a, b):
        invert = {
            "NORTH": "SOUTH",
            "SOUTH": "NORTH",
            "WEST": "EAST",
            "EAST": "WEST",
            "None": "None"
        }
        return a == invert[b]
    directions.append('None')

    result = []
    for i, (current, upcomming) in enumerate(zip(directions, directions[1:])):
        if are_opposite(current, upcomming):
            return dirReduc_original(result + directions[i+2:])
        else:
            result.append(current)

    return result

# A nice solution by others used a stack based approach.
# Recursive and stack based solutions can be very similar since recursion is basically just callSTACK stuff anyways.
# Very elegant and fast!
# I improved it a bit by initializing the new_plan with the first item and removing a check.
def dirReduc(plan):
    opposite = {
        "NORTH": "SOUTH",
        "SOUTH": "NORTH",
        "WEST": "EAST",
        "EAST": "WEST",
    }

    # Add a sentinel/dummy value which will never be removed.
    # This guarantees that there is always a at least 1 value in new_plan.
    new_plan = ["dummy"]
    # The dummy in new_plan allows us to skip checking if new_plan[-1] is possible.
    previous = lambda : new_plan[-1]
    # Adding 1 sentinel value thus allows us to remove a check that needs to be done in each iteration otherwise.
    # For more speedup removal of this lambda can be done. But this is better for clarity

    for current in plan:
        if previous() == opposite[current]:
            # If the one we already have added is opposite to the one we are about to add.
            # Then dont add the new one and remove the previous one!
            new_plan.pop()
        else:
            new_plan.append(current)

    # Exclude the dummy value.
    return new_plan[1:]


# Some tests

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