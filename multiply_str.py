def multiply(num1: str, num2: str) -> str:
    if(num1 == '0' or num2 == '0'):
        return '0'

    # Check if the result is postive
    carry = 0
    res = ''
    isPos = True if('-' in num1 and '-' in num2) or ('-' not in num1 and '-' not in num2) else False
    if(isPos is False):
        res = '-' + res
        num1 = num1[1:len(num1)] if '-' in num1 else num1[0:len(num1)]
        num2 = num2[1:len(num2)] if '-' in num2 else num2[0:len(num2)]

    num = [0 for _ in range(len(num1) + len(num2))]
    # Multiply each position of num1 and num2
    for i in range(len(num2) - 1, -1, -1):
        for j in range(len(num1) - 1, -1, -1):
            num[i + j + 1] += (int(num1[j]) * int(num2[i])) % 10
            carry = (int(num1[j]) * int(num2[i])) // 10
            num[i+j] += carry
    print(num)
    # Handle remaining carries
    for i in range(len(num) - 1, -1, -1):
        carry = num[i] // 10
        num[i] = num[i] % 10
        num[i - 1] += carry
    print(num)

    if(num[0] == 0):
        num = num[1:len(num)]
    else:
        num = num[0:len(num)]

    for i in range(0, len(num)):
        res += str(num[i])

    return res

num1 = '18'
num2 = '8'
res = multiply(num1, num2)
print(res)