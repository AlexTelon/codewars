#https://www.codewars.com/kata/54ca3e777120b56cb6000710/train/python

# def chained(functions):
#     if len(functions) == 0:
#         return lambda x: x
#     else:
#         return lambda x: functions[-1]( chained(functions[:-1])(x) )
#         # return lambda x: chained(functions[1:])(functions[0](x)) # this is ok too


# the code above was a bit tricky to get right.
# After seeing other solutions I realise that creating a higher order function is just a matter 
# of creating an inner function, solve the problem in that inner function and then return it in the outer scope.
# see below:
def chained(functions):
    # First define a inner function.
    # Inside this function we simply solve the problem normally.
    def f(x):
        for func in functions:
            x = func(x)
        return x
    # Return the inner function
    return f


# Below are the tests given 
def f1(x): return x*2
def f2(x): return x+2
def f3(x): return x**2

def f4(x): return x.split()
def f5(xs): return [x[::-1].title() for x in xs]
def f6(xs): return "_".join(xs)

assert chained([f1,f2,f3])(0) == 4
assert chained([f1,f2,f3])(2) == 36
assert chained([f3,f2,f1])(2) == 12
assert chained([f4,f5,f6])("lorem ipsum dolor") == "Merol_Muspi_Rolod"

