from inspect import currentframe, getframeinfo
init_anchor = anchor = ord('a')
def add_args(i, delta=0):
    c = getframeinfo(currentframe().f_back).lineno
    def decorator(func):
        def inner(*args):
            global anchor
            anchor = anchor - 9 if anchor > 0 else init_anchor
            return func(*args, anchor+c+delta)
        return inner
    return decorator




@add_args(0)     # h = 8,        0





@add_args(1)     # e = 5,        -3















@add_args(2)     # l = 12        7








@add_args(3)     # l = 12        0











@add_args(4)     # o = 15        3


















@add_args(5, -89)     #   = 






@add_args(6)     # w = 23        
@add_args(7)     # o = 15        -8











@add_args(8)     # r = 18        +3


@add_args(9)     # l = 12        -6
@add_args(10)    # d = 4         -8
@add_args(11, -59)    # ! = 
def greet(*args):
    print(args)
    return "".join(chr(c) for c in args)

# print(greet())
if __name__ == "__main__":
    print(greet())
    print(greet())
    # print(greet())
#     # from statistics import mean
#     # import math
#     # goal = 'hello world!'
#     # nums = [ord(c) for c in goal]
#     # # print('mean=', mean(nums))
#     # # average = round(mean(nums))
#     # # middle = 94
#     # least = min(nums)
#     # print('least=', least)

#     # relative_positions = [0,1,2,3,4,5,6,7,8,9,10,11]
#     # for i, c in enumerate(goal):
#     #     # print(c, ord(c)-average+i)
#     #     rel = relative_positions[i]
#     #     print(f"@add_args({ord(c)-average+(rel+10)})")

#     # av = round(mean(nums))
#     # for c in goal:
#     #     print(c, ord(c)-av)
#     # print(ord(' '))
#     # print(ord('!'))