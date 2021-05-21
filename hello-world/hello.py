def add_args(c):
    def decorator(func):
        def inner(*args):
            return func(*args, 96-c)
        return inner
    return decorator


@add_args(-8)
@add_args(-5)
@add_args(-12)
@add_args(-12)
@add_args(-15)
@add_args(64)
@add_args(-23)
@add_args(-15)
@add_args(-18)
@add_args(-12)
@add_args(-4)
@add_args(63)
def greet(*args):
    return "".join(chr(c) for c in args)

print(greet())
# from statistics import mean
# import math
# nums = [ord(c) for c in greet()]
# print('mean=', mean(nums))
# average = round(mean(nums))

# for c in greet():
#     print(c, average-ord(c))
