from itertools import cycle
import math

# def thirt(n):
#     def find_total(n):        
#         def reminder():
#             for num in cycle([1, 10, 9, 12, 3, 4]):
#                 yield num
#         rem = reminder()
#         return sum([int(c) * next(rem) for c in str(n)[::-1]])

#     prev, current = math.nan, find_total(n)
#     while prev != current:
#         prev, current = current, find_total(current)

#     return current
def thirt(n):
    def find_total(n):        
        pattern = cycle([1, 10, 9, 12, 3, 4])
        return sum([int(c) * next(pattern) for c in str(n)[::-1]])

    prev, current = math.nan, find_total(n)
    while prev != current:
        prev, current = current, find_total(current)

    return current

print(thirt(1234567))