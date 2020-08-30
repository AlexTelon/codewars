# https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8/train/python

def tickets(amounts):
    bills = {
        100: 0,
        50: 0,
        25: 0
    }

    def not_enough_change():
        # If we are negative in any of the bills it means we didn't have enough.
        return any(x < 0 for x in bills.values())

    def update_change(amount):
        # We never have any use of 100 bills. So we could skip adding it to the change to solve this problem.
        
        # The number of bills exchanged. In the case of recieving a 100 dollar bill we have two options.
        # Having 2 25's is always better than a 50 so we try to give back that back if possible.
        needed_change = {
            100: lambda : {100: 1, 50: -1, 25: -1} if bills[50] > 0 else {100: 1, 25: -3},
            50: lambda : {50: 1, 25: -1},
            25: lambda : {25: 1},
        }        

        exchange = needed_change[amount]()

        # add/remove the bills exchanged
        for key in exchange.keys():
            bills[key] += exchange[key]

    # Everyone has 100, 50 or 25 dollars. So guaranteed to have enough, no need to check for that.
    for amount in amounts:
        update_change(amount)

        if not_enough_change():
            return "NO"

    return "YES"

assert tickets([25, 25, 50]) == "YES"
assert tickets([25, 100]) == "NO"
assert tickets([25, 50]) == "YES"
assert tickets([25, 25, 50, 50, 100]) == "NO"

print('ok')