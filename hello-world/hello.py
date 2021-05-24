from inspect import currentframe, getframeinfo
average = 114
def add_args(a=0):
    c = getframeinfo(currentframe().f_back).lineno
    def decorator(func):
        def inner(*args):
            return func(*args, average-c+a)
        return inner
    return decorator
@add_args()


@add_args() # moving down to increase the number
@add_args(8)
@add_args(9)
@add_args(13)
@add_args(-65)
@add_args(23)
@add_args(16)
@add_args(20)
@add_args(15)
@add_args(8)
@add_args(-58)
def greet(*args):
    return "".join(chr(c) for c in args)

print(greet())
from statistics import mean
import math
goal = 'hello world!'
nums = [ord(c) for c in goal]
# print('mean=', mean(nums))
# average = round(mean(nums))
# middle = 94
least = min(nums)
print('least=', least)

relative_positions = [0,1,2,3,4,5,6,7,8,9,10,11]
for i, c in enumerate(goal):
    # print(c, ord(c)-average+i)
    rel = relative_positions[i]
    print(f"@add_args({ord(c)-average+(rel+10)})")