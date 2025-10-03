def divide(dividend:int, divisor:int) -> int:
    if(dividend == 0): return 0

    checkPos = (dividend > 0 and divisor > 0) or (dividend < 0 and divisor < 0)
    dividend = abs(dividend)
    divisor = abs(divisor)

    quotient = 0
    print('Check whether quotient is negative or positve number:', checkPos)
    
    while(dividend >= divisor):
        shlftVal = 1
        # Find the biggest number with divisor that dividend can be divisible
        while(dividend >= (divisor * shlftVal << 1)):
            shlftVal = shlftVal << 1
            print('Shift left value we got:', shlftVal)

        # Update value dividend
        dividend -= (divisor * shlftVal)
        quotient += shlftVal
        print('Value of diviend:', dividend)

    # while(dividend >= divisor):
    #     dividend = dividend - divisor
    #     quotient += 1
    
    # Check if quotient is neg or pos
    if(checkPos is False):
        quotient *= -1
    
    if(quotient < -2**31):
        return -2**31
    
    if(quotient > 2**31 - 1):
        return 2**31 - 1
    return quotient

dividened, divisor = 10, -3
res = divide(dividened, divisor)
print('Result:', res)