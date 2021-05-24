from inspect import currentframe, getframeinfo
init_anchor = anchor = 99
def scroll_down(delta=0):
    l = getframeinfo(currentframe().f_back).lineno
    def decorator(func):
        def inner(*args):
            global anchor
            anchor = anchor - 9 if anchor >= 0 else init_anchor - 9
            return func(*args, anchor+l+delta)
        return inner
    return decorator


@scroll_down()





@scroll_down()















@scroll_down()








@scroll_down()











@scroll_down()


















@scroll_down(-89)






@scroll_down()
@scroll_down()











@scroll_down()


@scroll_down()
@scroll_down()
@scroll_down(-59)
def greet(*args):
    return "".join(chr(c) for c in args)

print(greet())