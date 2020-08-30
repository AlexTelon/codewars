# https://www.codewars.com/kata/555615a77ebc7c2c8a0000b8/train/python
from collections import Counter

def tickets(amounts):
    till = Counter()

    def not_enough_change():
        # If we are negative in any of the bills in the till it means we didn't have enough to sell a ticket.
        return any(x < 0 for x in till.values())

    def sell_ticket(amount):
        # We never have any use of 100 bills. So we could skip adding it to the change to solve this problem.
        
        # The number of bills exchanged. In the case of recieving a 100 dollar bill we have two options.
        # Having 2 25's is always better than a 50 so we try to give back that back if possible in the case of 100.
        exchange = {
            100: lambda : Counter({100: 1, 50: -1, 25: -1}) if till[50] > 0 else Counter({100: 1, 25: -3}),
            50: lambda : Counter({50: 1, 25: -1}),
            25: lambda : Counter({25: 1}),
        }        

        # Add/remove the bills exchanged.
        till.update( exchange[amount]() )

    # Everyone has 100, 50 or 25 dollars. So guaranteed to have enough, no need to check for that.
    for amount in amounts:
        sell_ticket(amount)

        if not_enough_change():
            return "NO"

    return "YES"

# assert tickets([25, 25, 50]) == "YES"
assert tickets([25, 100]) == "NO"
assert tickets([25, 50]) == "YES"
assert tickets([25, 25, 50, 50, 100]) == "NO"

print('ok')