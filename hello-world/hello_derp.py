from inspect import currentframe, getframeinfo
init_anchor = anchor = 99
def add_args(delta=0):
    l = getframeinfo(currentframe().f_back).lineno
    def decorator(func):
        def inner(*args):
            global anchor
            anchor = anchor - 9 if anchor >= 0 else init_anchor - 9
            return func(*args, anchor+l+delta)
        return inner
    return decorator


@add_args()





@add_args()















@add_args()








@add_args()











@add_args()


















@add_args(-89)






@add_args()
@add_args()











@add_args()


@add_args()
@add_args()
@add_args(-59)
def greet(*args):
    return "".join(chr(c) for c in args)

# print(greet())
if __name__ == "__main__":
    print(greet())
    print(greet())
    print(chr(59))
    print(chr(89))
    # print(ord('a') + 2)
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